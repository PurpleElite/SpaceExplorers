using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceExplorers
{
    class TextureEntity : Entity
    {
        protected string textureKey;

        // Constructors

        public TextureEntity(string ID, Vector position, int[] size, string textureKey) : base(ID, position, size)
        {
            this.textureKey = textureKey;
        }

        public TextureEntity() : base()
        {
            textureKey = null;
        }

        public virtual string Draw()
        {
            return textureKey;
        }

        public virtual void SetTexture(String textureKey)
        {
            this.textureKey = textureKey;
        }
    }
}
