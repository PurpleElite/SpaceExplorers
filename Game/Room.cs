﻿using System;
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
        public List<MapObject> objectList;

        //Room Bounds
        int xBound;
        int yBound;

        Camera camera;

        //Sprite for handing off objects to be rendered
        Sprite sprite;

        public Room(int xBound, int yBound, Camera camera)
        {
            this.xBound = xBound;
            this.yBound = yBound;
            objectList = new List<MapObject>();
            this.camera = camera;
            camera.Bounds = new Vector2f(xBound, yBound);
        }

        public void Step()
        {
            foreach (var obj in objectList)
            {
                if (obj.CollisionDetection)
                {
                    foreach (var collideCandidate in objectList.Where(item => item != obj))
                    {
                        if (collideCandidate.CollisionDetection)
                        {
                            obj.Collision_Check(collideCandidate);
                        }
                    }
                }
                obj.Step();
            }
            objectList = objectList.OrderBy(MapObject => MapObject.ZLevel).ToList();
            camera.Step();
        }


        internal void Use(Character user)
        {
            MapObject interact = null;
            float minDistance = -1;
            FloatRect interactArea = user.getInteractArea();
            foreach (var obj in objectList.Where(item => item.Interactable))
            {
                Vector interactPoint = obj.GetInteractPoint();
                if (interactArea.Contains(interactPoint.X, interactPoint.Y))
                {
                    if (interact == null)
                    {
                        interact = obj;
                        minDistance = user.GetCollisionBounds().Center.DistanceTo(obj.InteractPoint);
                    }
                    else if (user.GetCollisionBounds().Center.DistanceTo(obj.InteractPoint) < minDistance)
                    {
                        interact = obj;
                        minDistance = user.GetCollisionBounds().Center.DistanceTo(obj.InteractPoint);
                    }
                }
            }
            if (interact != null)
                interact.Interaction(user);
        }

        //Iterator for advancing steps and rendering objects in room in relation to position of camera
        public IEnumerable<Sprite> RenderList()
        {
            foreach (var obj in objectList)
            {
                sprite = new Sprite(TextureLibrary.Textures[obj.GetTextureKey()]);
                int xPosition = obj.GetXPosition();
                int yPosition = obj.GetYPosition();
                sprite.Position = new Vector2f(xPosition, yPosition);
                yield return sprite;
            }
            yield return null;
        }
    }
}
