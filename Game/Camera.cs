using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceExplorers
{
    class Camera
    {
        //Camera Position
        public Vector2f Position;
        //Size of the window
        public Vector2f Size;
        //Conditions
        bool track;
        //Target of tracking
        MapObject focus;

        public Camera (int x, int y, int width, int height)
        {
            Position = new Vector2f(x,y);
            Size = new Vector2f(width, height);
            track = false;
        }

        public Camera(int width, int height)
        {
            Position = new Vector2f(0,0);
            Size = new Vector2f(width, height);
        }

        public void Center(int centerX, int centerY)
        {
            Position = new Vector2f(centerX - Size.X / 2, centerY - Size.Y / 2);
        }

        public void Set_Focus(MapObject obj)
        {
            track = true;
            focus = obj;
        }

        public void Step()
        {
            if (track)
                Center(focus.GetXPosition() + focus.GetWidth()/2, focus.GetYPosition() + focus.GetHeight()/2);
        }
    }
}
