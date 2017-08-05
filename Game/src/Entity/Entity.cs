using SFML.Graphics;
using System;
using System.Collections.Generic;

namespace SpaceExplorers
{
    public class Entity : IRenderable
    {
        private class TimerAction
        {
            public Action Action;
            public int StepCount;

            /// <summary>
            /// Create new action that will execute after a given number of steps.
            /// </summary>
            /// <param name="action"></param>
            /// <param name="stepCount"></param>
            public TimerAction(Action action, int stepCount)
            {
                Action = action;
                StepCount = stepCount;
            }
        }

        public Vector Velocity = new Vector(0, 0);
        public Vector Position;
        public Vector Size;
        public string ID;
        public bool Interactable = false;
        public Vector InteractPoint;
        public Action<Entity, Entity> InteractAction;
        public int ZLevel = 0;
        public bool LockZLevel = false;
        public int CopyNum = 0;
        public string TextureKey { get; set; }
        public Animation Animation { get; set; }

        private FloatRect _maskRect;
        protected int _stepCountMask = -1;
        public FloatRect NewMaskRect;
        private bool _mask = false;
        public FloatRect MaskRect { get { return _maskRect; } set { _maskRect = value; _mask = true; } }

        protected int _stepCountMove = -1;
        public Vector Destination;

        private List<TimerAction> _timers;


        /// <summary>
        /// Create Entity with given ID and size
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="size"></param>
        public Entity(string ID, Vector size)
        {
            this.ID = ID;
            Position = new Vector(0, 0);
            Size = size;
            _timers = new List<TimerAction>();
        }

        public Entity()
        {
            ID = "Default";
            Position = new Vector (0, 0);
            Size = new Vector(0, 0);
            _timers = new List<TimerAction>();
        }

        public virtual Entity Copy()
        {
            Entity copy = (Entity)MemberwiseClone();
            copy.Position = new Vector(Position.X, Position.Y);
            copy.Size = new Vector(Size.X, Size.Y);
            if (Animation != null)
            {
                copy.Animation = Animation.Copy();
            }
            if (Interactable)
            {
                copy.InteractPoint = new Vector(InteractPoint.X, InteractPoint.Y);
                copy.InteractAction = InteractAction;
            }
            copy._timers = new List<TimerAction>();
            foreach (var timer in _timers)
            {
                copy._timers.Add(timer);
            }
            return copy;
        }

        public virtual Renderable Draw()
        {
            if (TextureKey != null)
            {
                Sprite sprite = new Sprite(TextureLibrary.Textures[TextureKey])
                {
                    Position = new SFML.Window.Vector2f(GetXPosition(), GetYPosition())
                };
                if (_mask)
                {
                    sprite.TextureRect = new IntRect ((int)MaskRect.Left, (int)MaskRect.Top, (int)MaskRect.Width, (int)MaskRect.Height);
                }
                return new Renderable(sprite);
            }
            return new Renderable(null);
        }

        public void InitializeInteraction(Vector location, Action<Entity, Entity> action)
        {
            InteractPoint = location;
            InteractAction = action;
            Interactable = true;
        }

        public virtual void Step()
        {
            if (!LockZLevel)
                ZLevel = (int)(Position.Y + Size.Y);

            if (_stepCountMove > 0)
            {
                Vector difference = Destination - Position;
                Velocity = difference / _stepCountMove;
                _stepCountMove--;
            }
            else if (_stepCountMove == 0)
            {
                Velocity *= 0;
                _stepCountMove--;
            }

            if (_stepCountMask > 0)
            {
                MaskRect = RectInterpolate(MaskRect, NewMaskRect, _stepCountMask);
                _stepCountMask--;
            }

            SetPosition(Position + Velocity);
            if (Animation != null)
            {
                TextureKey = Animation.Step();
            }
            for (int i = _timers.Count - 1; i >= 0; i--)
            {
                if(_timers[i].StepCount == 0)
                {
                    _timers[i].Action();
                    _timers.RemoveAt(i);
                }
                else
                {
                    _timers[i].StepCount--;
                }
            }
        }

        public virtual void CreateTimer(Action action, int numSteps)
        {
            TimerAction newTimer = new TimerAction(action, numSteps);
            _timers.Add(newTimer);
        }

        public virtual void TransformMove(Vector destination, int numSteps)
        {
            _stepCountMove = numSteps;
            Destination = destination;
        }

        public virtual void TransformMask(FloatRect newMaskRect, int numSteps)
        {
            _stepCountMask = numSteps;
            NewMaskRect = newMaskRect;
        }

        // Helper Methods
        public FloatRect RectInterpolate(FloatRect current, FloatRect target, int steps)
        {
            float newLeft = current.Left + (target.Left - current.Left) / steps;
            float newTop = current.Top + (target.Top - current.Top) / steps;
            float newWidth = (current.Left + current.Width + (target.Left + target.Width - current.Left - current.Width) / steps) - newLeft;
            float newHeight = (current.Top + current.Height + (target.Top + target.Height - current.Top - current.Height) / steps) - newTop;
            return new FloatRect(newLeft, newTop, newWidth, newHeight);
        }

        // Getter Methods

        public virtual Vector GetPosition() => Position;

        public virtual int GetXPosition()
        {
            return (int)Position.X;
        }

        public virtual int GetYPosition()
        {
            return (int)Position.Y;
        }

        public virtual int GetWidth()
        {
            return (int) Size.X;
        }

        public virtual int GetHeight()
        {
            return (int) Size.Y;
        }

        public virtual int GetZLevel()
        {
            return ZLevel;
        }

        public virtual String GetID()
        {
            return ID;
        }

        // Setter Methods

        public virtual void SetPosition(Vector position)
        {
            Position = position;
        }

        public virtual void SetZLevel(int z)
        {
            LockZLevel = true;
            ZLevel = z;
        }

        public virtual void SetID(String ID)
        {
            this.ID = ID;
        }
    }
}
