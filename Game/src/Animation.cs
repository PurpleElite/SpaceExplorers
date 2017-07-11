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
        int _currentIndex;
        int _stepCount;

        public Animation(string ID)
        {
            this.ID = ID;
            Frames = new List<Frame>();
            _currentIndex = 0;
            _stepCount = 0;
        }

        public string Step()
        {
            if (_stepCount >= Frames[_currentIndex].StepDuration)
            {
                _stepCount = 0;
                _currentIndex++;
                if (_currentIndex >= Frames.Count)
                {
                    _currentIndex = 0;
                }
            }
            _stepCount++;
            return Frames[_currentIndex].TextureKey;
        }

        internal Animation Copy()
        {
            return (Animation)MemberwiseClone();
        }
    }
}
