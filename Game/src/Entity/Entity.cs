using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceExplorers
{
    public class Entity : IRenderable
    {
        private class TimerAction
        {
            public Action Action;
            public int StepCount;

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

        protected int _stepCount = -1;
        public Vector Destination;

        private List<TimerAction> _timers;


        // Constructors

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
                Sprite sprite = new Sprite(TextureLibrary.Textures[TextureKey]);
                sprite.Position = new SFML.Window.Vector2f(GetXPosition(), GetYPosition());
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
            if (_stepCount > 0)
            {
                Vector difference = Destination - Position;
                Velocity = difference / _stepCount;
                _stepCount--;
            }
            else if (_stepCount == 0)
            {
                Velocity *= 0;
                _stepCount--;
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
            _stepCount = numSteps;
            Destination = destination;
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
