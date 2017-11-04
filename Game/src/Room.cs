using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;

namespace SpaceExplorers
{
    class Room
    {
        //List of objects in the room
        public List<RoomEntity> EntityList;

        private Queue<RoomEntity> AddQueue;
        private Queue<RoomEntity> RemoveQueue;

        //Room Bounds
        int xBound;
        int yBound;

        Camera camera;

        public Room(int xBound, int yBound, Camera camera)
        {
            this.xBound = xBound;
            this.yBound = yBound;
            EntityList = new List<RoomEntity>();
            AddQueue = new Queue<RoomEntity>();
            RemoveQueue = new Queue<RoomEntity>();
            this.camera = camera;
            camera.Bounds = new Vector2f(xBound, yBound);
        }

        public void AddEntity(RoomEntity ent)
        {
            AddQueue.Enqueue(ent);
        }

        public void RemoveEntity(RoomEntity ent)
        {
            RemoveQueue.Enqueue(ent);
        }

        public void Step()
        {
            while (AddQueue.Count > 0)
            {
                EntityList.Add(AddQueue.Dequeue());
            }
            while (RemoveQueue.Count > 0)
            {
                EntityList.Remove(RemoveQueue.Dequeue());
            }
            foreach (var ent in EntityList)
            {
                if (ent.CollisionDetection)
                {
                    foreach (var collideCandidate in EntityList.Where(item => item != ent))
                    {
                        if (collideCandidate.CollisionDetection)
                        {
                            ent.Collision_Check(collideCandidate);
                        }
                    }
                }
                ent.Step();
            }
            foreach (var actor in EntityList.OfType<Actor>())
            {
                int newZ = actor.ZLevel;
                foreach (var ent in EntityList)
                {
                    if (ent != actor)
                    {
                        if (Utility.RectangleIntersect(actor.Position.X, actor.Position.Y, actor.Size.X, actor.Size.Y,
                            ent.Position.X, ent.Position.Y, ent.Size.X, ent.Size.Y))
                        {
                            var relation = ent.ZRelation(actor.InteractPoint+actor.Position);
                            if (relation == Polygon.PointPosition.Below && ent.ZLevel > newZ)
                            {
                                newZ = ent.ZLevel + 1;
                            }
                            else if (relation == Polygon.PointPosition.Above && ent.ZLevel < newZ)
                            {
                                newZ = ent.ZLevel - 1;
                            }
                        }
                    }
                }
                actor.ZLevel = newZ;
            }
            EntityList = EntityList.OrderBy(MapEntity => MapEntity.ZLevel).ToList();
            camera.Step();
        }


        internal void Use(Actor user)
        {
            RoomEntity target = null;
            float minDistance = -1;
            FloatRect interactArea = user.getInteractArea();
            foreach (var ent in EntityList.Where(item => item.Interactable))
            {
                Vector interactPoint = ent.GetInteractPoint();
                if (interactArea.Contains(interactPoint.X, interactPoint.Y))
                {
                    if (target == null)
                    {
                        target = ent;
                        minDistance = user.InteractPoint.DistanceTo(ent.InteractPoint);
                    }
                    else if (user.InteractPoint.DistanceTo(ent.InteractPoint) < minDistance)
                    {
                        target = ent;
                        minDistance = user.InteractPoint.DistanceTo(ent.InteractPoint);
                    }
                }
            }
            if (target != null)
                target.Interaction(user);
        }

        public IEnumerable<Renderable> RenderList()
        {
            if (EntityList.Count > 0)
            {
                foreach (var ent in EntityList)
                {
                    yield return ent.Draw();
                }
            }
            yield return new Renderable(null);
        }
    }
}
