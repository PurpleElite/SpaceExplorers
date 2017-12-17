using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceExplorers.Scenes
{
    class EventRemoveDialogue : ISceneEvent
    {
        MenuDialogue _dialogueBox;
        HudEntity _dialoguePortraitBack;
        HudEntity _dialoguePortrait;

        private int _popupTime = 8;
        private int _slideTime = 15;

        public SceneEventReturn Execute(Scene parent)
        {
            foreach (Entity HudEnt in Program.ActiveHud.EntityList)
            {
                if (HudEnt.ID == "DialoguePortraitBack")
                {
                    _dialoguePortraitBack = (HudEntity)HudEnt;
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
            _dialoguePortrait.Destroy();
            _dialogueBox.WipeText();
            _dialogueBox.TransformMask(new SFML.Graphics.FloatRect(270, 0, 0, 56), _slideTime);
            _dialogueBox.TransformMove(new Vector(262, 200), _slideTime);
            _dialogueBox.CreateTimer(delegate { _dialogueBox.TransformMove(new Vector(262, 270), _popupTime); }, _slideTime);
            _dialogueBox.CreateTimer(_dialogueBox.Destroy, _slideTime + _popupTime);
            _dialogueBox.CreateTimer(Program.Controller.Return_Control, _slideTime + _popupTime);
            _dialogueBox.CreateTimer(parent.Continue, _slideTime + _popupTime);
            _dialoguePortraitBack.TransformMove(new Vector(214, 200), _slideTime);
            _dialoguePortraitBack.CreateTimer(delegate { _dialoguePortraitBack.TransformMove(new Vector(214, 270), _popupTime); }, _slideTime);
            _dialoguePortraitBack.CreateTimer(_dialoguePortraitBack.Destroy, _slideTime + _popupTime);

            SceneEventReturn ret = new SceneEventReturn(true);
            return ret;
        }

        public ISceneEvent Copy()
        {
            return this;
        }
    }
}
