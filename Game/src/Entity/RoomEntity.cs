using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceExplorers
{
    public class RoomEntity : Entity
    {
        protected Polygon collisionBounds;
        public bool CollisionDetection = false;

        // --Constructors--

        public RoomEntity(string ID, Vector size, string textureKey) : base(ID, size)
        {
            TextureKey = textureKey;
        }

        public RoomEntity() : base()
        {
            TextureKey = null;
        }

        // --Public Methods--
        public override Entity Copy()
        {
            RoomEntity copy = (RoomEntity)base.Copy();
            copy.Velocity = new Vector(Velocity.X, Velocity.Y);
            if (CollisionDetection)
                copy.collisionBounds = collisionBounds.Copy();
            return copy;
        }

        public virtual void Destroy()
        {
            Program.ActiveRoom.RemoveEntity(this);
        }

        public virtual bool Collision_Check(RoomEntity obj)
        {
            Polygon candidate = obj.GetCollisionBounds();
            Polygon.PolygonCollisionResult result = collisionBounds.PolygonCollision(candidate, Velocity);
            Velocity += result.MinimumTranslationVector;
            return result.WillIntersect;
        }

        public virtual void Interaction(Actor user)
        {
            InteractAction.Invoke(user, this);
        }

        // --Getter Methods--
        public Vector GetVelocity()
        {
            return Velocity;
        }

        public float GetXVelocity()
        {
            return Velocity.X;
        }

        public float GetYVelocity()
        {
            return Velocity.Y;
        }

        public Polygon GetCollisionBounds()
        {
            return collisionBounds;
        }

        public Vector GetInteractPoint()
        {
            return InteractPoint + Position;
        }

        // --Setter Methods--

        public override void SetPosition(Vector position)
        {
            Vector difference = position - Position;
            if (CollisionDetection)
                collisionBounds.Offset(difference);
            base.SetPosition(position);
        }

        public void SetVelocity(Vector velocity)
        {
            Velocity = velocity;
        }

        public void SetXVelocity(float xVelocity)
        {
            Velocity.X = xVelocity;
        }

        public void SetYVelocity(float yVelocity)
        {
            Velocity.Y = yVelocity;
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
            collisionBounds.Offset(Position);
        }
    }
}
