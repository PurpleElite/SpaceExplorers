using SFML.Graphics;

namespace SpaceExplorers
{
    class HudEntity : Entity, IRenderable
    {
        string textureKey;

        // --Constructors--
        public HudEntity(string ID, Vector position, int[] size, string textureKey) : base(ID, position, size)
        {
            this.textureKey = textureKey;
        }

        public HudEntity() : base()
        {
            textureKey = null;
        }

        // --Public Methods--
        public virtual void Step()
        {
            
        }

        public virtual Renderable Draw()
        {
            if (textureKey != null)
            {
                Sprite sprite = new Sprite(TextureLibrary.Textures[textureKey]);
                sprite.Position = new SFML.Window.Vector2f(GetXPosition(), GetYPosition());
                return new Renderable(sprite);
            }
            return new Renderable(null);
        }
    }
}