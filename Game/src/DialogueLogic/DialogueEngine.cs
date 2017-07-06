using System;

namespace SpaceExplorers
{
    class DialogueEngine
    {
        MenuDialogue dialogueBox;
        DialogueLine currentLine;

        public DialogueEngine()
        {
            // WIP
        }

        public void RunDialogue(Entity player, Entity npc)
        {
            Console.WriteLine("RunDialogue");
            dialogueBox = (MenuDialogue)EntityLibrary.Create("DialogueBox", new Vector(81, 200));
            dialogueBox.Initialize();
            Program.ActiveHud.AddEntity(dialogueBox);
            Program.controller.Set_Control(dialogueBox);
            currentLine = DialogueLibrary.Dialogues[new DialogueLibrary.DialogueKey(player, npc)];
            dialogueBox.Display(currentLine);
        }

        public void Forward()
        {
            Console.WriteLine("Forward");
            if (currentLine.Choices.Count > 0)
            {
                dialogueBox.Display(currentLine);
            }
            else
            {
                dialogueBox.Destroy();
                Program.controller.Return_Control();
            }
        }

        public void DisplayFinished()
        {
            if (currentLine.Choices.Count > 1)
            {
                MenuList choiceList = (MenuList)EntityLibrary.Create("DialogueChoice", new Vector(81, 196 - 9 * currentLine.Choices.Count));
                choiceList.SetZLevel(dialogueBox.ZLevel - 2);
                for (int i = 0; i < currentLine.Choices.Count; i++)
                {
                    Action choiceAction = () => ChooseNext(i);
                    choiceList.AddOption(new MenuList.ListOption(currentLine.Choices[i].ChoiceText, choiceAction));
                }
                Program.ActiveHud.AddEntity(choiceList);
                Program.controller.Set_Control(choiceList);
            }
            else
            {
                currentLine = currentLine.Choices[0];
            }
        }

        public void ChooseNext(int nextIndex)
        {
            currentLine = currentLine.Choices[nextIndex];
            Forward();
        }
    }
}