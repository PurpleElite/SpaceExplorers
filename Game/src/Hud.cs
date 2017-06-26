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

        private Vector2u windowDim;

        public Hud(Vector2u windowDim)
        {
            this.windowDim = windowDim;
            EntityList = new List<HudEntity>();
        }

        public void Step()
        {
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