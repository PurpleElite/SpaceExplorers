using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceExplorers
{
    public class Entity
    {
        protected Vector position;
        protected int[] size;
        protected string ID;
        public bool Interactable = false;
        public Vector InteractPoint;
        public Action<Entity, Entity> InteractAction;
        public int ZLevel = 0;

        // Constructors

        public Entity(string ID, Vector position, int[] size)
        {
            this.ID = ID;
            this.position = position;
            this.size = size;
        }

        public Entity()
        {
            ID = "Default";
            position = new Vector (0, 0);
            size = new int[]{ 0, 0 };
        }

        // Getter Methods

        public virtual Vector GetPosition()
        {
            return position;
        }

        public virtual int GetXPosition()
        {
            return (int)position.X;
        }

        public virtual int GetYPosition()
        {
            return (int)position.Y;
        }

        public virtual int GetWidth()
        {
            return size[0];
        }

        public virtual int GetHeight()
        {
            return size[1];
        }

        public virtual int GetZLevel()
        {
            return ZLevel;
        }

        public virtual String GetID()
        {
            return ID;
        }

        // Setter Methods

        public virtual void SetPosition(Vector position)
        {
            this.position = position;
        }

        public virtual void SetXPosition(float xPosition)
        {
            position.X = xPosition;
        }

        public virtual void SetYPosition(float yPosition)
        {
            position.Y = yPosition;
        }

        public virtual void SetZLevel(int z)
        {
            ZLevel = z;
        }

        public virtual void SetID(String ID)
        {
            this.ID = ID;
        }
    }
}
