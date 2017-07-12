using System;

namespace SpaceExplorers
{
    class DialogueEngine
    {
        MenuDialogue dialogueBox;
        DialogueLine currentLine;
        bool done;

        public DialogueEngine()
        {
            // WIP
        }

        public void RunDialogue(Entity player, Entity npc)
        {
            done = false;
            dialogueBox = (MenuDialogue)EntityLibrary.Create("DialogueBox", new Vector(81, 200));
            dialogueBox.Initialize();
            Program.ActiveHud.AddEntity(dialogueBox);
            Program.Controller.Set_Control(dialogueBox);
            currentLine = DialogueLibrary.Dialogues[new DialogueLibrary.DialogueKey(player, npc)];
            dialogueBox.Display(currentLine);
        }

        public void Forward()
        {
            if (done)
            {
                dialogueBox.Destroy();
                Program.Controller.Return_Control();
            }
            else
            {
                dialogueBox.Display(currentLine);
            }
        }

        public void DisplayFinished()
        {
            if (currentLine.Choices.Count > 1)
            {
                MenuList choiceList = (MenuList)EntityLibrary.Create("DialogueChoice", new Vector(81, 200));
                choiceList.TransformMove(new Vector(81, 196), 10);
                choiceList.SetZLevel(dialogueBox.ZLevel - 2);
                for (int i = 0; i < currentLine.Choices.Count; i++)
                {
                    int j = i;
                    Action choiceAction = () => ChooseNext(j);
                    choiceList.AddOption(new MenuList.ListOption(currentLine.Choices[i].ChoiceText, choiceAction));
                }
                Program.ActiveHud.AddEntity(choiceList);
                Program.Controller.Set_Control(choiceList);
            }
            else if (currentLine.Choices.Count == 1)
            {
                currentLine = currentLine.Choices[0];
            }
            else if(currentLine.Choices.Count == 0)
            {
                done = true;
            }
        }

        public void ChooseNext(int nextIndex)
        {
            currentLine = currentLine.Choices[nextIndex];
            Forward();
        }
    }
}