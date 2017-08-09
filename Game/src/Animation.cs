using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceExplorers
{
    public class Animation
    {
        public class Frame
        {
            public string TextureKey;
            public int StepDuration;

            public Frame(string textureKey, int stepDuration)
            {
                TextureKey = textureKey;
                StepDuration = stepDuration;
            }
        }

        public List<Frame> Frames;
        public string ID;
        public int CurrentIndex;
        public AnimType Type { get; }
        int _stepCount;

        public Animation(string ID, AnimType type)
        {
            this.ID = ID;
            Type = type;
            Frames = new List<Frame>();
            CurrentIndex = 0;
            _stepCount = 0;
        }

        public string Step()
        {
            if (_stepCount >= Frames[CurrentIndex].StepDuration)
            {
                _stepCount = 0;
                CurrentIndex++;
                if (CurrentIndex >= Frames.Count)
                {
                    CurrentIndex = 0;
                }
            }
            _stepCount++;
            return Frames[CurrentIndex].TextureKey;
        }

        internal Animation Copy()
        {
            return (Animation)MemberwiseClone();
        }
    }
}
