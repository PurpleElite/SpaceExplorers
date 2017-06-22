using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceExplorers
{
    public struct DialogueLine
    {
        public int index;
        public string text;
        public bool choice;
        public bool end;

        public DialogueLine(int index, string text, bool choice, bool end)
        {
            this.index = index;
            this.text = text;
            this.choice = choice;
            this.end = end;
        }
    }

    class Dialogue
    {
        int index;
        public List<DialogueLine> Lines = new List<DialogueLine>();
        public DialogueLibrary.DialogueKey ID;

        public Dialogue(DialogueLibrary.DialogueKey ID)
        {
            this.ID = ID;
        }

        internal void Initialize()
        {
            index = 0;
            Lines = Lines.OrderBy(DialogueLine => DialogueLine.index).ToList();
        }

        internal DialogueLine NextLine()
        {
            DialogueLine line = Lines[index];
            index++;
            return line;
        }
    }
}
