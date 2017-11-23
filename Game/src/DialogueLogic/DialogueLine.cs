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

        public DialogueLine(string text, Actor speaker)
        {
            Text = text;
            Speaker = speaker;
        }

        public DialogueLine(string text, Actor speaker, Actor.PortraitType portrait)
        {
            Text = text;
            Speaker = speaker;
            Portrait = portrait;
        }
    }
}
