using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceExplorers
{
    class MenuDialogue : HudEntity, IControllable
    {
        private Action _callback;
        private TextBox _textDisplay;
        private TextBox _textName;
        private string _displayText;
        private List<string> _textBlocks = new List<string>();
        private int _blockIncrement;
        private int _displayIncrement;
        private int _stepCount;
        private int _soundCooldown;
        private bool _displayDone = true;
        private bool _speedUp = false;
        private List<char> _pauseChars = new List<char> { '!', '?', '.', ':' };
        private List<char> _slowChars = new List<char> { ',', ';' };
        private List<char> _skipChars = new List<char> { '(', ')', '\'', '\n', '\r', '"' };

        // --Constructors--
        public MenuDialogue(string ID, Vector size, string textureKey) : base(ID, size, textureKey)
        {
            _textDisplay = new TextBox(ID + "TextBoxDisplay", new Vector(245, 35), FontLibrary.Fonts["codersCrux"], 32);
            _textDisplay.SetColor(74, 193, 255, 255);
            _textDisplay.SetZLevel(ZLevel + 1);
            _textName = new TextBox(ID + "TextBoxName", new Vector(63, 8), FontLibrary.Fonts["small"], 16);
            _textName.SetColor(74, 193, 255, 255);
            _textName.SetZLevel(ZLevel + 1);
        }

        public MenuDialogue() : base() {}

        // --Public Methods--
        public override Entity Copy()
        {
            MenuDialogue copy = (MenuDialogue)base.Copy();
            copy._textDisplay = (TextBox)_textDisplay.Copy();
            copy._textName = (TextBox)_textName.Copy();
            return copy;
        }

        public void Initialize()
        {
            Program.ActiveHud.EntityList.Add(_textDisplay);
            Program.ActiveHud.EntityList.Add(_textName);
        }

        public override void Step()
        {
            base.Step();
            if (_displayDone)
                return;
            if (_stepCount <= 0)
            {
                if (_displayIncrement >= _displayText.Length)
                {
                    _displayDone = true;
                    /*if (_blockIncrement == _textBlocks.Count - 1)
                    {
                        Program.DialogueEngine.DisplayFinished();
                    }*/
                }
                else
                {
                    char currentChar = _displayText[_displayIncrement];
                    if (_skipChars.Contains(currentChar))
                    {
                        _displayIncrement++;
                        Step();
                        return;
                    }
                    if (_speedUp)
                    {
                        _stepCount = 0;
                        _displayIncrement++;
                    }
                    else if (_pauseChars.Any(item => item == currentChar))
                        _stepCount = 16;
                    else if (_slowChars.Any(item => item == currentChar))
                        _stepCount = 8;
                    else if (currentChar == ' ')
                        _stepCount = 5;
                    else
                        _stepCount = 2;
                    _displayIncrement++;

                    if (_soundCooldown <= 0)
                    {
                        Program.QueueSound("speechBlip6");
                        if (_speedUp)
                            _soundCooldown = 3;
                        else
                            _soundCooldown = 4;
                    }
                }
                _textDisplay.SetText(_displayText.Substring(0, _displayIncrement));
            }
            _stepCount--;
            _soundCooldown--;
        }

        /// <summary>
        /// Display the given line of dialogue.
        /// </summary>
        /// <param name="line"></param>
        internal void Display(DialogueLine line, Action callback)
        {
            _callback = callback;
            //Set all variables to default values
            _blockIncrement = 0;
            _displayDone = false;
            _soundCooldown = 0;
            _stepCount = 0;
            _displayIncrement = 0;
            //Break the text up into blocks of wrapped text. Each block will be displayed seperately.
            _textBlocks = Utility.WrapTextBlocks(line.Text, 44, 4);
            //Set the first block to be displayed while removing unecessary carriage returns added by the text wrapping method
            _displayText = _textBlocks[_blockIncrement].Replace("\r", "");

            if (line.Speaker != null)
            {
                _textName.SetText(line.Speaker.Name);
            }
        }

        public override void Destroy()
        {
            _textDisplay.Destroy();
            _textName.Destroy();
            base.Destroy();
        }

        public override void SetPosition(Vector position)
        {
            _textDisplay.SetPosition(new Vector(position.X + 2, position.Y + 7));
            _textName.SetPosition(new Vector(position.X + 1, position.Y + 3));
            base.SetPosition(position);
        }

        public override void SetZLevel(int z)
        {
            _textDisplay.SetZLevel(z + 1);
            _textName.SetZLevel(z + 1);
            base.SetZLevel(z);
        }

        public void WipeText()
        {
            _textDisplay.SetText("");
            _textName.SetText("");
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
            //check to see if current block is done, if not speed up text display
            if (_displayDone && _stepCountMask <= 0 && _stepCountMove <= 0)
            {
                _blockIncrement++;
                //check to see if we've finished displaying all blocks
                if (_blockIncrement >= _textBlocks.Count)
                {
                    _callback.Invoke();
                }
                else
                {
                    _displayDone = false;
                    _soundCooldown = 0;
                    _stepCount = 0;
                    _displayIncrement = 0;
                    _displayText = _textBlocks[_blockIncrement].Replace("\r", ""); ;
                }
            }
            else
            {
                _speedUp = true;
            }
        }

        public void Use_Released()
        {
            _speedUp = false;
        }
    }
}
