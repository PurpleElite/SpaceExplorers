using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceExplorers
{
    class RoomEntity : Entity, IRenderable
    {
        protected Vector velocity;
        
        protected Polygon collisionBounds;
        public bool CollisionDetection = false;
        public bool LockZLevel = false;
        public string textureKey;

        // --Constructors--
        public RoomEntity(string ID, Vector velocity, Vector position, int[] size, string textureKey) : base(ID, position, size)
        {
            this.velocity = velocity;
            this.textureKey = textureKey;
        }

        public RoomEntity(string ID, Vector position, int[] size, string textureKey) : base(ID, position, size)
        {
            velocity = new Vector(0, 0);
            this.textureKey = textureKey;
        }

        public RoomEntity() : base()
        {
            velocity = new Vector(0, 0);
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

        public virtual bool Collision_Check(RoomEntity obj)
        {
            Polygon candidate = obj.GetCollisionBounds();
            Polygon.PolygonCollisionResult result = collisionBounds.PolygonCollision(candidate, velocity);
            velocity += result.MinimumTranslationVector;
            return result.WillIntersect;
        }

        public void InitializeInteraction(int x, int y, Action<Entity, Entity> action)
        {
            InteractPoint = new Vector(x, y);
            InteractAction = action;
            Interactable = true;
        }

        public void Interaction(Actor user)
        {
            Console.WriteLine("Interaction with " + ID);
            InteractAction.Invoke(user, this);
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

        public override void SetZLevel(int z)
        {
            LockZLevel = true;
            base.SetZLevel(z);
        }

        public void SetCollisionBounds(Polygon bounds)
        {
            CollisionDetection = true;
            collisionBounds = bounds;
            collisionBounds.Offset(position);
        }
    }
}
