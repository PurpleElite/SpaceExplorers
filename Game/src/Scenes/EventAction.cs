using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceExplorers.Scenes
{
    class EventAction : ISceneEvent
    {
        Action _action;

        public EventAction (Action action)
        {
            _action = action;
        }

        public SceneEventReturn Execute(Scene parent)
        {
            _action.Invoke();
            SceneEventReturn ret = new SceneEventReturn(false);
            return ret;
        }
    }
}
