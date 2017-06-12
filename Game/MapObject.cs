using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceExplorers
{
    public class MapObject
    {
        protected Vector velocity;
        protected Vector position;
        protected int[] size = { 0, 0 };
        protected String textureKey;
        protected String ID;
        protected Polygon collisionBounds;
        public bool CollisionDetection = false;
        public bool Interactable = false;
        public Vector InteractPoint;
        public int ZLevel = 0;
        public bool LockZLevel = false;

        // --Constructors--
        public MapObject(String ID, Vector velocity, Vector position, int[] size, String textureKey)
        {
            this.ID = ID;
            this.velocity = velocity;
            this.position = position;
            this.size = size;
            this.textureKey = textureKey;
        }

        public MapObject(String ID, Vector position, int[] size, String textureKey)
        {
            this.ID = ID;
            velocity = new Vector(0, 0);
            this.position = position;
            this.size = size;
            this.textureKey = textureKey;
        }

        public MapObject()
        {
            ID = "default";
            velocity = new Vector(0, 0);
            position = new Vector(0, 0);
            textureKey = null;
        }

        // --Public Methods--
        public virtual void Step()
        {
            if (!LockZLevel)
                ZLevel = (int)position.Y + size[1];
            if (CollisionDetection)
                collisionBounds.Offset(velocity);
            position += velocity;
        }

        public virtual bool Collision_Check(MapObject obj)
        {
            Polygon candidate = obj.GetCollisionBounds();
            Polygon.PolygonCollisionResult result = collisionBounds.PolygonCollision(candidate, velocity);
            velocity += result.MinimumTranslationVector;
            return result.WillIntersect;
        }

        public void Interaction(Character user)
        {
            Console.WriteLine("Interaction with " + ID);
        }

        // --Getter Methods--
        public Vector GetVelocity()
        {
            return velocity;
        }

        public float GetXVelocity()
        {
            return velocity.X;
        }

        public float GetYVelocity()
        {
            return velocity.Y;
        }

        public Vector GetPosition()
        {
            return position;
        }

        public int GetXPosition()
        {
            return (int)position.X;
        }

        public int GetYPosition()
        {
            return (int)position.Y;
        }

        public int GetWidth()
        {
            return size[0];
        }

        public int GetHeight()
        {
            return size[1];
        }

        public int GetZLevel()
        {
            return ZLevel;
        }

        public String GetTextureKey()
        {
            return textureKey;
        }

        public String GetID()
        {
            return ID;
        }

        public Polygon GetCollisionBounds()
        {
            return collisionBounds;
        }

        public Vector GetInteractPoint()
        {
            return InteractPoint + position;
        }

        // --Setter Methods--
        public void SetVelocity(Vector velocity)
        {
            this.velocity = velocity;
        }

        public void SetXVelocity(float xVelocity)
        {
            velocity.X = xVelocity;
        }

        public void SetYVelocity(float yVelocity)
        {
            velocity.Y = yVelocity;
        }

        public void SetPosition(Vector position)
        {
            this.position = position;
        }

        public void SetXPosition(float xPosition)
        {
            position.X = xPosition;
        }

        public void SetYPosition(float yPosition)
        {
            position.Y = yPosition;
        }

        public void SetZLevel(int z)
        {
            ZLevel = z;
            LockZLevel = true;
        }

        public void SetSprite(String textureKey)
        {
            this.textureKey = textureKey;
        }

        public void SetID(String ID)
        {
            this.ID = ID;
        }

        public void SetCollisionBounds(Polygon bounds)
        {
            CollisionDetection = true;
            collisionBounds = bounds;
            collisionBounds.Offset(position);
        }

        public void SetInteractPoint(int x, int y)
        {
            InteractPoint = new Vector(x, y);
            Interactable = true;
        }
    }
}
