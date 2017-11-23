using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceExplorers.Scenes
{
    public struct DialogueChoice
    {
        public string Text;
        public Scene Scene;

        public DialogueChoice(string text, Scene scene)
        {
            Text = text;
            Scene = scene;
        }
    }

    class EventDialogueChoice : ISceneEvent
    {
        List<DialogueChoice> _choices;

        public EventDialogueChoice(List<DialogueChoice> choices)
        {
            _choices = choices;
        }

        /// <summary>
        /// Display a list of choices
        /// </summary>
        /// <param name="parent"></param>
        /// <returns></returns>
        public SceneEventReturn Execute(Scene parent)
        {
            int zLevel = 0;
            foreach (Entity HudEnt in Program.ActiveHud.EntityList)
            {
                if (HudEnt.ID == "DialogueBox")
                {
                    zLevel = HudEnt.ZLevel - 2;
                }
            }

            MenuList choiceList = (MenuList)EntityLibrary.Create("DialogueChoice", new Vector(81, 200));
            choiceList.TransformMove(new Vector(81, 196), 10);
            choiceList.SetZLevel(zLevel);
            foreach (var choice in _choices)
            {
                //The Continues stack up over time, so they need to be temporary. Consider making a deep copy before adding in the continue event?
                choice.Scene.Events.Add(new EventAction(() => parent.Continue()));
                Action choiceAction = () => choice.Scene.Run();
                choiceList.AddOption(new MenuList.ListOption(choice.Text, choiceAction));
            }
            Program.ActiveHud.AddEntity(choiceList);
            Program.Controller.Set_Control(choiceList);

            SceneEventReturn ret = new SceneEventReturn(true);
            return ret;
        }
    }
}
