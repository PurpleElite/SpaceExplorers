using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceExplorers.Scenes
{
    class EventPlayAnimation : ISceneEvent
    {
        AnimType _anim;
        bool _pause;

        public EventPlayAnimation(AnimType anim, bool pause)
        {
            _anim = anim;
            _pause = pause;
        }

        public SceneEventReturn Execute(Scene parent)
        {
            return new SceneEventReturn(_pause);
        }
    }
}
