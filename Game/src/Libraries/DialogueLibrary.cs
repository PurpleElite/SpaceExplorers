using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceExplorers
{
    static class DialogueLibrary
    {
        public struct DialogueKey
        {
            public string initiator;
            public string target;

            public DialogueKey(Entity initiator, Entity target)
            {
                this.initiator = initiator.GetID();
                this.target = target.GetID();
            }

            public DialogueKey(string initiator, string target)
            {
                this.initiator = initiator;
                this.target = target;
            }
        }

        public static Dictionary<DialogueKey, Dialogue> Dialogues = new Dictionary<DialogueKey, Dialogue>();

        public static void Initialize()
        {
            Dialogue test = new Dialogue(new DialogueKey ("Jacob", "JBreech"));
            test.Lines.Add(new DialogueLine(0, "Test1", false, false, (Actor)EntityLibrary.Entities["Jacob"]));
            test.Lines.Add(new DialogueLine(1, "Test2", false, false, (Actor)EntityLibrary.Entities["JBreech"]));
            test.Lines.Add(new DialogueLine(2, "Test3", false, true, null));
            Dialogues.Add(test.ID, test);
        }
    }
}
