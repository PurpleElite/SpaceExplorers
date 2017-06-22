using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceExplorers
{
    class MenuDialogue : HudEntity, IControllable
    {
        TextBox text;

        // --Constructors--
        public MenuDialogue(string ID, Vector position, int[] size, string textureKey) : base(ID, position, size, textureKey)
        {
            text = new TextBox(ID + "TextBox", position, new int[] { 290, 40 }, FontLibrary.Fonts["VCROSDMono"], 21);
            text.SetColor(74, 193, 255, 255);
            text.SetZLevel(ZLevel + 1);
            Program.ActiveHud.entityList.Add(text);
        }

        public MenuDialogue() : base()
        {
            // do nothing
        }

        // --Public Methods--
        public override void Step()
        {

        }

        internal void Display(DialogueLine line)
        {
            text.SetText(line.text);
            text.SetPosition(new Vector(position.X + 10, position.Y + 55));
        }

        public void Up_Pressed() {  }

        public void Down_Pressed() {  }

        public void Left_Pressed() {  }

        internal void Destroy()
        {
            throw new NotImplementedException();
        }

        public void Right_Pressed() {  }

        public void Up_Released() {  }

        public void Down_Released() {  }

        public void Left_Released() {  }

        public void Right_Released() {  }

        public void Use_Pressed() { Program.DialogueEngine.Forward(); }

        public void Use_Released()
        {
            // Do nothing
        }
    }
}
