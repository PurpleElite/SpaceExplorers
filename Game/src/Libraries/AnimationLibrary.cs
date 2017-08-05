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
                Animation newAnim = new Animation(animName);
                string[] frames = Directory.GetFiles(animDir, "frame*");
                foreach(string framePath in frames)
                {
                    string frameName = Path.GetFileName(framePath);
                    TextureLibrary.Textures.Add(animName + frameName, new Texture(new Image(framePath)));
                    newAnim.Frames.Add(new Animation.Frame(animName + frameName, 6));
                }
                Animations.Add(newAnim.ID, newAnim);
            }
        }

        public static Animation Create(string AnimationID)
        {
            Animation newAnimation = Animations[AnimationID].Copy();
            return newAnimation;
        }
    }
}
