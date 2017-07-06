﻿using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceExplorers
{
    public class RoomEntity : Entity, IRenderable
    {
        public Vector Velocity = new Vector(0, 0);
        
        protected Polygon collisionBounds;
        public bool CollisionDetection = false;
        public bool LockZLevel = false;
        public string TextureKey;

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

        public virtual void Step()
        {
            if (!LockZLevel)
                ZLevel = (int)(Position.Y + Size.Y);
            if (CollisionDetection)
                collisionBounds.Offset(Velocity);
            Position += Velocity;
        }

        public virtual void Destroy()
        {
            Program.ActiveRoom.EntityList.Remove(this);
        }

        public virtual bool Collision_Check(RoomEntity obj)
        {
            Polygon candidate = obj.GetCollisionBounds();
            Polygon.PolygonCollisionResult result = collisionBounds.PolygonCollision(candidate, Velocity);
            Velocity += result.MinimumTranslationVector;
            return result.WillIntersect;
        }

        public void Interaction(Actor user)
        {
            Console.WriteLine("Interaction with " + ID);
            InteractAction.Invoke(user, this);
        }

        public virtual Renderable Draw()
        {
            if (TextureKey != null)
            {
                Sprite sprite = new Sprite(TextureLibrary.Textures[TextureKey]);
                sprite.Position = new SFML.Window.Vector2f(GetXPosition(), GetYPosition());
                return new Renderable(sprite);
            }
            return new Renderable(null);
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