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
        static int defaultStepDuration = 8;
        public static Dictionary<string, Animation> Animations = new Dictionary<string, Animation>();

        public static void Initialize()
        {
            string baseDir = Path.Combine("Images", "Animations");
            string[] animDirs = Directory.GetDirectories(baseDir);
            foreach(string animDir in animDirs)
            {
                string animName = Path.GetFileName(animDir);
                AnimType type = (AnimType)(-1);
                //-1 specifies that default value should be used.
                int stepDur = -1;
                int[] stepDurArr = { };
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
                                type = (AnimType)Enum.Parse(typeof(AnimType), sValue);
                            else if (sParameter == "stepDur")
                                stepDur = int.Parse(sValue);
                            else if (sParameter == "stepDurArr")
                            {
                                string[] temp = sValue.Split(new char[] { '[', ',', ']' }, StringSplitOptions.RemoveEmptyEntries);
                                stepDurArr = new int[temp.Length];
                                for (int j = 0; j < temp.Length; j++)
                                {
                                    stepDurArr[j] = int.Parse(temp[j]);
                                }
                            }
                        } // end while
                    } // end using
                    if (Enum.IsDefined(typeof(AnimType), type))
                    {
                        Animation newAnim = new Animation(animName, type);
                        string[] frames = Directory.GetFiles(animDir, "frame*");
                        for (int i = 0; i < frames.Length; i++)
                        {
                            // Get the texture
                            string framePath = frames[i];
                            string frameName = Path.GetFileName(framePath);
                            TextureLibrary.Textures.Add(animName + frameName, new Texture(new Image(framePath)));
                            // Determine the step duration
                            int stepDuration;
                            if (stepDurArr.Length > i && stepDurArr[i] != -1)
                            {
                                stepDuration = stepDurArr[i];
                            }
                            else if (stepDur != -1)
                            {
                                stepDuration = stepDur;
                            }
                            else
                            {
                                stepDuration = defaultStepDuration;
                            }
                            // Add the frame to the animation
                            newAnim.Frames.Add(new Animation.Frame(animName + frameName, stepDuration));
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
