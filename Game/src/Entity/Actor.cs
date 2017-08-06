using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;

namespace SpaceExplorers
{
    public class Actor : RoomEntity, IControllable
    {
        enum Direction : int { E = 0, SE = 45, S = 90, SW = 135, W = 180, NW = 225,  N = 270, NE = 315 };

        public string Name;

        bool keyUp = false;
        bool keyDown = false;
        bool keyLeft = false;
        bool keyRight = false;
        Direction verticalHeading = 0;
        Direction horizontalHeading = 0;
        Direction keyRecent = 0;
        float speed;
        float interactSize = 50;
        public string PortraitKey;

        public Actor(string ID, string name, Vector size, string textureKey, string portraitKey, float speed) : base(ID, size, textureKey)
        {
            Name = name;
            Size = size;
            Velocity = new Vector(0, 0);
            PortraitKey = portraitKey;
            this.speed = speed;
        }

        // --Public Methods--
        public override Entity Copy()
        {
            Actor copy = (Actor)base.Copy();
            return copy;
        }

        public override void Step()
        {
            base.Step();
            UpdateVelocity();
            UpdateAnimation();
        }

        // --Private Methods--
        private void UpdateAnimation()
        {
            if (Velocity.Magnitude > 0)
            {
                Direction direction = (Direction)((Math.Round(Velocity.GetDirection() / 45) * 45) % 360);
                switch (direction)
                {
                    case Direction.E:
                        if(Animations.ContainsKey(AnimType.RunE)) _animation = Animations[AnimType.RunE];
                        break;
                    case Direction.NE:
                        if (Animations.ContainsKey(AnimType.RunNE)) _animation = Animations[AnimType.RunNE];
                        break;
                    case Direction.N:
                        if (Animations.ContainsKey(AnimType.RunN)) _animation = Animations[AnimType.RunN];
                        break;
                    case Direction.NW:
                        if (Animations.ContainsKey(AnimType.RunNW)) _animation = Animations[AnimType.RunNW];
                        break;
                    case Direction.W:
                        if (Animations.ContainsKey(AnimType.RunW)) _animation = Animations[AnimType.RunW];
                        break;
                    case Direction.SW:
                        if (Animations.ContainsKey(AnimType.RunSW)) _animation = Animations[AnimType.RunSW];
                        break;
                    case Direction.S:
                        if (Animations.ContainsKey(AnimType.RunS)) _animation = Animations[AnimType.RunS];
                        break;
                    case Direction.SE:
                        if (Animations.ContainsKey(AnimType.RunSE)) _animation = Animations[AnimType.RunSE];
                        break;
                }
            }
            else
            {
                if (Animations.ContainsKey(AnimType.Idle))
                {
                    _animation = Animations[AnimType.Idle];
                }
                else
                {
                    _animation = null;
                }
            }
        }

        private void UpdateVelocity()
        {
            if (keyUp && verticalHeading == Direction.N)
                Velocity.Y = -1;
            else if (keyDown && verticalHeading == Direction.S)
                Velocity.Y = 1;
            else
                Velocity.Y = 0;

            if (keyLeft && horizontalHeading == Direction.W)
                Velocity.X = -1;
            else if (keyRight && horizontalHeading == Direction.E)
                Velocity.X = 1;
            else
                Velocity.X = 0;

            Velocity.Normalize();
            Velocity *= speed;
            if (ID == "AHavisham")
            Console.WriteLine("Velocity: X " + Velocity.X + ", Y " + Velocity.Y);
        }

        internal FloatRect getInteractArea()
        {
            FloatRect interactArea;
            switch (keyRecent)
            {
                case Direction.N:
                    interactArea = new FloatRect(collisionBounds.Center.X - interactSize* 1.5f / 2, collisionBounds.Center.Y - interactSize, interactSize * 1.5f, interactSize);
                    break;
                case Direction.S:
                    interactArea = new FloatRect(collisionBounds.Center.X - interactSize * 1.5f / 2, collisionBounds.Center.Y, interactSize * 1.5f, interactSize);
                    break;
                case Direction.W:
                    interactArea = new FloatRect(collisionBounds.Center.X - interactSize, collisionBounds.Center.Y - interactSize * 1.5f / 2, interactSize, interactSize * 1.5f);
                    break;
                case Direction.E:
                    interactArea = new FloatRect(collisionBounds.Center.X, collisionBounds.Center.Y - interactSize * 1.5f / 2, interactSize, interactSize * 1.5f);
                    break;
                default:
                    interactArea = new FloatRect();
                    break;
            }
            return interactArea;
        }

        //Key Presses
        public void Up_Pressed() { keyUp = true; verticalHeading = Direction.N; keyRecent = Direction.N; }

        public void Down_Pressed() { keyDown = true; verticalHeading = Direction.S; keyRecent = Direction.S; }

        public void Left_Pressed() { keyLeft = true; horizontalHeading = Direction.W; keyRecent = Direction.W; }

        public void Right_Pressed() { keyRight = true; horizontalHeading = Direction.E; keyRecent = Direction.E;  }

        public void Up_Released() { keyUp = false; if (keyDown) verticalHeading = Direction.S; }

        public void Down_Released() { keyDown = false; if (keyUp) verticalHeading = Direction.N; }

        public void Left_Released() { keyLeft = false; if (keyRight) horizontalHeading = Direction.E; }

        public void Right_Released() { keyRight = false; if (keyLeft) horizontalHeading = Direction.W; }

        public void Use_Pressed()
        {
            Program.ActiveRoom.Use(this);
        }

        public void Use_Released()
        {
            // Do nothing
        }
    }
}
