using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceExplorers
{
    static class SceneLibrary
    {
        public static Dictionary<string, Scene> Scenes = new Dictionary<string, Scene>();

        public static void Initialize()
        {
            Scene aHavishamJBreech = new Scene("AHavishamJBreechDialogue");
            var line1 = new DialogueLine("Hey debug stand in guy how you doin?  You're looking a little animated there.", (Actor)EntityLibrary.Entities["AHavisham"]);
            aHavishamJBreech.Events.Add(new Scenes.EventDialogue(line1));
            var line2 = new DialogueLine("What the fuck did you just fucking say about me, you little bitch?", (Actor)EntityLibrary.Entities["JBreech"]);
            aHavishamJBreech.Events.Add(new Scenes.EventDialogue(line2));
            var line3 = new DialogueLine("I’ll have you know I graduated top of my class in the Navy Seals", null);
            aHavishamJBreech.Events.Add(new Scenes.EventDialogue(line3, false));

            Scene branch1 = new Scene("AHavishamJBreechDialogueBranch1");
            branch1.Events.Add(new Scenes.EventDialogue(new DialogueLine("I'm going to stop you right there.", (Actor)EntityLibrary.Entities["AHavisham"])));
            Scenes.DialogueChoice choice1 = new Scenes.DialogueChoice("Stop.", branch1);

            Scene branch2 = new Scene("AHavishamJBreechDialogueBranch2");
            branch2.Events.Add(new Scenes.EventDialogue(new DialogueLine("What.", (Actor)EntityLibrary.Entities["AHavisham"])));
            branch2.Events.Add(new Scenes.EventDialogue(new DialogueLine("The fuck did you just fucking say about me, you little bitch?", (Actor)EntityLibrary.Entities["AHavisham"])));
            Scenes.DialogueChoice choice2 = new Scenes.DialogueChoice("What.", branch2);

            Scene branch3 = new Scene("AHavishamJBreechDialogueBranch3");
            Scenes.DialogueChoice choice3 = new Scenes.DialogueChoice("...", branch3);

            aHavishamJBreech.Events.Add(new Scenes.EventDialogueChoice(new List<Scenes.DialogueChoice>(){choice1, choice2, choice3}));

            var line4 = new DialogueLine("and I’ve been involved in numerous secret raids on Al-Quaeda, and I have over 300 confirmed kills.", null);
            branch3.Events.Add(new Scenes.EventDialogue(line4, false));

            Scene branch5 = new Scene("AHavishamJBreechDialogueBranch5");
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
                "fury all over you and you will drown in it. You’re fucking dead, kiddo.", null);
            branch5.Events.Add(new Scenes.EventDialogue(line5, false));
            Scenes.DialogueChoice choice5 = new Scenes.DialogueChoice("...", branch5);

            branch3.Events.Add(new Scenes.EventDialogueChoice(new List<Scenes.DialogueChoice>() { choice1, choice2, choice5 }));

            Scene branch6 = new Scene("AHavishamJBreechDialogueBranch6");
            var line16 = new DialogueLine("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH", (Actor)EntityLibrary.Entities["AHavisham"]);
            branch6.Events.Add(new Scenes.EventDialogue(line16));
            Scenes.DialogueChoice choice6 = new Scenes.DialogueChoice("[Scream]", branch6);

            Scene branch7 = new Scene("AHavishamJBreechDialoguebranch7");
            var line17 = new DialogueLine("Nice, keep it up.", (Actor)EntityLibrary.Entities["AHavisham"]);
            branch7.Events.Add(new Scenes.EventDialogue(line17));
            Scenes.DialogueChoice choice7 = new Scenes.DialogueChoice("Nice, keep it up.", branch7);

            branch5.Events.Add(new Scenes.EventDialogueChoice(new List<Scenes.DialogueChoice>() { choice6, choice7 }));

            aHavishamJBreech.Events.Add(new Scenes.EventRemoveDialogue());
            Scenes.Add(aHavishamJBreech.ID, aHavishamJBreech);



            //var EGottfried1 = new DialogueLine("Gottfried.", (Actor)EntityLibrary.Entities["AHavisham"], "", Actor.PortraitType.glare);
            //var EGottfried2 = new DialogueLine("GID lapdog.  What do you want?", (Actor)EntityLibrary.Entities["EGottfried"], "", Actor.PortraitType.glare);
        }
    }
}
