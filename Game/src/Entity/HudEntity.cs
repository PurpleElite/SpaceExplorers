using SFML.Graphics;

namespace SpaceExplorers
{
    class HudEntity : Entity
    {
        // --Constructors--
        public HudEntity(string ID, Vector  size, string textureKey) : base(ID, size)
        {
            TextureKey = textureKey;
        }

        public HudEntity() : base()
        {
            TextureKey = null;
        }

        // --Public Methods--
        public override Entity Copy()
        {
            HudEntity copy = (HudEntity) base.Copy();
            return copy;
        }

        public virtual void Destroy()
        {
            Program.ActiveHud.RemoveEntity(this);
        }
    }
}