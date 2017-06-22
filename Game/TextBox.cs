using System;
using SFML.Graphics;
using SFML.Window;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceExplorers
{
    class TextBox : HudEntity
    {
        Text text;

        // --Constructors--
        public TextBox(string ID, Vector position, int[] size, Font font, uint charSize) : base(ID, position, size, null)
        {
            text = new Text()
            {
                Font = font,
                CharacterSize = charSize,
                Position = new Vector2f(position.X, position.Y)
            };
            text.Scale = new Vector2f(0.5f, 0.5f);
        }

        public TextBox() : base()
        {
            // do nothing
        }

        public void SetColor(byte r, byte g, byte b, byte alpha)
        {
            text.Color = new Color(r, g, b, alpha);
        }

        public void SetText(string newText)
        {
            text.DisplayedString = newText;
            // Remember to implement text wrapping
        }

        public override Renderable Draw()
        {
            return new Renderable(text);
        }

        public override void SetPosition(Vector pos)
        {
            position = pos;
            text.Position = new Vector2f(position.X, position.Y);
        }
    }
}
