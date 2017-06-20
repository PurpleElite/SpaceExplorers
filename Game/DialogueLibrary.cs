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
            public Entity initiator;
            public Entity target;

            public DialogueKey(Entity initiator, Entity target)
            {
                this.initiator = initiator;
                this.target = target;
            }
        }

        public static Dictionary<DialogueKey, Dialogue> Dialogues = new Dictionary<DialogueKey, Dialogue>();

        public static void Initialize()
        {

        }
    }
}
