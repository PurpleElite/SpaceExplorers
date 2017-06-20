namespace SpaceExplorers
{
    class HudEntity : TextureEntity
    {
        // --Constructors--
        public HudEntity(string ID, Vector position, int[] size, string textureKey) : base(ID, position, size, textureKey)
        {
            // do nothing
        }

        public HudEntity() : base()
        {
            // do nothing
        }

        // --Public Methods--
        public virtual void Step()
        {
            
        }
    }
}