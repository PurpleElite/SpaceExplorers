﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceExplorers.Scenes
{
    class EventDialogue : ISceneEvent
    {
        MenuDialogue _dialogueBox;
        HudEntity _dialoguePortraitBack;
        HudEntity _dialoguePortrait;
        DialogueLine _line;
        Scene _parent;
        bool _pauseAfterDisplay;

        private int _popupTime = 8;
        private int _slideTime = 15;

        public EventDialogue(DialogueLine line)
        {
            _line = line;
            _pauseAfterDisplay = true;
        }

        public EventDialogue(DialogueLine line, bool pauseAfterDisplay)
        {
            _line = line;
            _pauseAfterDisplay = pauseAfterDisplay;
        }

        /// <summary>
        /// Display a line of dialogue with the given parameters.
        /// </summary>
        /// <param name="parent"></param>
        /// <returns></returns>
        public SceneEventReturn Execute(Scene parent)
        {
            _parent = parent;
            bool newBox = true;
            _dialogueBox = null;
            _dialoguePortraitBack = null;
            _dialoguePortrait = null;
            // Look for existing dialogue box elements
            foreach (Entity HudEnt in Program.ActiveHud.EntityList)
            {
                if (HudEnt.ID == "DialoguePortraitBack")
                {
                    _dialoguePortraitBack = (HudEntity)HudEnt;
                    newBox = false;
                }
                if (HudEnt.ID == "DialoguePortrait")
                {
                    _dialoguePortrait = (HudEntity)HudEnt;
                }
                if (HudEnt.ID == "DialogueBox")
                {
                    _dialogueBox = (MenuDialogue)HudEnt;
                }
            }
            if (_dialoguePortraitBack == null)
            {
                // Initilize the box the character portrait sits in
                _dialoguePortraitBack = (HudEntity)EntityLibrary.Create("DialoguePortraitBack", new Vector(214, 270));
                _dialoguePortraitBack.TransformMove(new Vector(214, 200), _popupTime);
                _dialoguePortraitBack.CreateTimer(delegate { _dialoguePortraitBack.TransformMove(new Vector(81, 200), _slideTime); }, _popupTime);
                _dialoguePortraitBack.SetZLevel(10);
                Program.ActiveHud.AddEntity(_dialoguePortraitBack);
            }
            if (_dialoguePortrait == null)
            {
                // Initialize the character portrait
                _dialoguePortrait = new HudEntity("DialoguePortrait", new Vector(40, 40), null);
                _dialoguePortrait.SetZLevel(11);
                Program.ActiveHud.AddEntity(_dialoguePortrait);
            }
            if (_dialogueBox == null)
            {
                // Initialize the box that houses the dialogue
                _dialogueBox = (MenuDialogue)EntityLibrary.Create("DialogueBox", new Vector(262, 270));
                _dialogueBox.MaskRect = new SFML.Graphics.FloatRect(270, 0, 0, 56);
                _dialogueBox.Initialize();
                _dialogueBox.TransformMove(new Vector(262, 200), _popupTime);
                _dialogueBox.CreateTimer(delegate { _dialogueBox.TransformMove(new Vector(129, 200), _slideTime); }, _popupTime);
                _dialogueBox.CreateTimer(delegate { _dialogueBox.TransformMask(new SFML.Graphics.FloatRect(0, 0, 270, 56), _slideTime); }, _popupTime);
                _dialogueBox.SetZLevel(9);
                Program.ActiveHud.AddEntity(_dialogueBox);
            }
            if (newBox)
            {
                // Send user input to the dialogue box
                Program.Controller.Set_Control(_dialogueBox);
                // Set a timer for the dialogue box's entry into the screen
                _dialoguePortraitBack.CreateTimer(Display, _slideTime + _popupTime);
            }
            else
            {
                Display();
            }

            SceneEventReturn ret = new SceneEventReturn(true);
            return ret;
        }

        public void Display()
        {
            if (_line.Speaker != null)
            {
                string portrait;
                if (_line.Speaker.Portraits.ContainsKey(_line.Portrait))
                {
                    portrait = _line.Speaker.Portraits[_line.Portrait];
                }
                else
                {
                    portrait = _line.Speaker.Portraits[Actor.PortraitType.normal];
                }
                SetPortrait(portrait);
            }
            Action callback = () => _parent.Continue();
            _dialogueBox.Display(_line, callback, _pauseAfterDisplay);
        }

        private void SetPortrait(string textureKey)
        {
            _dialoguePortrait.SetPosition(_dialoguePortraitBack.Position + new Vector(4, 6));
            _dialoguePortrait.TextureKey = textureKey;
        }

        public ISceneEvent Copy()
        {
            return this;
        }
    }
}
