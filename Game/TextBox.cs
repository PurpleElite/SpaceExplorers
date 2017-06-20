using System;
using SFML.Graphics;
using SFML.Window;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        }

        public TextBox() : base()
        {
            // do nothing
        }

        public void SetText(string newText)
        {
            text.DisplayedString = newText;
        }

        public override void SetPosition(Vector pos)
        {
            position = pos;
            text.Position = new Vector2f(position.X, position.Y);
        }
    }
}
