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
        Text Text { get; set; }

        // --Constructors--
        public TextBox(string ID, Vector size, Font font, uint charSize) : base(ID, size, null)
        {
            Text = new Text()
            {
                Font = font,
                CharacterSize = charSize,
                Position = new Vector2f(0, 0)
            };
            Text.Scale = new Vector2f(0.5f, 0.5f);
        }

        public TextBox() : base()
        {
            // do nothing
        }

        public override Entity Copy()
        {
            TextBox copy = (TextBox)base.Copy();
            copy.Text = new Text()
            {
                Font = Text.Font,
                CharacterSize = Text.CharacterSize,
                Position = Text.Position,
                Color = Text.Color,
            };
            copy.Text.Scale = new Vector2f(0.5f, 0.5f);
            return copy;
        }

        public void SetColor(byte r, byte g, byte b, byte alpha)
        {
            Text.Color = new Color(r, g, b, alpha);
        }

        public void SetText(string newText)
        {
            Text.DisplayedString = newText;
            // Remember to implement text wrapping
        }

        public override Renderable Draw()
        {
            return new Renderable(Text);
        }

        public override void SetPosition(Vector pos)
        {
            Position = pos;
            Text.Position = new Vector2f(Position.X, Position.Y);
        }
    }
}
