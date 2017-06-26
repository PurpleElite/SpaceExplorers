using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceExplorers
{
    public struct Renderable
    {
        public Sprite sprite;
        public Text text;
        public Renderable(Drawable drawable)
        {
            sprite = drawable as Sprite;
            text = drawable as Text;
        }
    }

    interface IRenderable
    {
        Renderable Draw();
    }
}
