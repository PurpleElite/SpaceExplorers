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
            var line2 = new DialogueLine("You can hold down E to speed up dialogue.", (Actor)EntityLibrary.Entities["JBreech"]);
            aHavishamJBreech.Events.Add(new Scenes.EventDialogue(line2));
            var line3 = new DialogueLine("Here you can choose a dialogue options from the box using W and S, then use E to select.", null);
            aHavishamJBreech.Events.Add(new Scenes.EventDialogue(line3, false));

            Scene branch1 = new Scene("AHavishamJBreechDialogueBranch1");
            branch1.Events.Add(new Scenes.EventDialogue(new DialogueLine("I'm going to stop you right there.", (Actor)EntityLibrary.Entities["AHavisham"])));
            Scenes.DialogueChoice choice1 = new Scenes.DialogueChoice("Stop.", branch1);

            Scene branch2 = new Scene("AHavishamJBreechDialogueBranch2");
            branch2.Events.Add(new Scenes.EventDialogue(new DialogueLine("This is a test option.", (Actor)EntityLibrary.Entities["AHavisham"])));
            branch2.Events.Add(new Scenes.EventDialogue(new DialogueLine("It tests multiple lines of short dialogue.", (Actor)EntityLibrary.Entities["AHavisham"])));
            Scenes.DialogueChoice choice2 = new Scenes.DialogueChoice("TempChoice", branch2);

            Scene branch3 = new Scene("AHavishamJBreechDialogueBranch3");
            Scenes.DialogueChoice choice3 = new Scenes.DialogueChoice("...", branch3);

            aHavishamJBreech.Events.Add(new Scenes.EventDialogueChoice(new List<Scenes.DialogueChoice>(){choice1, choice2, choice3}));

            var line4 = new DialogueLine("I am now going to test a long block of text to make sure it's properly broken into multiple lines", null);
            branch3.Events.Add(new Scenes.EventDialogue(line4, false));

            Scene branch5 = new Scene("AHavishamJBreechDialogueBranch5");
            var line5 = new DialogueLine("one two three four five six seven eight nine ten eleven twelve thirteen fourteen fifteen sixteen" +
                "seventeen eighteen nineteen twenty twentyone twentytwo twentythree twentyfour twentyfive twentysix twentyseven twentyeight" +
                "twentynine thirty thirtyone thirtytwo thirtythree thirtyfour thirtyfive thirtysix thirtyseven thirtyeight thirtynine 40 41" +
                "42 43 44 45 46 47 48 49 50 51 52 53 54 55 56 57 58 59 60 61 62 63 64 65 66 67 68 69 70 71 72 73 74 75 76 77 78 79 80" +
                "81 82 83 84 85 86 87 88 89 90 91 92 93 94 95 96 97 98 99 One Hundred", null);
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
