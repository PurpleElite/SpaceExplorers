using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML;
using SFML.Window;
using SFML.Graphics;
using SFML.Audio;
using System.Windows.Input;

namespace SpaceExplorers
{
    class Program
    {
        //Controller to track key bindings and inputs
        static Controller controller = new Controller();

        static void Main(string[] args)
        {
            // Create the application window.
            RenderWindow window = new RenderWindow(new VideoMode(960, 540), "Space Explorers");

            // Here we assign a callback to the window close button.
            window.Closed += Window_Closed;
            //Callbacks for keyboard presses
            window.KeyPressed += Window_KeyPressed;
            window.KeyReleased += Window_KeyReleased;

            //Make it so that holding down a key does not rapidly repeat it
            window.SetKeyRepeatEnabled(false);

            // Here we lock the refresh rate to 60 fps.
            window.SetFramerateLimit(60);

            //Create the View
            View defaultView = new View(new Vector2f(960, 540), new Vector2f(960, 540));
            //defaultView.Size = new Vector2f(960, 540);
            defaultView.Zoom(0.5f);
            Camera defaultCamera = new Camera(defaultView);

            //Create the Room
            Room defaultRoom = new Room(1000, 1000, defaultCamera);

            //Create New MapObjects and add them to the room
            ObjectLibrary.initialize();
            defaultRoom.objectList.Add(ObjectLibrary.Objects["Background"]);
            defaultRoom.objectList.Add(ObjectLibrary.Objects["DebugBox"]);
            defaultRoom.objectList.Add(ObjectLibrary.Objects["DebugCube"]);
            defaultRoom.objectList.Add(ObjectLibrary.Objects["DebugAngleCube"]);
            Character Jacob = (Character)ObjectLibrary.Objects["Jacob"];
            defaultRoom.objectList.Add(Jacob);
            controller.Set_Player(Jacob);
            defaultCamera.Set_Focus(Jacob);

            // Load in the music. Only do this once as well.
            //Sound Music = new Sound(new SoundBuffer("Sound\\blahblah.ogg"));
            // Play the music!
            //Music.Play();

            // This is the main loop, all the game logic and drawing goes on in here.
            while (window.IsOpen())
            {
                // This thing checks for any user input. If we didn't call it then our window would be frozen.
                window.DispatchEvents();

                // Aww yes, hot pink clear color.
                window.Clear(new Color(255, 180, 200));

                // Get the position of the mouse pointer.
                //Vector2i mousePosition = window.InternalGetMousePosition();

                // Here we iterate through the contents of objectList and update/draw them
                defaultRoom.Step();
                window.SetView(defaultView);
                foreach (Sprite sprite in defaultRoom.RenderList())
                {
                    if (sprite != null)
                    {
                        //sprite.Position = sprite.Position * 2 - defaultCamera.Size/2;
                        //sprite.Scale = new Vector2f(2,2);
                        window.Draw(sprite);
                    }
                }

                // And then we display everything we drew
                window.Display();
            }

            return;
        }

        private static void Window_KeyReleased(object sender, KeyEventArgs e)
        {
            controller.Key_Release(e.Code.ToString());
        }

        private static void Window_KeyPressed(object sender, KeyEventArgs e)
        {
            controller.Key_Press(e.Code.ToString());
        }

        private static void Window_Closed(object sender, EventArgs e)
        {
            ((Window)sender).Close();
        }
    }
}
