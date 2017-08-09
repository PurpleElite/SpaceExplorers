using System;
using System.Collections.Generic;
using SFML.Graphics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SpaceExplorers
{
    static class AnimationLibrary
    {
        public static Dictionary<string, Animation> Animations = new Dictionary<string, Animation>();

        public static void Initialize()
        {
            string baseDir = Path.Combine("Images", "Animations");
            string[] animDirs = Directory.GetDirectories(baseDir);
            foreach(string animDir in animDirs)
            {
                string animName = Path.GetFileName(animDir);
                AnimType type = (AnimType)(-1);
                int frameDuration = 8;
                try {
                    //Following block borrowed from user A876 on stackoverflow.com
                    using (StreamReader reader = new StreamReader(Path.Combine(animDir, "config.txt")))  // Open the file for reading (and auto-close).
                    {
                        while (!reader.EndOfStream)
                        {
                            string sLine = reader.ReadLine().Trim();  // Read the next line. Trim leading and trailing whitespace.

                            int i = sLine.IndexOf("=");  // Find the first "=" in the line.
                            if (i <= 0) // IF the first "=" in the line is the first character (or not present),
                                continue;  // the line is not a parameter line. Ignore it. (Iterate the while.)
                            string sParameter = sLine.Remove(i).TrimEnd();  // All before the "=" is the parameter name. Trim whitespace.
                            string sValue = sLine.Substring(i + 1).TrimStart();  // All after the "=" is the value. Trim whitespace.

                            i = sValue.IndexOfAny(new char[] { ' ', '\t' });  // Find the first " " or tab in the value.
                            if (i > 1) // IF the first " " or tab is the second character or after,
                                sValue = sValue.Remove(i);  // All before the " " or tab is the parameter. (Discard the rest.)

                            // IF a desired parameter is specified, collect it:
                            if (sParameter == "type")
                                type = (AnimType) Enum.Parse(typeof(AnimType), sValue);
                            else if (sParameter == "stepDuration")
                                frameDuration = int.Parse(sValue);
                        } // end while
                    } // end using
                    if (Enum.IsDefined(typeof(AnimType), type))
                    {
                        Animation newAnim = new Animation(animName, type);
                        string[] frames = Directory.GetFiles(animDir, "frame*");
                        foreach (string framePath in frames)
                        {
                            string frameName = Path.GetFileName(framePath);
                            TextureLibrary.Textures.Add(animName + frameName, new Texture(new Image(framePath)));
                            newAnim.Frames.Add(new Animation.Frame(animName + frameName, frameDuration));
                        }
                        Animations.Add(newAnim.ID, newAnim);
                    }
                    else
                    {
                        Console.WriteLine("Error! No Animation tyoe defined for animation " + animName);
                    }
                }
                catch (IOException)
                {
                    Console.WriteLine("Error! No config file provided for animation " + animName);
                }
            }
        }

        public static Animation Create(string AnimationID)
        {
            if (Animations.ContainsKey(AnimationID))
            {
                Animation newAnimation = Animations[AnimationID].Copy();
                return newAnimation;
            }
            return null;
        }
    }
}
