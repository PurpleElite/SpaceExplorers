using System;

namespace SpaceExplorers
{
    class DialogueEngine
    {
        Dialogue dialogue;
        MenuDialogue dialogueBox;
        DialogueLine currentLine;

        public DialogueEngine()
        {
            // WIP
        }

        public void RunDialogue(Entity player, Entity npc)
        {
            Console.WriteLine("RunDialogue");
            dialogueBox = (MenuDialogue)EntityLibrary.Create("DialogueBox", new Vector(90, 200));
            dialogueBox.Initialize();
            Program.ActiveHud.EntityList.Add(dialogueBox);
            Program.controller.Set_Control(dialogueBox);
            dialogue = DialogueLibrary.Dialogues[new DialogueLibrary.DialogueKey(player, npc)];
            dialogue.Initialize();
            Forward();
        }

        public void Forward()
        {
            Console.WriteLine("Forward");
            if (!currentLine.end)
            {
                currentLine = dialogue.NextLine();
                dialogueBox.Display(currentLine);
            }
            else
            {
                dialogueBox.Destroy();
                Program.controller.Return_Control();
                currentLine = new DialogueLine();
            }
        }
    }
}