using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceExplorers
{
    class Dialogue
    {
        public struct DialogueLine
        {
            public string text;
            public bool choice;
            public bool end;

            public DialogueLine(string text, bool choice, bool end)
            {
                this.text = text;
                this.choice = choice;
                this.end = end;
            }
        }

        int index;
        List<DialogueLine> dialogue = new List<DialogueLine>();

        internal void initialize()
        {
            index = 0;
        }

        internal DialogueLine NextLine()
        {
            DialogueLine line = dialogue[index];
            index++;
            return line;
        }
    }
}
