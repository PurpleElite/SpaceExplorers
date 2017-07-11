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
            Animation breechWind = new Animation("BreechWind");
            string breechWindPath = Path.Combine("Images", "Animations", "BreechWind");
            TextureLibrary.Textures.Add("BreechWindFrame1.png", new Texture(new Image(Path.Combine(breechWindPath, "Frame1.png"))));
            TextureLibrary.Textures.Add("BreechWindFrame2.png", new Texture(new Image(Path.Combine(breechWindPath, "Frame2.png"))));
            TextureLibrary.Textures.Add("BreechWindFrame3.png", new Texture(new Image(Path.Combine(breechWindPath, "Frame3.png"))));
            TextureLibrary.Textures.Add("BreechWindFrame4.png", new Texture(new Image(Path.Combine(breechWindPath, "Frame4.png"))));
            TextureLibrary.Textures.Add("BreechWindFrame5.png", new Texture(new Image(Path.Combine(breechWindPath, "Frame5.png"))));
            TextureLibrary.Textures.Add("BreechWindFrame6.png", new Texture(new Image(Path.Combine(breechWindPath, "Frame6.png"))));
            TextureLibrary.Textures.Add("BreechWindFrame7.png", new Texture(new Image(Path.Combine(breechWindPath, "Frame7.png"))));
            breechWind.Frames.Add(new Animation.Frame("BreechWindFrame1.png", 6));
            breechWind.Frames.Add(new Animation.Frame("BreechWindFrame2.png", 6));
            breechWind.Frames.Add(new Animation.Frame("BreechWindFrame3.png", 6));
            breechWind.Frames.Add(new Animation.Frame("BreechWindFrame4.png", 6));
            breechWind.Frames.Add(new Animation.Frame("BreechWindFrame5.png", 6));
            breechWind.Frames.Add(new Animation.Frame("BreechWindFrame6.png", 6));
            breechWind.Frames.Add(new Animation.Frame("BreechWindFrame7.png", 6));
            Animations.Add(breechWind.ID, breechWind);
        }

        public static Animation Create(string AnimationID)
        {
            Animation newAnimation = Animations[AnimationID].Copy();
            return newAnimation;
        }
    }
}
