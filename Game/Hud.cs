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

        //Iterator for advancing steps and rendering objects in room in relation to position of camera
        public IEnumerable<Sprite> RenderList()
        {
            Sprite sprite;
            if (entityList.Count > 0)
            {
                foreach (var ent in entityList)
                {
                    sprite = new Sprite(TextureLibrary.Textures[ent.GetTextureKey()]);
                    int xPosition = ent.GetXPosition();
                    int yPosition = ent.GetYPosition();
                    sprite.Position = new Vector2f(xPosition, yPosition);
                    yield return sprite;
                }
            }
            yield return null;
        }
    }
}