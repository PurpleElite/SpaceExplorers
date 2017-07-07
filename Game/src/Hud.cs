using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;

namespace SpaceExplorers
{
    internal class Hud
    {
        //List of objects in the HUD
        public List<HudEntity> EntityList;

        private Queue<HudEntity> AddQueue;
        private Queue<HudEntity> RemoveQueue;
        private Vector2u windowDim;

        public Hud(Vector2u windowDim)
        {
            this.windowDim = windowDim;
            EntityList = new List<HudEntity>();
            AddQueue = new Queue<HudEntity>();
            RemoveQueue = new Queue<HudEntity>();
        }

        public void AddEntity(HudEntity ent)
        {
            AddQueue.Enqueue(ent);
        }

        public void RemoveEntity(HudEntity ent)
        {
            RemoveQueue.Enqueue(ent);
        }

        public void Step()
        {
            while(AddQueue.Count > 0)
            {
                EntityList.Add(AddQueue.Dequeue());
            }
            while (RemoveQueue.Count > 0)
            {
                EntityList.Remove(RemoveQueue.Dequeue());
            }
            foreach (var ent in EntityList)
            {
                ent.Step();
            }
            EntityList = EntityList.OrderBy(HudEntity => HudEntity.ZLevel).ToList();
        }

        public IEnumerable<Renderable> RenderList()
        {
            if (EntityList.Count > 0)
            {
                foreach (var ent in EntityList)
                {
                    yield return ent.Draw();
                }
            }
            yield return new Renderable(null);
        }
    }
}