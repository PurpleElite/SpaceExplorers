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
        string displayText;
        int displayIncrement;
        int stepCount;
        int soundCooldown;
        bool displayDone = true;
        bool speedUp = false;
        List<char> pauseChars = new List<char> { '!', '?', '.', ':' };
        List<char> slowChars = new List<char> { ',', ';' };
        List<char> skipChars = new List<char> { '(', ')', '\'', '\n', '\r', '"' };

        // --Constructors--
        public MenuDialogue(string ID, Vector size, string textureKey) : base(ID, size, textureKey)
        {
            textDisplay = new TextBox(ID + "TextBoxDisplay", new Vector(245, 35), FontLibrary.Fonts["codersCrux"], 32);
            textDisplay.SetColor(74, 193, 255, 255);
            textDisplay.SetZLevel(ZLevel + 1);
            textName = new TextBox(ID + "TextBoxName", new Vector(63, 8), FontLibrary.Fonts["small"], 16);
            textName.SetColor(74, 193, 255, 255);
            textName.SetZLevel(ZLevel + 1);
        }

        public MenuDialogue() : base() {}

        // --Public Methods--
        public override Entity Copy()
        {
            MenuDialogue copy = (MenuDialogue)base.Copy();
            copy.textDisplay = (TextBox)textDisplay.Copy();
            copy.textName = (TextBox)textName.Copy();
            return copy;
        }

        public void Initialize()
        {
            Program.ActiveHud.EntityList.Add(textDisplay);
            Program.ActiveHud.EntityList.Add(textName);
        }

        public override void Step()
        {
            base.Step();
            if (displayDone)
                return;
            if (stepCount <= 0)
            {
                if (displayIncrement >= displayText.Length)
                {
                    displayDone = true;
                    Program.DialogueEngine.DisplayFinished();
                }
                else
                {
                    char currentChar = displayText[displayIncrement];
                    if (skipChars.Any(item => item == currentChar))
                    {
                        displayIncrement++;
                        Step();
                        return;
                    }
                    if (speedUp)
                    {
                        stepCount = 0;
                        displayIncrement++;
                    }
                    else if (pauseChars.Any(item => item == currentChar))
                        stepCount = 16;
                    else if (slowChars.Any(item => item == currentChar))
                        stepCount = 8;
                    else if (currentChar == ' ')
                        stepCount = 5;
                    else
                        stepCount = 2;
                    displayIncrement++;

                    if (soundCooldown <= 0)
                    {
                        Program.QueueSound("speechBlip6");
                        if (speedUp)
                            soundCooldown = 3;
                        else
                            soundCooldown = 4;
                    }
                }
                textDisplay.SetText(displayText.Substring(0, displayIncrement));
            }
            stepCount--;
            soundCooldown--;
        }

        internal void Display(DialogueLine line)
        {
            displayDone = false;
            soundCooldown = 0;
            stepCount = 0;
            displayIncrement = 0;
            displayText = Utility.WrapText(line.Text, 44);
            displayText = displayText.Replace("\r", "");
            if (line.Speaker != null)
            {
                textName.SetText(line.Speaker.Name);
            }
        }

        public override void Destroy()
        {
            textDisplay.Destroy();
            textName.Destroy();
            base.Destroy();
        }

        public override void SetPosition(Vector position)
        {
            textDisplay.SetPosition(new Vector(position.X + 2, position.Y + 7));
            textName.SetPosition(new Vector(position.X + 1, position.Y + 3));
            base.SetPosition(position);
        }

        public override void SetZLevel(int z)
        {
            textDisplay.SetZLevel(z + 1);
            textName.SetZLevel(z + 1);
            base.SetZLevel(z);
        }

        public void WipeText()
        {
            textDisplay.SetText("");
            textName.SetText("");
        }

        public void Up_Pressed() {  }

        public void Down_Pressed() {  }

        public void Left_Pressed() {  }

        public void Right_Pressed() {  }

        public void Up_Released() {  }

        public void Down_Released() {  }

        public void Left_Released() {  }

        public void Right_Released() {  }

        public void Use_Pressed()
        {
            if (displayDone && _stepCountMask <= 0 && _stepCountMove <= 0)
                Program.DialogueEngine.Forward();
            else
                speedUp = true;
        }

        public void Use_Released()
        {
            speedUp = false;
        }
    }
}
