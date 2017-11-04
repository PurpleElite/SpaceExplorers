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
using System.IO;

namespace SpaceExplorers
{
    class Program
    {
        //Controller to track key bindings and inputs
        public static Controller Controller = new Controller();
        static Vector2u windowDim = new Vector2u(960, 540);
        public static Room ActiveRoom;
        public static Hud ActiveHud;
        public static DialogueEngine DialogueEngine;
        private static Queue<Sound> soundQueue = new Queue<Sound>();

        static void Main(string[] args)
        {

            //Create the View
            View defaultView = new View(new Vector2f(windowDim.X, windowDim.Y), new Vector2f(windowDim.X, windowDim.Y));
            defaultView.Zoom(0.5f);
            Camera defaultCamera = new Camera(defaultView);

            //Create the Room
            ActiveRoom = new Room(2000, 1000, defaultCamera);
            Controller.Set_Room(ActiveRoom);

            //Create the Hud
            ActiveHud = new Hud(windowDim);

            //Initalize Fonts
            FontLibrary.Initialize();

            //Intialize Animations
            AnimationLibrary.Initialize();

            //Initialize Entities
            EntityLibrary.Initialize();

            //Initialize Sounds
            SoundLibrary.Initialize();

            //Create Dialogue Engine
            DialogueEngine = new DialogueEngine();
            DialogueLibrary.Initialize();

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

            //Create New Mapentitys and add them to the room
            ActiveRoom.EntityList.Add((RoomEntity)EntityLibrary.Create("Background"));
            ActiveRoom.EntityList.Add((RoomEntity)EntityLibrary.Create("RiverBounds", new Vector(0, 0)));
            ActiveRoom.EntityList.Add((RoomEntity)EntityLibrary.Create("VertMapBoundary", new Vector(-1, 0)));
            ActiveRoom.EntityList.Add((RoomEntity)EntityLibrary.Create("Rock1", new Vector(88, 509)));
            ActiveRoom.EntityList.Add((RoomEntity)EntityLibrary.Create("Rock2", new Vector(61, 507)));
            ActiveRoom.EntityList.Add((RoomEntity)EntityLibrary.Create("Rock3", new Vector(207, 587)));
            ActiveRoom.EntityList.Add((RoomEntity)EntityLibrary.Create("Rock4", new Vector(370, 284)));
            ActiveRoom.EntityList.Add((RoomEntity)EntityLibrary.Create("Rock5", new Vector(586, 208)));
            ActiveRoom.EntityList.Add((RoomEntity)EntityLibrary.Create("Rock6", new Vector(633, 195)));
            ActiveRoom.EntityList.Add((RoomEntity)EntityLibrary.Create("Rock7", new Vector(918, 393)));
            ActiveRoom.EntityList.Add((RoomEntity)EntityLibrary.Create("Rock8", new Vector(869, 373)));
            ActiveRoom.EntityList.Add((RoomEntity)EntityLibrary.Create("Rock9", new Vector(858, 601)));
            ActiveRoom.EntityList.Add((RoomEntity)EntityLibrary.Create("Rock10", new Vector(812, 601)));
            ActiveRoom.EntityList.Add((RoomEntity)EntityLibrary.Create("Rock11", new Vector(617, 680)));
            ActiveRoom.EntityList.Add((RoomEntity)EntityLibrary.Create("Bush1", new Vector(31, 546)));
            ActiveRoom.EntityList.Add((RoomEntity)EntityLibrary.Create("Bush1", new Vector(-14, 280)));
            ActiveRoom.EntityList.Add((RoomEntity)EntityLibrary.Create("Bush1", new Vector(1497, 568)));
            ActiveRoom.EntityList.Add((RoomEntity)EntityLibrary.Create("Bush2", new Vector(44, 392)));
            ActiveRoom.EntityList.Add((RoomEntity)EntityLibrary.Create("Bush2", new Vector(148, 780)));
            ActiveRoom.EntityList.Add((RoomEntity)EntityLibrary.Create("Bush2", new Vector(1696, 394)));
            ActiveRoom.EntityList.Add((RoomEntity)EntityLibrary.Create("Bush3", new Vector(1497, 622)));
            ActiveRoom.EntityList.Add((RoomEntity)EntityLibrary.Create("Bush4", new Vector(1585, 602)));
            ActiveRoom.EntityList.Add((RoomEntity)EntityLibrary.Create("Tree1", new Vector(536, 523)));
            ActiveRoom.EntityList.Add((RoomEntity)EntityLibrary.Create("Tree2", new Vector(79, 376)));
            ActiveRoom.EntityList.Add((RoomEntity)EntityLibrary.Create("Tree3", new Vector(957, 172)));
            ActiveRoom.EntityList.Add((RoomEntity)EntityLibrary.Create("TreesBack", new Vector(0, 0)));
            ActiveRoom.EntityList.Add((RoomEntity)EntityLibrary.Create("TreesFore", new Vector(0, 400)));
            ActiveRoom.EntityList.Add((RoomEntity)EntityLibrary.Create("BeaconLightRadar", new Vector(962, 235)));
            ActiveRoom.EntityList.Add((RoomEntity)EntityLibrary.Create("DirtForeBeacon", new Vector(1027, 528)));
            ActiveRoom.EntityList.Add((RoomEntity)EntityLibrary.Create("DirtForeBeacon2", new Vector(1234, 429)));
            ActiveRoom.EntityList.Add((RoomEntity)EntityLibrary.Create("Garden", new Vector(544, 307)));
            ActiveRoom.EntityList.Add((RoomEntity)EntityLibrary.Create("Plants", new Vector(546, 295)));
            ActiveRoom.EntityList.Add((RoomEntity)EntityLibrary.Create("Shelter1", new Vector(1178, 554)));
            ActiveRoom.EntityList.Add((RoomEntity)EntityLibrary.Create("Shelter2", new Vector(779, 644)));
            ActiveRoom.EntityList.Add((RoomEntity)EntityLibrary.Create("Shelter3", new Vector(855, 390)));
            ActiveRoom.EntityList.Add((RoomEntity)EntityLibrary.Create("Shelter4", new Vector(690, 506)));
            ActiveRoom.EntityList.Add((RoomEntity)EntityLibrary.Create("Shelter5", new Vector(486, 600)));
            ActiveRoom.EntityList.Add((RoomEntity)EntityLibrary.Create("Shelter6", new Vector(483, 746)));
            ActiveRoom.EntityList.Add((RoomEntity)EntityLibrary.Create("Shelter7", new Vector(281, 694)));
            ActiveRoom.EntityList.Add((RoomEntity)EntityLibrary.Create("Shelter8", new Vector(187, 251)));
            ActiveRoom.EntityList.Add((RoomEntity)EntityLibrary.Create("Sawmill", new Vector(1323, 442)));
            ActiveRoom.EntityList.Add((RoomEntity)EntityLibrary.Create("ClothingLine", new Vector(1041, 123)));
            ActiveRoom.EntityList.Add((RoomEntity)EntityLibrary.Create("CargoMod", new Vector(751, 60)));
            ActiveRoom.EntityList.Add((RoomEntity)EntityLibrary.Create("CryoMod", new Vector(503, 66)));
            ActiveRoom.EntityList.Add((RoomEntity)EntityLibrary.Create("MedMod", new Vector(1476, 302)));
            ActiveRoom.EntityList.Add((RoomEntity)EntityLibrary.Create("NuclearMod", new Vector(303, 315)));
            ActiveRoom.EntityList.Add((RoomEntity)EntityLibrary.Create("NuclearBeaconWire", new Vector(448, 494)));
            Actor AHavisham = (Actor)EntityLibrary.Create("AHavisham", new Vector(984, 612));
            AHavisham.InteractPoint = new Vector(25, 47);
            ActiveRoom.EntityList.Add(AHavisham);
            Controller.Set_Control(AHavisham);
            defaultCamera.Set_Focus(AHavisham);
            Actor JBreech = (Actor)EntityLibrary.Create("JBreech", new Vector(257, 609));
            Action<Entity, Entity> dialogue = (char1, char2) => DialogueEngine.RunDialogue((Actor)char1, (Actor)char2);
            JBreech.InitializeInteraction(dialogue);
            JBreech.InteractPoint = new Vector(26, 47);
            ActiveRoom.EntityList.Add(JBreech);
            Actor CAraceli = (Actor)EntityLibrary.Create("CAraceli", new Vector(273, 592));
            CAraceli.InitializeInteraction(dialogue);
            CAraceli.InteractPoint = new Vector(26, 47);
            ActiveRoom.EntityList.Add(CAraceli);
            Actor EGottfried = (Actor)EntityLibrary.Create("EGottfried", new Vector(1180, 635));
            EGottfried.InitializeInteraction(dialogue);
            EGottfried.InteractPoint = new Vector(26, 47);
            ActiveRoom.EntityList.Add(EGottfried);
            Actor Tel = (Actor)EntityLibrary.Create("Tel", new Vector(793, 733));
            Tel.InitializeInteraction(dialogue);
            Tel.InteractPoint = new Vector(26, 47);
            Tel.SetFacing(180);
            ActiveRoom.EntityList.Add(Tel);
            Actor EDevlin = (Actor)EntityLibrary.Create("EDevlin", new Vector(492, 507));
            EDevlin.InitializeInteraction(dialogue);
            EDevlin.InteractPoint = new Vector(26, 47);
            EDevlin.SetFacing(180);
            ActiveRoom.EntityList.Add(EDevlin);
            Actor JBelmonte = (Actor)EntityLibrary.Create("JBelmonte", new Vector(1289, 475));
            JBelmonte.InitializeInteraction(dialogue);
            JBelmonte.InteractPoint = new Vector(26, 47);
            ActiveRoom.EntityList.Add(JBelmonte);
            Actor ANand = (Actor)EntityLibrary.Create("ANand", new Vector(647, 411));
            ANand.InitializeInteraction(dialogue);
            ANand.InteractPoint = new Vector(26, 47);
            ActiveRoom.EntityList.Add(ANand);
            Actor ARiber = (Actor)EntityLibrary.Create("ARiber", new Vector(686, 695));
            ARiber.InitializeInteraction(dialogue);
            ARiber.InteractPoint = new Vector(29, 44);
            ActiveRoom.EntityList.Add(ARiber);
            Actor JHowie = (Actor)EntityLibrary.Create("JHowie", new Vector(148, 298));
            JHowie.InitializeInteraction(dialogue);
            JHowie.InteractPoint = new Vector(26, 47);
            JHowie.SetFacing(180);
            ActiveRoom.EntityList.Add(JHowie);
            Actor PIrving = (Actor)EntityLibrary.Create("PIrving", new Vector(1105, 518));
            PIrving.InitializeInteraction(dialogue);
            PIrving.InteractPoint = new Vector(26, 47);
            ActiveRoom.EntityList.Add(PIrving);
            Actor Wrat = (Actor)EntityLibrary.Create("Wrat", new Vector(786, 544));
            Wrat.InitializeInteraction(dialogue);
            Wrat.InteractPoint = new Vector(26, 47);
            ActiveRoom.EntityList.Add(Wrat);
            Actor JCollins = (Actor)EntityLibrary.Create("JCollins", new Vector(876, 249));
            JCollins.InitializeInteraction(dialogue);
            JCollins.InteractPoint = new Vector(26, 47);
            ActiveRoom.EntityList.Add(JCollins);
            Actor MCollins = (Actor)EntityLibrary.Create("MCollins", new Vector(87, 505));
            MCollins.InitializeInteraction(dialogue);
            MCollins.InteractPoint = new Vector(26, 47);
            ActiveRoom.EntityList.Add(MCollins);
            Actor AVDoorn = (Actor)EntityLibrary.Create("AVDoorn", new Vector(724, 134));
            AVDoorn.InitializeInteraction(dialogue);
            AVDoorn.InteractPoint = new Vector(26, 47);
            ActiveRoom.EntityList.Add(AVDoorn);
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
                ActiveHud.Step();
                window.SetView(defaultView);
                foreach (Renderable renderable in ActiveRoom.RenderList())
                {
                    if (renderable.sprite != null)
                        window.Draw(renderable.sprite);
                    else if (renderable.text != null)
                        window.Draw(renderable.text);
                }
                foreach (Renderable renderable in ActiveHud.RenderList())
                {
                    if (renderable.sprite != null)
                    {
                        renderable.sprite.Position += window.GetView().Center - window.GetView().Size/2;
                        window.Draw(renderable.sprite);
                    }
                    else if (renderable.text != null)
                    {
                        renderable.text.Position += window.GetView().Center - window.GetView().Size / 2;
                        window.Draw(renderable.text);
                        renderable.text.Position -= window.GetView().Center - window.GetView().Size / 2;
                    }
                }

                // And then we display everything we drew
                window.Display();

                // Now we play our sounds
                while(soundQueue.Count > 0)
                {
                    Sound sound = soundQueue.Dequeue();
                    sound.Play();
                }
            }

            return;
        }

        public static void QueueSound(string soundID)
        {
            Sound newSound = SoundLibrary.Sounds.GetOrNull(soundID);
            if (newSound == null)
            {
                Console.WriteLine("Sound not in library: " + soundID);
                return;
            }
            soundQueue.Enqueue(newSound); 
        }

        private static void Window_KeyReleased(Object sender, KeyEventArgs e)
        {
            Controller.Key_Release(e.Code.ToString());
        }

        private static void Window_KeyPressed(Object sender, KeyEventArgs e)
        {
            Controller.Key_Press(e.Code.ToString());
        }

        private static void Window_Closed(Object sender, EventArgs e)
        {
            ((Window)sender).Close();
        }
    }
}
