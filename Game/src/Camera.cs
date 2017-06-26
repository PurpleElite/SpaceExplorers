using SFML.Window;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceExplorers
{
    class Camera
    {
        //View
        View view;
        //Size of the containing Room
        public Vector2f Bounds;
        //Conditions
        bool track;
        //Target of tracking
        RoomEntity focus;

        public Camera (View view)
        {
            this.view = view;
            track = false;
            Bounds = new Vector2f(0, 0);
        }

        public void Center(int centerX, int centerY)
        {
            //Check to make sure the camera doesn't go out of bounds
            if (Bounds.X > 0)
                if (centerX - view.Size.X / 2 < 0) centerX = (int)(view.Size.X / 2);
                else if (centerX + view.Size.X / 2 > Bounds.X) centerX = (int)(Bounds.X - view.Size.X / 2);
            if (Bounds.Y > 0)
                if (centerY - view.Size.Y / 2 < 0) centerY = (int)(view.Size.Y / 2);
                else if (centerY + view.Size.Y / 2 > Bounds.Y) centerY = (int)(Bounds.Y - view.Size.Y / 2);
            //Center the view
            view.Center = new Vector2f(centerX, centerY);
        }

        public void Set_Focus(RoomEntity obj)
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
