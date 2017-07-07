using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceExplorers
{
    class MenuList : HudEntity, IControllable
    {
        public class ListOption
        {
            public string Text;
            public Action Action;

            public ListOption(string text, Action action)
            {
                Text = text;
                Action = action;
            }
        }

        public List<ListOption> Options;
        public List<TextBox> TextBoxes;
        public int SelectionIndex = 0;
        public HudEntity selectionBoundary;

        public MenuList(string ID, Vector size, string textureKey) : base(ID, size, textureKey)
        {
            Options = new List<ListOption>();
            TextBoxes = new List<TextBox>();
            selectionBoundary = new HudEntity();
        }

        public void AddOption(ListOption newOption)
        {
            if (Options.Count == 0)
            {
                selectionBoundary = (HudEntity)EntityLibrary.Create("DialogueSelection", new Vector(0, 0));
                selectionBoundary.SetZLevel(ZLevel + 1);
                Program.ActiveHud.AddEntity(selectionBoundary);
            }
            SetPosition(new Vector(Position.X, Position.Y - 9));
            selectionBoundary.SetPosition(new Vector(Position.X + 4, Position.Y + 3 + 9 * SelectionIndex));
            TextBox newText = new TextBox(ID + "Option" + Options.Count, new Vector(162, 9), FontLibrary.Fonts["small"], 16);
            newText.SetColor(74, 193, 255, 255);
            newText.SetZLevel(ZLevel + 1);
            newText.SetPosition(new Vector(Position.X + 5, Position.Y + 3 + 9 * Options.Count));
            newText.SetText(newOption.Text);
            TextBoxes.Add(newText);
            newText.SetZLevel(ZLevel + 1);
            Options.Add(newOption);
            Program.ActiveHud.AddEntity(newText);
        }

        public override Entity Copy()
        {
            MenuList copy = (MenuList)base.Copy();
            copy.Options = new List<ListOption>();
            foreach(var option in Options)
            {
                copy.Options.Add(option);
            }
            copy.TextBoxes = new List<TextBox>();
            foreach (var textBox in TextBoxes)
            {
                copy.TextBoxes.Add((TextBox)textBox.Copy());
            }
            copy.selectionBoundary = (HudEntity)selectionBoundary.Copy();
            return copy;
        }

        public override void Destroy()
        {
            selectionBoundary.Destroy();
            foreach (var text in TextBoxes)
            {
                text.Destroy();
            }
            base.Destroy();
        }

        public override void SetPosition(Vector position)
        {
            Vector difference = position - Position;
            foreach (var text in TextBoxes)
            {
                text.SetPosition(text.Position + difference);
            }
            base.SetPosition(position);
        }

        public void Down_Pressed()
        {
            SelectionIndex++;
            if (SelectionIndex >= Options.Count) SelectionIndex = Options.Count - 1;
            selectionBoundary.SetPosition(new Vector(Position.X + 4, Position.Y + 3 + 9 * SelectionIndex));
        }

        public void Down_Released()
        {
        }

        public void Left_Pressed()
        {
        }

        public void Left_Released()
        {
        }

        public void Right_Pressed()
        {
        }

        public void Right_Released()
        {
        }

        public void Up_Pressed()
        {
            SelectionIndex--;
            if (SelectionIndex < 0) SelectionIndex = 0;
            selectionBoundary.SetPosition(new Vector(Position.X + 4, Position.Y + 3 + 9 * SelectionIndex));
        }

        public void Up_Released()
        {
        }

        public void Use_Pressed()
        {
            Destroy();
            Program.Controller.Return_Control();
            Options[SelectionIndex].Action();
        }

        public void Use_Released()
        {
        }
    }
}
