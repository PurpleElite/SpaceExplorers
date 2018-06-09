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
        public enum PortraitType : int { normal, glare, angry, smirk, somber, curious, concerned, laughing, suspicious, conflicted, misc1 };
        enum Direction : int { E = 0, SE = 45, S = 90, SW = 135, W = 180, NW = 225,  N = 270, NE = 315 };

        public string Name;

        private bool _keyUp = false;
        private bool _keyDown = false;
        private bool _keyLeft = false;
        private bool _keyRight = false;
        private Direction _verticalHeading = 0;
        private Direction _horizontalHeading = 0;
        private Direction _keyRecent = 0;
        private float _speed;
        private float _interactSize = 50;
        private int _runFrame = 0;
        public Dictionary<PortraitType, string> Portraits;

        public Actor(string ID, string name, Vector size, string textureKey, string portraitKey, float speed) : base(ID, size, textureKey)
        {
            Name = name;
            Size = size;
            Velocity = new Vector(0, 0);
            Portraits = new Dictionary<PortraitType, string>();
            Portraits.Add(PortraitType.normal, portraitKey);
            _speed = speed;
        }

        // --Public Methods--
        public override Entity Copy()
        {
            Actor copy = (Actor)base.Copy();
            return copy;
        }

        public void SetFacing(double angle)
        {
            angle %= 360;
            if (angle > 180 && angle <= 360)
            {
                _verticalHeading = Direction.N;
            }
            else
            {
                _verticalHeading = Direction.S;
            }
            if (angle > 270 || angle <= 90)
            {
                _horizontalHeading = Direction.E;
            }
            else
            {
                _horizontalHeading = Direction.W;
            }
        }

        public override void Step()
        {
            UpdateAnimation();
            base.Step();
            UpdateVelocity();
        }

        // --Private Methods--
        private void UpdateAnimation()
        {
            if (Velocity.Magnitude > 0.1)
            {
                // Moving
                if (AnimationType.IsMovement(CurrAnimation))
                {
                    _runFrame = CurrAnimation.StepCount;
                }
                Direction direction = (Direction)((Math.Round(Velocity.GetDirection() / 45) * 45) % 360);
                switch (direction)
                {
                    case Direction.E:
                        if (Animations.ContainsKey(AnimType.RunE) && CurrAnimType != AnimType.RunE)
                        {
                            PlayAnimation(AnimType.RunE);
                            CurrAnimation.SkipFrames(_runFrame);
                        }
                        break;
                    case Direction.NE:
                        if (Animations.ContainsKey(AnimType.RunNE) && CurrAnimType != AnimType.RunNE)
                        {
                            PlayAnimation(AnimType.RunNE);
                            CurrAnimation.SkipFrames(_runFrame);
                        }
                        break;
                    case Direction.N:
                        if (Animations.ContainsKey(AnimType.RunN) && CurrAnimType != AnimType.RunN)
                        {
                            PlayAnimation(AnimType.RunN);
                            CurrAnimation.SkipFrames(_runFrame);
                        }
                        break;
                    case Direction.NW:
                        if (Animations.ContainsKey(AnimType.RunNW) && CurrAnimType != AnimType.RunNW)
                        {
                            PlayAnimation(AnimType.RunNW);
                            CurrAnimation.SkipFrames(_runFrame);
                        }
                        break;
                    case Direction.W:
                        if (Animations.ContainsKey(AnimType.RunW) && CurrAnimType != AnimType.RunW)
                        {
                            PlayAnimation(AnimType.RunW);
                            CurrAnimation.SkipFrames(_runFrame);
                        }
                        break;
                    case Direction.SW:
                        if (Animations.ContainsKey(AnimType.RunSW) && CurrAnimType != AnimType.RunSW)
                        {
                            PlayAnimation(AnimType.RunSW);
                            CurrAnimation.SkipFrames(_runFrame);
                        }
                        break;
                    case Direction.S:
                        if (Animations.ContainsKey(AnimType.RunS) && CurrAnimType != AnimType.RunS)
                        {
                            PlayAnimation(AnimType.RunS);
                            CurrAnimation.SkipFrames(_runFrame);
                        }
                        break;
                    case Direction.SE:
                        if (Animations.ContainsKey(AnimType.RunSE) && CurrAnimType != AnimType.RunSE)
                        {
                            PlayAnimation(AnimType.RunSE);
                            CurrAnimation.SkipFrames(_runFrame);
                        }
                        break;
                }
            }
            else
            {
                // Stationary
                _runFrame = 0;
                // Determine facing and play appropriate idle animation
                if (_horizontalHeading == Direction.E)
                {
                    PlayAnimation(AnimType.IdleE);
                }
                if (_horizontalHeading == Direction.W)
                {
                    PlayAnimation(AnimType.IdleW);
                }
            }
        }

        private void UpdateVelocity()
        {
            if (_keyUp && _verticalHeading == Direction.N)
                Velocity.Y = -1;
            else if (_keyDown && _verticalHeading == Direction.S)
                Velocity.Y = 1;
            else
                Velocity.Y = 0;

            if (_keyLeft && _horizontalHeading == Direction.W)
                Velocity.X = -1;
            else if (_keyRight && _horizontalHeading == Direction.E)
                Velocity.X = 1;
            else
                Velocity.X = 0;

            Velocity.Normalize();
            Velocity *= _speed;
        }

        internal FloatRect GetInteractArea()
        {
            FloatRect interactArea;
            switch (_keyRecent)
            {
                case Direction.N:
                    interactArea = new FloatRect(Position.X + InteractPoint.X - _interactSize* 1.5f / 2, 
                        Position.Y + InteractPoint.Y - _interactSize, 
                        _interactSize * 1.5f, 
                        _interactSize);
                    break;
                case Direction.S:
                    interactArea = new FloatRect(Position.X + InteractPoint.X - _interactSize * 1.5f / 2, 
                        Position.Y + InteractPoint.Y, 
                        _interactSize * 1.5f, 
                        _interactSize);
                    break;
                case Direction.W:
                    interactArea = new FloatRect(Position.X + InteractPoint.X - _interactSize, 
                        Position.Y + InteractPoint.Y - _interactSize * 1.5f / 2, 
                        _interactSize, 
                        _interactSize * 1.5f);
                    break;
                case Direction.E:
                    interactArea = new FloatRect(Position.X + InteractPoint.X, 
                        Position.Y + InteractPoint.Y - _interactSize * 1.5f / 2, 
                        _interactSize, 
                        _interactSize * 1.5f);
                    break;
                default:
                    interactArea = new FloatRect();
                    break;
            }
            return interactArea;
        }

        //Key Presses
        public void Up_Pressed() { _keyUp = true; _verticalHeading = Direction.N; _keyRecent = Direction.N; }

        public void Down_Pressed() { _keyDown = true; _verticalHeading = Direction.S; _keyRecent = Direction.S; }

        public void Left_Pressed() { _keyLeft = true; _horizontalHeading = Direction.W; _keyRecent = Direction.W; }

        public void Right_Pressed() { _keyRight = true; _horizontalHeading = Direction.E; _keyRecent = Direction.E;  }

        public void Up_Released() { _keyUp = false; if (_keyDown) _verticalHeading = Direction.S; }

        public void Down_Released() { _keyDown = false; if (_keyUp) _verticalHeading = Direction.N; }

        public void Left_Released() { _keyLeft = false; if (_keyRight) _horizontalHeading = Direction.E; }

        public void Right_Released() { _keyRight = false; if (_keyLeft) _horizontalHeading = Direction.W; }

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
