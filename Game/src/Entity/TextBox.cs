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
        public TextBox(string ID, Vector size, Font font, uint charSize) : base(ID, size, null)
        {
            text = new Text()
            {
                Font = font,
                CharacterSize = charSize,
                Position = new Vector2f(0, 0)
            };
            text.Scale = new Vector2f(0.5f, 0.5f);
        }

        public TextBox() : base()
        {
            // do nothing
        }

        public override Entity Copy()
        {
            TextBox copy = (TextBox) MemberwiseClone();
            copy.Position = new Vector(Position.X, Position.Y);
            copy.Size = new Vector(Size.X, Size.Y);
            if (Interactable)
            {
                copy.InteractPoint = new Vector(InteractPoint.X, InteractPoint.Y);
                copy.InteractAction = InteractAction;
            }
            copy.text = new Text()
            {
                Font = text.Font,
                CharacterSize = text.CharacterSize,
                Position = text.Position,
                Color = text.Color,
            };
            copy.text.Scale = new Vector2f(0.5f, 0.5f);
            return copy;
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
            Position = pos;
            text.Position = new Vector2f(Position.X, Position.Y);
        }
    }
}
