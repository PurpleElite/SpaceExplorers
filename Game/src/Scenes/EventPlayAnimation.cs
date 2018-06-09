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
        string _ID;
        bool _pause;
        Entity _target;
        Scene _parent;

        public EventPlayAnimation(Scene parent, AnimType anim, string ID, bool pause)
        {
            _anim = anim;
            _ID = ID;
            _pause = pause;
        }

        public SceneEventReturn Execute(Scene parent)
        {
            _target = Program.ActiveRoom.EntityList.Find(ent => ent.ID == _ID);
            if (_pause)
            {
                Action callback = () => _parent.Continue();
                _target.PlayAnimation(_anim, callback);
            }
            _target.PlayAnimation(_anim);
            return new SceneEventReturn(_pause);
        }

        public ISceneEvent Copy()
        {
            return this;
        }
    }
}
