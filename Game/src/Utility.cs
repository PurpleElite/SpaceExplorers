﻿using System;
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

        static public List<string> WrapTextBlocks(string text, int charLimit, int lineLimit)
        {
            string[] words = text.Split(' ');

            StringBuilder newText = new StringBuilder();
            List<string> blocks = new List<string>();

            int lineCount = 0;
            string line = "";
            foreach (string word in words)
            {
                if ((line + word).Length > charLimit)
                {
                    newText.AppendLine(line);
                    line = "";
                    lineCount++;
                    if (lineCount >= lineLimit)
                    {
                        blocks.Add(newText.ToString());
                        newText.Clear();
                        lineCount = 0;
                    }
                }

                line += string.Format("{0} ", word);
            }

            if (line.Length > 0)
            {
                newText.AppendLine(line);
                blocks.Add(newText.ToString());
            }
            return blocks;
        }

        public static int ValueWrap(int value, int mod)
        {
            var newValue = value % mod;
            return newValue < 0 ?
                mod + newValue :
                newValue;
        }

        public static bool RectangleIntersect(float x1, float y1, float width1, float height1,
            float x2, float y2, float width2, float height2)
        {
            return x1 < x2 + width2 && x1 + width1 > x2 && y1 < y2 + height2 && y1 + height1 > y2;
        }
    }
}
