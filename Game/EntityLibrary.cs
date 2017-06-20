using System;
using System.Collections.Generic;
using SFML.Graphics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceExplorers
{
    static class EntityLibrary
    {
        public static Dictionary<string, Entity> Entities = new Dictionary<string, Entity>();

        public static void Initialize()
        {
            TextureLibrary.Textures.Add("DebugBack.png", new Texture(new Image("Images\\DebugBack.png")));
            RoomEntity Background = new RoomEntity("Background", new Vector(0, 0), new int[] { 1000, 1000 }, "DebugBack.png");
            Background.SetZLevel(0);
            Entities.Add(Background.GetID(), Background);

            Polygon boundsDebugCube = new Polygon();
            boundsDebugCube.Points.Add(new Vector(1, 126));
            boundsDebugCube.Points.Add(new Vector(152, 126));
            boundsDebugCube.Points.Add(new Vector(152, 226));
            boundsDebugCube.Points.Add(new Vector(1, 226));
            boundsDebugCube.BuildEdges();
            TextureLibrary.Textures.Add("DebugCube.png", new Texture(new Image("Images\\DebugCube.png")));
            RoomEntity DebugCube = new RoomEntity("DebugCube", new Vector(250, 500), new int[] { 152, 226 }, "DebugCube.png");
            DebugCube.SetCollisionBounds(boundsDebugCube);
            Entities.Add(DebugCube.GetID(), DebugCube);

            Polygon boundsDebugBox = new Polygon();
            boundsDebugBox.Points.Add(new Vector(1, 50));
            boundsDebugBox.Points.Add(new Vector(52, 50));
            boundsDebugBox.Points.Add(new Vector(52, 95));
            boundsDebugBox.Points.Add(new Vector(1, 95));
            boundsDebugBox.BuildEdges();
            TextureLibrary.Textures.Add("DebugBox.png", new Texture(new Image("Images\\DebugBox.png")));
            RoomEntity DebugBox = new RoomEntity("DebugBox", new Vector(500, 500), new int[] { 52, 95 }, "DebugBox.png");
            DebugBox.SetCollisionBounds(boundsDebugBox);
            Entities.Add(DebugBox.GetID(), DebugBox);

            Polygon boundsDebugAngleCube = new Polygon();
            boundsDebugAngleCube.Points.Add(new Vector(93, 89));
            boundsDebugAngleCube.Points.Add(new Vector(185, 128));
            boundsDebugAngleCube.Points.Add(new Vector(93, 181));
            boundsDebugAngleCube.Points.Add(new Vector(1, 128));
            boundsDebugAngleCube.BuildEdges();
            TextureLibrary.Textures.Add("DebugAngleCube.png", new Texture(new Image("Images\\DebugAngleCube.png")));
            RoomEntity DebugAngleCube = new RoomEntity("DebugAngleCube", new Vector(400, 150), new int[] { 185, 181 }, "DebugAngleCube.png");
            DebugAngleCube.SetCollisionBounds(boundsDebugAngleCube);
            Entities.Add(DebugAngleCube.GetID(), DebugAngleCube);

            Polygon collisionBounds1 = new Polygon();
            collisionBounds1.Points.Add(new Vector(12, 111));
            collisionBounds1.Points.Add(new Vector(144, 111));
            collisionBounds1.Points.Add(new Vector(144, 158));
            collisionBounds1.Points.Add(new Vector(12, 158));
            collisionBounds1.BuildEdges();
            TextureLibrary.Textures.Add("Mittens.png", new Texture(new Image("Images\\Mittens.png")));
            RoomEntity Mittens = new RoomEntity("Mittens", new Vector(0, (float)0.01), new Vector(400, 300), new int[] { 166, 158 }, "Mittens.png");
            Mittens.SetCollisionBounds(collisionBounds1);
            Entities.Add(Mittens.GetID(), Mittens);

            Polygon collisionBounds2 = new Polygon();
            collisionBounds2.Points.Add(new Vector(17, 43));
            collisionBounds2.Points.Add(new Vector(33, 43));
            collisionBounds2.Points.Add(new Vector(33, 49));
            collisionBounds2.Points.Add(new Vector(17, 49));
            collisionBounds2.BuildEdges();
            TextureLibrary.Textures.Add("Cpt JAstra.png", new Texture(new Image("Images\\Cpt JAstra.png")));
            TextureLibrary.Textures.Add("Cpt JAstra portrait.png", new Texture(new Image("Images\\Cpt JAstra portrait.png")));
            Actor MittensFrend = new Actor("Jacob", new Vector(200, 300), new int[] { 50, 50 }, "Cpt JAstra.png", "Cpt JAstra portrait.png", (float)2);
            MittensFrend.SetCollisionBounds(collisionBounds2);
            Entities.Add(MittensFrend.GetID(), MittensFrend);

            Polygon collisionBoundsBreech = new Polygon();
            collisionBoundsBreech.Points.Add(new Vector(20, 44));
            collisionBoundsBreech.Points.Add(new Vector(32, 44));
            collisionBoundsBreech.Points.Add(new Vector(32, 50));
            collisionBoundsBreech.Points.Add(new Vector(20, 50));
            collisionBoundsBreech.BuildEdges();
            TextureLibrary.Textures.Add("Sgt JBreech.png", new Texture(new Image("Images\\Sgt JBreech.png")));
            TextureLibrary.Textures.Add("Sgt JBreech portrait.png", new Texture(new Image("Images\\Sgt JBreech portrait.png")));
            Actor JBreech = new Actor("JBreech", new Vector(250, 300), new int[] { 50, 50 }, "Sgt JBreech.png", "Sgt JBreech portrait.png", (float)2);
            JBreech.SetCollisionBounds(collisionBoundsBreech);
            Entities.Add(JBreech.GetID(), JBreech);

            TextureLibrary.Textures.Add("DialogueBoxWIP.png", new Texture(new Image("Images\\DialogueBoxWIP.png")));
            MenuDialogue DialogueBox = new MenuDialogue("DialogueBox", new Vector(90, 150), new int[] { 300, 100 }, "DialogueBoxWIP.png");
            Entities.Add(DialogueBox.GetID(), DialogueBox);
        }
    }
}
