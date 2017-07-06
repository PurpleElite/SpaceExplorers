using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceExplorers
{
    public class DialogueLine
    {
        public Actor Speaker;
        public string Text;
        public List<DialogueLine> Choices;
        public string ChoiceText;

        public DialogueLine(string text, Actor speaker)
        {
            Text = text;
            Choices = new List<DialogueLine>();
            Speaker = speaker;
            ChoiceText = "";
        }

        public DialogueLine(string text, Actor speaker, string choiceText)
        {
            Text = text;
            Choices = new List<DialogueLine>();
            Speaker = speaker;
            ChoiceText = choiceText;
        }

        public void AddChoice(DialogueLine dialogue)
        {
            Choices.Add(dialogue);
        }
    }
}
