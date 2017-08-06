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
            RoomEntity Background = new RoomEntity("Background", new Vector( 1000, 1000 ), "DebugBack.png");
            Background.SetZLevel(0);
            Entities.Add(Background.GetID(), Background);

            Polygon boundsDebugCube = new Polygon();
            boundsDebugCube.Points.Add(new Vector(1, 126));
            boundsDebugCube.Points.Add(new Vector(152, 126));
            boundsDebugCube.Points.Add(new Vector(152, 226));
            boundsDebugCube.Points.Add(new Vector(1, 226));
            boundsDebugCube.BuildEdges();
            TextureLibrary.Textures.Add("DebugCube.png", new Texture(new Image("Images\\DebugCube.png")));
            RoomEntity DebugCube = new RoomEntity("DebugCube", new Vector (152, 226), "DebugCube.png");
            DebugCube.SetCollisionBounds(boundsDebugCube);
            Entities.Add(DebugCube.GetID(), DebugCube);

            Polygon boundsDebugBox = new Polygon();
            boundsDebugBox.Points.Add(new Vector(1, 50));
            boundsDebugBox.Points.Add(new Vector(52, 50));
            boundsDebugBox.Points.Add(new Vector(52, 95));
            boundsDebugBox.Points.Add(new Vector(1, 95));
            boundsDebugBox.BuildEdges();
            TextureLibrary.Textures.Add("DebugBox.png", new Texture(new Image("Images\\DebugBox.png")));
            RoomEntity DebugBox = new RoomEntity("DebugBox", new Vector (52, 95), "DebugBox.png");
            DebugBox.SetCollisionBounds(boundsDebugBox);
            Entities.Add(DebugBox.GetID(), DebugBox);

            Polygon boundsDebugAngleCube = new Polygon();
            boundsDebugAngleCube.Points.Add(new Vector(93, 89));
            boundsDebugAngleCube.Points.Add(new Vector(185, 128));
            boundsDebugAngleCube.Points.Add(new Vector(93, 181));
            boundsDebugAngleCube.Points.Add(new Vector(1, 128));
            boundsDebugAngleCube.BuildEdges();
            TextureLibrary.Textures.Add("DebugAngleCube.png", new Texture(new Image("Images\\DebugAngleCube.png")));
            RoomEntity DebugAngleCube = new RoomEntity("DebugAngleCube", new Vector(185, 181), "DebugAngleCube.png");
            DebugAngleCube.SetCollisionBounds(boundsDebugAngleCube);
            Entities.Add(DebugAngleCube.GetID(), DebugAngleCube);

            Polygon collisionBounds1 = new Polygon();
            collisionBounds1.Points.Add(new Vector(12, 111));
            collisionBounds1.Points.Add(new Vector(144, 111));
            collisionBounds1.Points.Add(new Vector(144, 158));
            collisionBounds1.Points.Add(new Vector(12, 158));
            collisionBounds1.BuildEdges();
            TextureLibrary.Textures.Add("Mittens.png", new Texture(new Image("Images\\Mittens.png")));
            RoomEntity Mittens = new RoomEntity("Mittens", new Vector (166, 158), "Mittens.png");
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
            Actor JAstra = new Actor("Jacob", "Jacob Astra", new Vector (50, 50), "Cpt JAstra.png", "Cpt JAstra portrait.png", 2);
            JAstra.SetCollisionBounds(collisionBounds2);
            Entities.Add(JAstra.GetID(), JAstra);

            Polygon collisionBoundsHavisham = new Polygon();
            collisionBoundsHavisham.Points.Add(new Vector(17, 43));
            collisionBoundsHavisham.Points.Add(new Vector(33, 43));
            collisionBoundsHavisham.Points.Add(new Vector(33, 49));
            collisionBoundsHavisham.Points.Add(new Vector(17, 49));
            collisionBoundsHavisham.BuildEdges();
            TextureLibrary.Textures.Add("WDT AHavisham Poncho.png", new Texture(new Image("Images\\WDT AHavisham Poncho.png")));
            TextureLibrary.Textures.Add("WDT AHavisham Portrait.png", new Texture(new Image("Images\\WDT AHavisham Portrait.png")));
            Actor AHavisham = new Actor("AHavisham", "Alvis Havisham", new Vector(50, 50), "WDT AHavisham Poncho.png", "WDT AHavisham Portrait.png", 1.5f);
            AHavisham.AddAnimation(AnimType.RunE, AnimationLibrary.Create("HavishamRunE"));
            AHavisham.AddAnimation(AnimType.RunNE, AnimationLibrary.Create("HavishamRunNE"));
            AHavisham.AddAnimation(AnimType.RunN, AnimationLibrary.Create("HavishamRunN"));
            AHavisham.AddAnimation(AnimType.RunNW, AnimationLibrary.Create("HavishamRunNW"));
            AHavisham.AddAnimation(AnimType.RunW, AnimationLibrary.Create("HavishamRunW"));
            AHavisham.AddAnimation(AnimType.RunSW, AnimationLibrary.Create("HavishamRunSW"));
            AHavisham.AddAnimation(AnimType.RunS, AnimationLibrary.Create("HavishamRunS"));
            AHavisham.AddAnimation(AnimType.RunSE, AnimationLibrary.Create("HavishamRunSE"));
            AHavisham.SetCollisionBounds(collisionBoundsHavisham);
            Entities.Add(AHavisham.GetID(), AHavisham);

            Polygon collisionBoundsBreech = new Polygon();
            collisionBoundsBreech.Points.Add(new Vector(20, 44));
            collisionBoundsBreech.Points.Add(new Vector(32, 44));
            collisionBoundsBreech.Points.Add(new Vector(32, 50));
            collisionBoundsBreech.Points.Add(new Vector(20, 50));
            collisionBoundsBreech.BuildEdges();
            TextureLibrary.Textures.Add("Sgt JBreech.png", new Texture(new Image("Images\\Sgt JBreech.png")));
            TextureLibrary.Textures.Add("Sgt JBreech portrait.png", new Texture(new Image("Images\\Sgt JBreech portrait.png")));
            Actor JBreech = new Actor("JBreech", "Jonathan Breech", new Vector(50, 50), "Sgt JBreech.png", "Sgt JBreech portrait.png", 2);
            JBreech.AddAnimation(AnimType.Idle, AnimationLibrary.Create("BreechWind"));
            JBreech.SetCollisionBounds(collisionBoundsBreech);
            Entities.Add(JBreech.GetID(), JBreech);

            TextureLibrary.Textures.Add("DialogueBox.png", new Texture(new Image("Images\\DialogueBox.png")));
            MenuDialogue DialogueBox = new MenuDialogue("DialogueBox", new Vector(270, 56), "DialogueBox.png");
            Entities.Add(DialogueBox.GetID(), DialogueBox);

            TextureLibrary.Textures.Add("DialoguePortrait.png", new Texture(new Image("Images\\DialoguePortrait.png")));
            HudEntity DialoguePortraitBack = new HudEntity("DialoguePortraitBack", new Vector(48, 56), "DialoguePortrait.png");
            Entities.Add(DialoguePortraitBack.GetID(), DialoguePortraitBack);

            TextureLibrary.Textures.Add("DialogueSelection.png", new Texture(new Image("Images\\DialogueSelection.png")));
            HudEntity DialogueSelection = new HudEntity("DialogueSelection", new Vector(162, 11), "DialogueSelection.png");
            Entities.Add(DialogueSelection.GetID(), DialogueSelection);

            TextureLibrary.Textures.Add("DialogueChoices.png", new Texture(new Image("Images\\DialogueChoices.png")));
            MenuList DialogueChoices = new MenuList("DialogueChoice", new Vector(170, 40), "DialogueChoices.png");
            Entities.Add(DialogueChoices.GetID(), DialogueChoices);
        }

        public static Entity Create(string ID, Vector Position)
        {
            Entity ent;
            ent = Entities.GetOrNull(ID);
            if (ent == null)
            {
                Console.WriteLine("Entity not in library: " + ID);
                return null;
            }
            Entity newEnt = ent.Copy();
            newEnt.SetPosition(Position);
            ent.CopyNum++;
            return newEnt;
        }

        public static Entity Create(string ID)
        {
            Entity ent;
            ent = Entities.GetOrNull(ID);
            if (ent == null)
            {
                Console.WriteLine("Entity not in library: " + ID);
                return null;
            }
            Entity newEnt = ent.Copy();
            ent.CopyNum++;
            return newEnt;
        }
    }
}
