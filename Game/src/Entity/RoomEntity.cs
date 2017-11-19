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
        protected List<Polygon> _collisionBounds;
        public Polygon ZBound;
        public bool CollisionDetection = false;
        public bool Immobile = false;

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
            {
                copy._collisionBounds = new List<Polygon>();
                foreach(var bound in _collisionBounds)
                {
                    copy._collisionBounds.Add(bound.Copy());
                }
            }
            if (ZBound != null)
            {
                copy.ZBound = ZBound.Copy();
            }
            return copy;
        }

        public virtual void Destroy()
        {
            Program.ActiveRoom.RemoveEntity(this);
        }

        public virtual bool Collision_Check(RoomEntity obj)
        {
            bool willIntersect = false;
            List<Polygon> candidates = obj.GetCollisionBounds();
            foreach (var candidate in candidates)
            {
                foreach (var bound in _collisionBounds)
                {
                    Polygon.PolygonCollisionResult result = bound.PolygonCollision(candidate, Velocity);
                    if (!Immobile)
                    {
                        Velocity += result.MinimumTranslationVector;
                        willIntersect |= result.WillIntersect;
                    }
                }
            }
            return willIntersect;
        }

        public virtual Polygon.PointPosition ZRelation(Vector point)
        {
            if (ZBound != null)
            {
                return ZBound.PointYRelation(point);
            }
            else
            {
                return Polygon.PointPosition.None;
                /**Polygon.PointPosition ret = Polygon.PointPosition.None;
                foreach (var bound in _collisionBounds)
                {
                    Polygon.PointPosition relation = bound.PointYRelation(point);
                    if (relation == Polygon.PointPosition.Inside)
                    {
                        return relation;
                    }
                    else if (relation == Polygon.PointPosition.Above)
                    {
                        if (ret == Polygon.PointPosition.Below)
                        {
                            return Polygon.PointPosition.Inside;
                        }
                        else
                        {
                            ret = Polygon.PointPosition.Above;
                        }
                    }
                    else if (relation == Polygon.PointPosition.Below)
                    {
                        if (ret == Polygon.PointPosition.Above)
                        {
                            return Polygon.PointPosition.Inside;
                        }
                        else
                        {
                            ret = Polygon.PointPosition.Below;
                        }
                    }
                }
                return ret;**/
            }
        }

        public virtual void Interaction(Actor user)
        {
            InteractAction.Invoke();
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

        public List<Polygon> GetCollisionBounds()
        {
            return _collisionBounds;
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
            {
                foreach(var bound in _collisionBounds)
                    bound.Offset(difference);
            }
            if (ZBound != null)
            {
                ZBound.Offset(difference);
            }
            base.SetPosition(position);
        }

        public void SetVelocity(Vector velocity)
        {
            if (!Immobile)
                Velocity = velocity;
        }

        public void SetXVelocity(float xVelocity)
        {
            if (!Immobile)
                Velocity.X = xVelocity;
        }

        public void SetYVelocity(float yVelocity)
        {
            if (!Immobile)
                Velocity.Y = yVelocity;
        }

        public override void SetZLevel(int z)
        {
            LockZLevel = true;
            base.SetZLevel(z);
        }

        public void SetCollisionBounds(Polygon bounds)
        {
            if (ZBound == null)
                ZBound = bounds.Copy();
            CollisionDetection = true;
            _collisionBounds = bounds.Copy().MakeConvex();
            foreach(var bound in _collisionBounds)
                bound.Offset(Position);
        }
    }
}
