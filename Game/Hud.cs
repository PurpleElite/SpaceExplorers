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
        public List<HudEntity> entityList;

        private Vector2u windowDim;

        public Hud(Vector2u windowDim)
        {
            this.windowDim = windowDim;
            entityList = new List<HudEntity>();
        }

        public void Step()
        {
            foreach (var ent in entityList)
            {
                ent.Step();
            }
            entityList = entityList.OrderBy(HudEntity => HudEntity.ZLevel).ToList();
        }

        public IEnumerable<Renderable> RenderList()
        {
            if (entityList.Count > 0)
            {
                foreach (var ent in entityList)
                {
                    yield return ent.Draw();
                }
            }
            yield return new Renderable(null);
        }
    }
}