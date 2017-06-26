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
            Font VCROSDMono = new Font("Fonts\\VCR_OSD_MONO_1.001.ttf");
            Fonts.Add("VCROSDMono", VCROSDMono);
            Font codersCrux = new Font("Fonts\\coders_crux.ttf");
            Fonts.Add("codersCrux", codersCrux);
            Font small = new Font("Fonts\\04B_03__.TTF");
            Fonts.Add("small", small);
        }
    }
}
