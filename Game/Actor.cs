using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;

namespace SpaceExplorers
{
    class Actor : RoomEntity, IControllable
    {
        enum Direction : byte { Down, Up, Left, Right };

        bool keyUp = false;
        bool keyDown = false;
        bool keyLeft = false;
        bool keyRight = false;
        Direction verticalHeading = 0;
        Direction horizontalHeading = 0;
        Direction keyRecent = 0;
        float speed;
        float interactSize = 50;
        String portraitKey;

        public Actor(string ID, Vector position, int[] size, string textureKey, string portraitKey, float speed)
        {
            this.ID = ID;
            this.position = position;
            this.size = size;
            velocity = new Vector(0, 0);
            this.textureKey = textureKey;
            this.portraitKey = portraitKey;
            this.speed = speed;
        }

        // --Public Methods--
        public override void Step()
        {
            ZLevel = (int)position.Y + size[1];
            if (CollisionDetection)
                collisionBounds.Offset(velocity);
            position += velocity;
            updateVelocity();
        }

        /*public override bool Collision_Check(MapObject obj)
        {
            return base.Collision_Check(obj);
        }*/

        // --Private Methods--
        private void updateVelocity()
        {
            if (keyUp && verticalHeading == Direction.Up)
                velocity.Y = -1;
            else if (keyDown && verticalHeading == Direction.Down)
                velocity.Y = 1;
            else
                velocity.Y = 0;

            if (keyLeft && horizontalHeading == Direction.Left)
                velocity.X = -1;
            else if (keyRight && horizontalHeading == Direction.Right)
                velocity.X = 1;
            else
                velocity.X = 0;

            velocity.Normalize();
            velocity *= speed;
        }

        internal FloatRect getInteractArea()
        {
            FloatRect interactArea;
            switch (keyRecent)
            {
                case Direction.Up:
                    interactArea = new FloatRect(collisionBounds.Center.X - interactSize* 1.5f / 2, collisionBounds.Center.Y - interactSize, interactSize * 1.5f, interactSize);
                    break;
                case Direction.Down:
                    interactArea = new FloatRect(collisionBounds.Center.X - interactSize * 1.5f / 2, collisionBounds.Center.Y, interactSize * 1.5f, interactSize);
                    break;
                case Direction.Left:
                    interactArea = new FloatRect(collisionBounds.Center.X - interactSize, collisionBounds.Center.Y - interactSize * 1.5f / 2, interactSize, interactSize * 1.5f);
                    break;
                case Direction.Right:
                    interactArea = new FloatRect(collisionBounds.Center.X, collisionBounds.Center.Y - interactSize * 1.5f / 2, interactSize, interactSize * 1.5f);
                    break;
                default:
                    interactArea = new FloatRect();
                    break;
            }
            return interactArea;
        }

        //Key Presses
        public void Up_Pressed() { keyUp = true; verticalHeading = Direction.Up; keyRecent = Direction.Up; }

        public void Down_Pressed() { keyDown = true; verticalHeading = Direction.Down; keyRecent = Direction.Down; }

        public void Left_Pressed() { keyLeft = true; horizontalHeading = Direction.Left; keyRecent = Direction.Left; }

        public void Right_Pressed() { keyRight = true; horizontalHeading = Direction.Right; keyRecent = Direction.Right;  }

        public void Up_Released() { keyUp = false; if (keyDown) verticalHeading = Direction.Down; }

        public void Down_Released() { keyDown = false; if (keyUp) verticalHeading = Direction.Up; }

        public void Left_Released() { keyLeft = false; if (keyRight) horizontalHeading = Direction.Right; }

        public void Right_Released() { keyRight = false; if (keyLeft) horizontalHeading = Direction.Left; }

        public void Use_Pressed() { Program.ActiveRoom.Use(this); }

        public void Use_Released()
        {
            // Do nothing
        }
    }
}
