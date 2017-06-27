using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceExplorers
{
    static public class Utility
    {
        static public string WrapText(string text, int charLimit)
        {
            string[] words = text.Split(' ');

            StringBuilder newText = new StringBuilder();


            string line = "";
            foreach (string word in words)
            {
                if ((line + word).Length > charLimit)
                {
                    newText.AppendLine(line);
                    line = "";
                }

                line += string.Format("{0} ", word);
            }

            if (line.Length > 0)
                newText.AppendLine(line);
            return newText.ToString();
        }
    }
}
