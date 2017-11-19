using System;
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
        bool _done;

        private int _popupTime = 8;
        private int _slideTime = 15;

        public EventDialogue(DialogueLine line)
        {
            _line = line;
        }

        /// <summary>
        /// Display a line of dialogue with the given parameters.
        /// </summary>
        public SceneEventReturn Execute(Scene parent)
        {
            _parent = parent;
            // Set it so that the player cant push the dialogue forward until the text is done displaying
            _done = false;
            bool newBox = true;
            // Look for existing dialogue box elements
            foreach (Entity HudEnt in Program.ActiveHud.EntityList)
            {
                if (HudEnt.ID.Substring(0,"DialoguePortraitBack".Length - 1) == "DialoguePortraitBack")
                {
                    _dialoguePortraitBack = (HudEntity)HudEnt;
                    newBox = false;
                }
                if (HudEnt.ID.Substring(0, "DialoguePortrait".Length - 1) == "DialoguePortrait")
                {
                    _dialoguePortrait = (HudEntity)HudEnt;
                }
                if (HudEnt.ID.Substring(0, "DialogueBox".Length - 1) == "DialogueBox")
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
            // Send user input to the dialogue box
            Program.Controller.Set_Control(_dialogueBox);
            if (newBox)
            {
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
            if (_done)
            {
                _parent.Continue();
            }
            else
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
                _dialogueBox.Display(_line);
            }
        }

        private void SetPortrait(string textureKey)
        {
            _dialoguePortrait.SetPosition(_dialoguePortraitBack.Position + new Vector(4, 6));
            _dialoguePortrait.TextureKey = textureKey;
        }
    }
}
