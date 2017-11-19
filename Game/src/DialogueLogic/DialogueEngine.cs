using System;
using System.Collections.Generic;

namespace SpaceExplorers
{
    class DialogueEngine
    {
        MenuDialogue _dialogueBox;
        HudEntity _dialoguePortraitBack;
        HudEntity _dialoguePortrait;
        DialogueLine _currentLine;
        bool _done;

        private int _popupTime = 8;
        private int _slideTime = 15;

        public DialogueEngine()
        {
            // WIP
        }

        /// <summary>
        /// Run a dialogue between the player and an npc they're interacting with.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="npc"></param>
        public void RunDialogue(Actor player, Actor npc)
        {
            // If no dialogue exists between the player and the npc, abort
            _currentLine = DialogueLibrary.Dialogues.GetOrNull(new DialogueLibrary.DialogueKey(player, npc));
            if (_currentLine == null) return;
            // Stop the player's movement
            player.Velocity = new Vector(0, 0);
            // Set it so that the player cant push the dialogue forward until the text is done displaying
            _done = false;
            // Initiliaze the box the character portrait sits in
            _dialoguePortraitBack = (HudEntity)EntityLibrary.Create("DialoguePortraitBack", new Vector(214, 270));
            _dialoguePortraitBack.TransformMove(new Vector(214, 200), _popupTime);
            _dialoguePortraitBack.CreateTimer(delegate { _dialoguePortraitBack.TransformMove(new Vector(81, 200), _slideTime); }, _popupTime);
            _dialoguePortraitBack.SetZLevel(10);
            Program.ActiveHud.AddEntity(_dialoguePortraitBack);
            // Initialize the character portrait
            _dialoguePortrait = new HudEntity("DialoguePortrait", new Vector(40, 40), null);
            _dialoguePortrait.SetZLevel(11);
            Program.ActiveHud.AddEntity(_dialoguePortrait);
            // Initialize the box that houses the dialogue
            _dialogueBox = (MenuDialogue)EntityLibrary.Create("DialogueBox", new Vector(262, 270));
            _dialogueBox.MaskRect = new SFML.Graphics.FloatRect(270, 0, 0, 56);
            _dialogueBox.Initialize();
            _dialogueBox.TransformMove(new Vector(262, 200), _popupTime);
            _dialogueBox.CreateTimer(delegate { _dialogueBox.TransformMove(new Vector(129, 200), _slideTime); }, _popupTime);
            _dialogueBox.CreateTimer(delegate { _dialogueBox.TransformMask(new SFML.Graphics.FloatRect(0, 0, 270, 56), _slideTime); }, _popupTime);
            _dialogueBox.SetZLevel(9);
            Program.ActiveHud.AddEntity(_dialogueBox);
            // Send user input to the dialogue box
            Program.Controller.Set_Control(_dialogueBox);
            // Set a timer for the dialogue box's entry into the screen
            _dialoguePortraitBack.CreateTimer(Forward, _slideTime + _popupTime);

            // Make the actors face eachother
            Vector point1 = player.Position;
            Vector point2 = npc.Position;
            Vector difference = point2 - point1;
            player.SetFacing(difference.GetDirection());
            difference = point1 - point2;
            npc.SetFacing(difference.GetDirection());
        }

        public void Forward()
        {
            if (_done)
            {
                _dialoguePortrait.Destroy();
                _dialogueBox.WipeText();
                _dialogueBox.TransformMask(new SFML.Graphics.FloatRect(270, 0, 0, 56), _slideTime);
                _dialogueBox.TransformMove(new Vector(262, 200), _slideTime);
                _dialogueBox.CreateTimer(delegate { _dialogueBox.TransformMove(new Vector(262, 270), _popupTime); }, _slideTime);
                _dialogueBox.CreateTimer(_dialogueBox.Destroy, _slideTime + _popupTime);
                _dialogueBox.CreateTimer(Program.Controller.Return_Control, _slideTime + _popupTime);
                _dialoguePortraitBack.TransformMove(new Vector(214, 200), _slideTime);
                _dialoguePortraitBack.CreateTimer(delegate { _dialoguePortraitBack.TransformMove(new Vector(214, 270), _popupTime); }, _slideTime);
                _dialoguePortraitBack.CreateTimer(_dialoguePortraitBack.Destroy, _slideTime + _popupTime);
            }
            else
            {
                if (_currentLine.Speaker != null)
                {
                    string portrait;
                    if (_currentLine.Speaker.Portraits.ContainsKey(_currentLine.Portrait))
                    {
                        portrait = _currentLine.Speaker.Portraits[_currentLine.Portrait];
                    }
                    else
                    {
                        portrait = _currentLine.Speaker.Portraits[Actor.PortraitType.normal];
                    }
                    SetPortrait(portrait);
                }
                _dialogueBox.Display(_currentLine);
            }
        }

        public void DisplayFinished()
        {
            if (_currentLine.Choices.Count > 1)
            {
                MenuList choiceList = (MenuList)EntityLibrary.Create("DialogueChoice", new Vector(81, 200));
                choiceList.TransformMove(new Vector(81, 196), 10);
                choiceList.SetZLevel(_dialogueBox.ZLevel - 2);
                for (int i = 0; i < _currentLine.Choices.Count; i++)
                {
                    int j = i;
                    Action choiceAction = () => ChooseNext(j);
                    choiceList.AddOption(new MenuList.ListOption(_currentLine.Choices[i].ChoiceText, choiceAction));
                }
                Program.ActiveHud.AddEntity(choiceList);
                Program.Controller.Set_Control(choiceList);
            }
            else if (_currentLine.Choices.Count == 1)
            {
                _currentLine = _currentLine.Choices[0];
            }
            else if(_currentLine.Choices.Count == 0)
            {
                _done = true;
            }
        }

        public void ChooseNext(int nextIndex)
        {
            _currentLine = _currentLine.Choices[nextIndex];
            Forward();
        }

        private void SetPortrait(string textureKey)
        {
            _dialoguePortrait.SetPosition(_dialoguePortraitBack.Position + new Vector(4, 6));
            _dialoguePortrait.TextureKey = textureKey;
        }
    }
}