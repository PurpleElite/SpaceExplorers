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
            RenderWindow window = new RenderWindow(new VideoMode(800, 600), "Blah blahblah blahblah blah blahblahb blahblahblah DU du dudu du du dudu du DU");

            // Here we assign a callback to the window close button.
            window.Closed += Window_Closed;
            //Callbacks for keyboard presses
            window.KeyPressed += Window_KeyPressed;
            window.KeyReleased += Window_KeyReleased;

            //Make it so that holding down a key does not rapidly repeat it
            window.SetKeyRepeatEnabled(false);

            // Here we lock the refresh rate to 60 fps.
            window.SetFramerateLimit(60);

            //Create the Camera
            Camera defaultCamera = new Camera(800, 600);

            //Create the Room
            Room defaultRoom = new Room(2000, 2000, defaultCamera);

            //Create 2 rectangular Polygons used for collision detection
            Polygon collisionBounds1 = new Polygon();
            collisionBounds1.Points.Add(new Vector(12, 111));
            collisionBounds1.Points.Add(new Vector(144, 111));
            collisionBounds1.Points.Add(new Vector(144, 158));
            collisionBounds1.Points.Add(new Vector(12, 158));
            collisionBounds1.BuildEdges();

            Polygon collisionBounds2 = new Polygon();
            collisionBounds2.Points.Add(new Vector(17, 43));
            collisionBounds2.Points.Add(new Vector(33, 43));
            collisionBounds2.Points.Add(new Vector(33, 49));
            collisionBounds2.Points.Add(new Vector(17, 49));
            collisionBounds2.BuildEdges();

            //Create New MapObjects and add them to the room
            TextureLibrary.Textures.Add("Hub7Day.png", new Texture(new Image("Images\\Hub7Day.png")));
            MapObject Background = new MapObject("Background", new Vector(0, 0), new int[] { 2000, 1000 }, "Hub7Day.png");
            Background.SetZLevel(0);
            defaultRoom.objectList.Add(Background);

            TextureLibrary.Textures.Add("Mittens.png", new Texture(new Image("Images\\Mittens.png")));
            MapObject Mittens = new MapObject("Mittens1", new Vector(0, (float) 0.01), new Vector(400, 300), new int[] { 166, 158 }, "Mittens.png");
            Mittens.SetCollisionBounds(collisionBounds1);
            defaultRoom.objectList.Add(Mittens);

            TextureLibrary.Textures.Add("Cpt JAstra.png", new Texture(new Image("Images\\Cpt JAstra.png")));
            Character MittensFrend = new Character("Jacob", new Vector(200, 300), new int[] { 50, 50 }, "Cpt JAstra.png", (float)2);
            MittensFrend.SetCollisionBounds(collisionBounds2);
            defaultRoom.objectList.Add(MittensFrend);
            controller.Set_Player(MittensFrend);
            defaultCamera.Set_Focus(MittensFrend);

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
                foreach (Sprite sprite in defaultRoom.RenderList())
                {
                    if (sprite != null)
                    {
                        sprite.Position = sprite.Position * 2 - defaultCamera.Size / 2;
                        sprite.Scale = new Vector2f(2,2);
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
            Console.WriteLine("Released " + e.Code);
            controller.Key_Release(e.Code.ToString());
        }

        private static void Window_KeyPressed(object sender, KeyEventArgs e)
        {
            Console.WriteLine("Pressed " + e.Code);
            controller.Key_Press(e.Code.ToString());
        }

        private static void Window_Closed(object sender, EventArgs e)
        {
            ((Window)sender).Close();
        }
    }
}
