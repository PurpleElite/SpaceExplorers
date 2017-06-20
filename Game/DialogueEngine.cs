using System;

namespace SpaceExplorers
{
    class DialogueEngine
    {
        Dialogue dialogue;
        MenuDialogue dialogueBox;

        public void RunDialogue(Entity player, Entity npc)
        {
            Console.WriteLine("RunDialogue");
            dialogueBox = (MenuDialogue)EntityLibrary.Entities["DialogueBox"];
            Program.ActiveHud.entityList.Add(dialogueBox);
            Program.controller.Set_Control(dialogueBox);
            dialogue = DialogueLibrary.Dialogues[new DialogueLibrary.DialogueKey(player, npc)];
            dialogue.initialize();
            Forward();
        }

        public void Forward()
        {
            Console.WriteLine("Forward");
            Dialogue.DialogueLine line = dialogue.NextLine();
            if (!line.end)
            {
                dialogueBox.display(line);
            }
        }
    }
}