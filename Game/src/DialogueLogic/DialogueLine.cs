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
        public Actor.PortraitType Portrait = Actor.PortraitType.normal;
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

        public DialogueLine(string text, Actor speaker, string choiceText, Actor.PortraitType portrait)
        {
            Text = text;
            Choices = new List<DialogueLine>();
            Speaker = speaker;
            ChoiceText = choiceText;
            Portrait = portrait;
        }

        public void AddChoice(DialogueLine dialogue)
        {
            Choices.Add(dialogue);
        }
    }
}
