/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceExplorers
{
    static class DialogueLibrary
    {
        public class DialogueKey : Equ.MemberwiseEquatable<DialogueKey>
        {
            public string Initiator { get; }
            public string Target { get; }

            public DialogueKey(Entity initiator, Entity target)
            {
                Initiator = initiator.GetID();
                Target = target.GetID();
            }

            public DialogueKey(string initiator, string target)
            {
                Initiator = initiator;
                Target = target;
            }
        }

        public static Dictionary<DialogueKey, DialogueLine> Dialogues = new Dictionary<DialogueKey, DialogueLine>();

        public static void Initialize()
        {
            var line1 = new DialogueLine("Hey debug stand in guy how you doin?  You're looking a little animated there.", (Actor)EntityLibrary.Entities["AHavisham"]);
            Dialogues.Add(new DialogueKey("AHavisham", "JBreech"), line1);
            var line2 = new DialogueLine("What the fuck did you just fucking say about me, you little bitch?", (Actor)EntityLibrary.Entities["JBreech"]);
            line1.AddChoice(line2);
            var line3 = new DialogueLine("I’ll have you know I graduated top of my class in the Navy Seals", null);
            line2.AddChoice(line3);
            var line4 = new DialogueLine("and I’ve been involved in numerous secret raids on Al-Quaeda, and I have over 300 confirmed kills.", null, "...");
            line3.AddChoice(line4);
            var line5 = new DialogueLine("I am trained in gorilla warfare and I’m the top sniper in the entire US armed forces. You are nothing " +
                "to me but just another target. I will wipe you the fuck out with precision the likes of which has never been seen before on this " +
                "Earth, mark my fucking words. You think you can get away with saying that shit to me over the Internet? Think again, fucker. " +
                "As we speak I am contacting my secret network of spies across the USA and your IP is being traced right now so you better " +
                "prepare for the storm, maggot. The storm that wipes out the pathetic little thing you call your life. You’re fucking dead, " +
                "kid. I can be anywhere, anytime, and I can kill you in over seven hundred ways, and that’s just with my bare hands. Not only " +
                "am I extensively trained in unarmed combat, but I have access to the entire arsenal of the United States Marine " +
                "Corps and I will use it to its full extent to wipe your miserable ass off the face of the continent, you little shit. If only " +
                "you could have known what unholy retribution your little “clever” comment was about to bring down upon you, maybe you would " +
                "have held your fucking tongue. But you couldn’t, you didn’t, and now you’re paying the price, you goddamn idiot. I will shit " +
                "fury all over you and you will drown in it. You’re fucking dead, kiddo.", null, "...");
            line4.AddChoice(line5);
            var line16 = new DialogueLine("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH", (Actor)EntityLibrary.Entities["AHavisham"], "[Scream]");
            line5.AddChoice(line16);
            var line17 = new DialogueLine("Nice, keep it up.", (Actor)EntityLibrary.Entities["AHavisham"], "Nice, keep it up.");
            line5.AddChoice(line17);
            var line18 = new DialogueLine("I'm going to stop you right there.", (Actor)EntityLibrary.Entities["AHavisham"], "Stop.");
            line3.AddChoice(line18);
            line4.AddChoice(line18);
            line5.AddChoice(line18);
            var line19 = new DialogueLine("What.", (Actor)EntityLibrary.Entities["AHavisham"], "What.");
            line3.AddChoice(line19);
            var line20 = new DialogueLine("The fuck did you just fucking say about me, you little bitch?", (Actor)EntityLibrary.Entities["AHavisham"], "");
            line19.AddChoice(line20);

            var EGottfried1 = new DialogueLine("Gottfried.", (Actor)EntityLibrary.Entities["AHavisham"], "", Actor.PortraitType.glare);
            Dialogues.Add(new DialogueKey("AHavisham", "EGottfried"), EGottfried1);
            var EGottfried2 = new DialogueLine("GID lapdog.  What do you want?", (Actor)EntityLibrary.Entities["EGottfried"], "", Actor.PortraitType.glare);
        }
    }
}*/
