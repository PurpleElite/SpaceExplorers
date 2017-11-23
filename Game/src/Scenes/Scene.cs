using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceExplorers
{
    public class Scene
    {
        public List<ISceneEvent> Events;
        public string ID;
        int index;

        public Scene(string id)
        {
            Events = new List<ISceneEvent>();
            ID = id;
            index = -1;
        }

        public void Run()
        {
            Scene copy = new Scene(ID);
            copy.Events = new List<ISceneEvent>(Events);
            copy.Continue();
        }

        public void Continue()
        {
            index++;
            if (index < Events.Count )
            {
                SceneEventReturn flags = Events[index].Execute(this);
                if (flags.Pause == false)
                {
                    Continue();
                }
            }
        }
    }
}
