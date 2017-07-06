using System;
using System.Collections.Generic;
using SFML.Audio;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceExplorers
{
    static public class SoundLibrary
    {
        public static Dictionary<string, Sound> Sounds = new Dictionary<string, Sound>();

        public static void Initialize()
        {
            Sound speechBlip = new Sound(new SoundBuffer("Sound\\Speech.wav"));
            Sounds.Add("speechBlip", speechBlip);
            Sound speechBlip2 = new Sound(new SoundBuffer("Sound\\Speech2.wav"));
            Sounds.Add("speechBlip2", speechBlip2);
            Sound speechBlip3 = new Sound(new SoundBuffer("Sound\\Speech3.wav"));
            Sounds.Add("speechBlip3", speechBlip3);
            Sound speechBlip4 = new Sound(new SoundBuffer("Sound\\Speech4.wav"));
            Sounds.Add("speechBlip4", speechBlip4);
            Sound speechBlip5 = new Sound(new SoundBuffer("Sound\\Speech5.wav"));
            Sounds.Add("speechBlip5", speechBlip5);
            Sound speechBlip6 = new Sound(new SoundBuffer("Sound\\Speech6.wav"));
            speechBlip6.Volume = 50F;
            Sounds.Add("speechBlip6", speechBlip6);
        }
    }
}
