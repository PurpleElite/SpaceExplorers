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
        public static Controller controller = new Controller();
        static Vector2u windowDim = new Vector2u(960, 540);
        public static Room ActiveRoom;
        public static Hud ActiveHud;
        public static DialogueEngine DialogueEngine;

        static void Main(string[] args)
        {
            // Create the application window.
            RenderWindow window = new RenderWindow(new VideoMode(windowDim.X, windowDim.Y), "Space Explorers");

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
            View defaultView = new View(new Vector2f(windowDim.X, windowDim.Y), new Vector2f(windowDim.X, windowDim.Y));
            defaultView.Zoom(0.5f);
            Camera defaultCamera = new Camera(defaultView);

            //Create the Room
            ActiveRoom = new Room(1000, 1000, defaultCamera);
            controller.Set_Room(ActiveRoom);

            //Create the Hud
            ActiveHud = new Hud(windowDim);

            //Create New Mapentitys and add them to the room
            EntityLibrary.Initialize();
            ActiveRoom.entityList.Add((RoomEntity) EntityLibrary.Entities["Background"]);
            ActiveRoom.entityList.Add((RoomEntity)EntityLibrary.Entities["DebugBox"]);
            ActiveRoom.entityList.Add((RoomEntity)EntityLibrary.Entities["DebugCube"]);
            ActiveRoom.entityList.Add((RoomEntity)EntityLibrary.Entities["DebugAngleCube"]);
            Actor Jacob = (Actor)EntityLibrary.Entities["Jacob"];
            ActiveRoom.entityList.Add(Jacob);
            controller.Set_Control(Jacob);
            defaultCamera.Set_Focus(Jacob);
            Actor JBreech = (Actor)EntityLibrary.Entities["JBreech"];
            Action<Entity, Entity> dialogue = (char1, char2) => DialogueEngine.RunDialogue(char1, char2);
            JBreech.InitializeInteraction(26, 47, dialogue);
            ActiveRoom.entityList.Add(JBreech);

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

                // Here we iterate through the contents of the room and the hud and update/draw them
                ActiveRoom.Step();
                window.SetView(defaultView);
                foreach (Sprite sprite in ActiveRoom.RenderList())
                {
                    if (sprite != null)
                    {
                        window.Draw(sprite);
                    }
                }
                foreach (Sprite sprite in ActiveHud.RenderList())
                {
                    if (sprite != null)
                    {
                        sprite.Position += window.GetView().Center - window.GetView().Size/2;
                        window.Draw(sprite);
                    }
                }

                // And then we display everything we drew
                window.Display();
            }

            return;
        }

        private static void Window_KeyReleased(Object sender, KeyEventArgs e)
        {
            controller.Key_Release(e.Code.ToString());
        }

        private static void Window_KeyPressed(Object sender, KeyEventArgs e)
        {
            controller.Key_Press(e.Code.ToString());
        }

        private static void Window_Closed(Object sender, EventArgs e)
        {
            ((Window)sender).Close();
        }
    }
}
