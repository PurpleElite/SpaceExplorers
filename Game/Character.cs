using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;

namespace SpaceExplorers
{
    public class Character : MapObject
    {
        enum Direction : byte { Down, Up, Left, Right };

        bool keyUp = false;
        bool keyDown = false;
        bool keyLeft = false;
        bool keyRight = false;
        Direction verticalHeading = 0;
        Direction horizontalHeading = 0;
        float speed;

        public Character(String ID, Vector position, int[] size, String textureKey, float speed)
        {
            this.ID = ID;
            this.position = position;
            velocity = new Vector(0, 0);
            this.textureKey = textureKey;
            this.size = size;
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

        //Key Presses
        internal void Up_Pressed() { keyUp = true; verticalHeading = Direction.Up; }

        internal void Down_Pressed() { keyDown = true; verticalHeading = Direction.Down; }

        internal void Left_Pressed() { keyLeft = true; horizontalHeading = Direction.Left; }

        internal void Right_Pressed() { keyRight = true; horizontalHeading = Direction.Right; }

        internal void Up_Released() { keyUp = false; if (keyDown) verticalHeading = Direction.Down; }

        internal void Down_Released() { keyDown = false; if (keyUp) verticalHeading = Direction.Up; }

        internal void Left_Released() { keyLeft = false; if (keyRight) horizontalHeading = Direction.Right; }

        internal void Right_Released() { keyRight = false; if (keyLeft) horizontalHeading = Direction.Left; }
    }
}
