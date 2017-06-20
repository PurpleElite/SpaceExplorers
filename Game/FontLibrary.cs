using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceExplorers
{
    static class FontLibrary
    {
        public static Dictionary<string, Font> Fonts = new Dictionary<string, Font>();

        public static void Initialize()
        {
            Font arial = new Font("Fonts\\ARIAL.TTF");
            Fonts.Add("Arial", arial);
        }
    }
}
