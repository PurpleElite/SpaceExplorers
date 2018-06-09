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

        public class AnimationSegment
        {
            public List<Frame> Frames = new List<Frame>();
            public int CurrentIndex;
            public readonly bool Loop;
            public int _stepCount;

            public AnimationSegment(bool loop)
            {
                CurrentIndex = 0;
                _stepCount = 0;
                Loop = loop;
            }

            public string Step()
            {
                if (_stepCount >= Frames[CurrentIndex].StepDuration)
                {
                    _stepCount = 0;
                    CurrentIndex++;
                    if (CurrentIndex >= Frames.Count && Loop)
                    {
                        CurrentIndex = 0;
                    }
                }
                _stepCount++;
                return CurrentIndex < Frames.Count ? Frames[CurrentIndex].TextureKey : null;
            }

            public string GetFrame()
            {
                return Frames[CurrentIndex].TextureKey;
            }

            internal AnimationSegment Copy()
            {
                return (AnimationSegment)MemberwiseClone();
            }
        }

        
        public string ID;
        public AnimType Type { get; }
        public List<AnimationSegment> Segments;
        public int CurrentIndex { get; set; }
        public int StepCount { get; private set; }
        public Action Callback;
        bool _pause;

        public Animation(string ID, AnimType type)
        {
            this.ID = ID;
            Type = type;
            Segments = new List<AnimationSegment>();
            CurrentIndex = 0;
            StepCount = 0;
            Callback = () => { };
            _pause = false;
        }

        public string Step()
        {
            if (_pause)
            {
                return GetFrame();
            }
            StepCount++;
            if (CurrentIndex >= Segments.Count)
            {
                Callback.Invoke();
                Callback = () => { };
                return null;
            }
            string ret = Segments[CurrentIndex].Step();
            if (ret == null)
            {
                CurrentIndex++;
                return Step();
            }
            return ret;
        }

        public string GetFrame()
        {
            return Segments[CurrentIndex].GetFrame();
        }

        public void SkipFrames(int skipCount)
        {
            for (int i = 0; i < skipCount; i++)
            {
                Step();
            }
        }


        public Animation Copy()
        {
            Animation copyAnim = (Animation)MemberwiseClone();
            copyAnim.Segments = new List<AnimationSegment>();
            foreach (AnimationSegment segment in Segments)
            {
                copyAnim.Segments.Add(segment.Copy());
            }
            return copyAnim;
        }
    }
}
