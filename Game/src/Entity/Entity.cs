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
        public Vector Position;
        public Vector Size;
        public string ID;
        public bool Interactable = false;
        public Vector InteractPoint;
        public Action<Entity, Entity> InteractAction;
        public int ZLevel = 0;
        public int CopyNum = 0;

        // Constructors

        public Entity(string ID, Vector size)
        {
            this.ID = ID;
            Position = new Vector(0, 0);
            Size = size;
        }

        public Entity()
        {
            ID = "Default";
            Position = new Vector (0, 0);
            Size = new Vector(0, 0);
        }

        public virtual Entity Copy()
        {
            return ObjectExtensions.Copy(this);
        }

        public void InitializeInteraction(Vector location, Action<Entity, Entity> action)
        {
            InteractPoint = location;
            InteractAction = action;
            Interactable = true;
        }

        // Getter Methods

        public virtual Vector GetPosition()
        {
            return Position;
        }

        public virtual int GetXPosition()
        {
            return (int)Position.X;
        }

        public virtual int GetYPosition()
        {
            return (int)Position.Y;
        }

        public virtual int GetWidth()
        {
            return (int) Size.X;
        }

        public virtual int GetHeight()
        {
            return (int) Size.Y;
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
            Position = position;
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
