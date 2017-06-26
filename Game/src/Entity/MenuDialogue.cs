using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceExplorers
{
    class MenuDialogue : HudEntity, IControllable
    {
        TextBox textDisplay;
        TextBox textName;
        HudEntity portrait;

        // --Constructors--
        public MenuDialogue(string ID, Vector size, string textureKey) : base(ID, size, textureKey)
        {
            textDisplay = new TextBox(ID + "TextBoxDisplay", new Vector(245, 35), FontLibrary.Fonts["codersCrux"], 32);
            textDisplay.SetColor(74, 193, 255, 255);
            textDisplay.SetZLevel(ZLevel + 1);
            textName = new TextBox(ID + "TextBoxName", new Vector(63, 8), FontLibrary.Fonts["small"], 16);
            textName.SetColor(74, 193, 255, 255);
            textName.SetZLevel(ZLevel + 1);
            portrait = new HudEntity(ID + "Portrait", new Vector(40, 40), null);
            portrait.SetZLevel(ZLevel + 1);
        }

        public MenuDialogue() : base() {}

        // --Public Methods--
        public void Initialize()
        {
            Program.ActiveHud.EntityList.Add(textDisplay);
            Program.ActiveHud.EntityList.Add(textName);
            Program.ActiveHud.EntityList.Add(portrait);
        }

        public override void Step()
        {

        }

        internal void Display(DialogueLine line)
        {
            textDisplay.SetText(line.text);
            if (line.speaker != null)
            {
                textName.SetText(line.speaker.Name);
                portrait.textureKey = line.speaker.PortraitKey;
            }
        }

        public override void Destroy()
        {
            textDisplay.Destroy();
            textName.Destroy();
            portrait.Destroy();
            base.Destroy();
        }

        public override void SetPosition(Vector position)
        {
            textDisplay.SetPosition(new Vector(position.X + 50, position.Y + 7));
            textName.SetPosition(new Vector(position.X + 49, position.Y + 3));
            portrait.SetPosition(new Vector(position.X + 4, position.Y + 6));
            base.SetPosition(position);
        }

        public void Up_Pressed() {  }

        public void Down_Pressed() {  }

        public void Left_Pressed() {  }

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
