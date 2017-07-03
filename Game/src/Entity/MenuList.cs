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
            public Action<int> Action;
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
                selectionBoundary = (HudEntity)EntityLibrary.Create("DialogueSelection", new Vector(0, 0));
            SetPosition(new Vector(Position.X, Position.Y - 9));
            selectionBoundary.SetPosition(new Vector(Position.X + 4, Position.Y + 3 + 9 * SelectionIndex));
            Options.Add(newOption);
            TextBox newText = new TextBox(ID + "Option" + Options.Count, new Vector(162, 9), FontLibrary.Fonts["small"], 16);
            newText.SetColor(74, 193, 255, 255);
            newText.SetZLevel(ZLevel + 1);
            newText.Position = Position + new Vector(4, 4 + 9 * Options.Count);
            TextBoxes.Add(newText);
            Program.ActiveHud.EntityList.Add(newText);
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
                copy.TextBoxes.Add(textBox);
            }
            copy.selectionBoundary =(HudEntity)selectionBoundary.Copy();
            return copy;
        }

        public void Down_Pressed()
        {
            throw new NotImplementedException();
        }

        public void Down_Released()
        {
            throw new NotImplementedException();
        }

        public void Left_Pressed()
        {
            throw new NotImplementedException();
        }

        public void Left_Released()
        {
            throw new NotImplementedException();
        }

        public void Right_Pressed()
        {
            throw new NotImplementedException();
        }

        public void Right_Released()
        {
            throw new NotImplementedException();
        }

        public void Up_Pressed()
        {
            throw new NotImplementedException();
        }

        public void Up_Released()
        {
            throw new NotImplementedException();
        }

        public void Use_Pressed()
        {
            throw new NotImplementedException();
        }

        public void Use_Released()
        {
            throw new NotImplementedException();
        }
    }
}
