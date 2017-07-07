using SFML.Graphics;

namespace SpaceExplorers
{
    class HudEntity : Entity, IRenderable
    {
        public string textureKey;

        // --Constructors--
        public HudEntity(string ID, Vector  size, string textureKey) : base(ID, size)
        {
            this.textureKey = textureKey;
        }

        public HudEntity() : base()
        {
            textureKey = null;
        }

        // --Public Methods--
        public override Entity Copy()
        {
            HudEntity copy = (HudEntity) base.Copy();
            return copy;
        }
        public virtual void Step()
        {
            
        }

        public virtual void Destroy()
        {
            Program.ActiveHud.RemoveEntity(this);
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