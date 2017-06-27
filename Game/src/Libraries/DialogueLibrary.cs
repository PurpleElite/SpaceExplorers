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
            test.Lines.Add(new DialogueLine(0, "Hey debug stand in guy how you doin?  You're looking a little unanimated there.", false, false, (Actor)EntityLibrary.Entities["Jacob"]));
            test.Lines.Add(new DialogueLine(1, "What the fuck did you just fucking say about me, you little bitch?", false, false, (Actor)EntityLibrary.Entities["JBreech"]));
            test.Lines.Add(new DialogueLine(2, "I’ll have you know I graduated top of my class in the Navy Seals", false, false, null));
            test.Lines.Add(new DialogueLine(3, "and I’ve been involved in numerous secret raids on Al-Quaeda, and I have over 300 confirmed kills.", false, false, null));
            test.Lines.Add(new DialogueLine(4, "I am trained in gorilla warfare and I’m the top sniper in the entire US armed forces. You are nothing to me but just another target.", false, false, null));
            test.Lines.Add(new DialogueLine(5, "I will wipe you the fuck out with precision the likes of which has never been seen before on this Earth, mark my fucking words.", false, false, null));
            test.Lines.Add(new DialogueLine(6, "You think you can get away with saying that shit to me over the Internet? Think again, fucker.", false, false, null));
            test.Lines.Add(new DialogueLine(7, "As we speak I am contacting my secret network of spies across the USA and your IP is being traced right now so you better prepare for the storm, maggot.", false, false, null));
            test.Lines.Add(new DialogueLine(8, "The storm that wipes out the pathetic little thing you call your life. You’re fucking dead, kid.", false, false, null));
            test.Lines.Add(new DialogueLine(9, "I can be anywhere, anytime, and I can kill you in over seven hundred ways, and that’s just with my bare hands.", false, false, null));
            test.Lines.Add(new DialogueLine(10, "Not only am I extensively trained in unarmed combat, but I have access to the entire arsenal of the United States Marine Corps", false, false, null));
            test.Lines.Add(new DialogueLine(11, "and I will use it to its full extent to wipe your miserable ass off the face of the continent, you little shit.", false, false, null));
            test.Lines.Add(new DialogueLine(12, "If only you could have known what unholy retribution your little “clever” comment was about to bring down upon you, maybe you would have held your fucking tongue.", false, false, null));
            test.Lines.Add(new DialogueLine(13, "But you couldn’t, you didn’t, and now you’re paying the price, you goddamn idiot. I will shit fury all over you and you will drown in it.", false, false, null));
            test.Lines.Add(new DialogueLine(14, "You’re fucking dead, kiddo.", false, false, null));
            test.Lines.Add(new DialogueLine(15, "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH", false, true, (Actor)EntityLibrary.Entities["Jacob"]));
            Dialogues.Add(test.ID, test);
        }
    }
}
