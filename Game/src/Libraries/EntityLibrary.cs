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
            TextureLibrary.Textures.Add("Back.png", new Texture(new Image("Images\\Objects\\Back.png")));
            RoomEntity Background = new RoomEntity("Background", new Vector(2000, 1000), "Back.png");
            Background.SetZLevel(0);
            Entities.Add(Background.GetID(), Background);

            TextureLibrary.Textures.Add("DebugBack.png", new Texture(new Image("Images\\DebugBack.png")));
            RoomEntity DebugBackground = new RoomEntity("DebugBackground", new Vector( 1000, 1000 ), "DebugBack.png");
            DebugBackground.SetZLevel(0);
            Entities.Add(Background.GetID(), DebugBackground);

            Polygon boundsBeacon = new Polygon();
            boundsBeacon.Points.Add(new Vector(0, 301));
            boundsBeacon.Points.Add(new Vector(60, 303));
            boundsBeacon.Points.Add(new Vector(70, 310));
            boundsBeacon.Points.Add(new Vector(93, 310));
            boundsBeacon.Points.Add(new Vector(102, 304));
            boundsBeacon.Points.Add(new Vector(173, 307));
            boundsBeacon.Points.Add(new Vector(181, 313));
            boundsBeacon.Points.Add(new Vector(207, 313));
            boundsBeacon.Points.Add(new Vector(217, 308));
            boundsBeacon.Points.Add(new Vector(267, 310));
            boundsBeacon.Points.Add(new Vector(271, 194));
            boundsBeacon.Points.Add(new Vector(4, 187));
            boundsBeacon.BuildEdges();
            TextureLibrary.Textures.Add("BeaconLightRadar.png", new Texture(new Image("Images\\BeaconLightRadar.png")));
            RoomEntity BeaconLightRadar = new RoomEntity("BeaconLightRadar", new Vector(274, 313), "BeaconLightRadar.png");
            BeaconLightRadar.SetCollisionBounds(boundsBeacon);
            BeaconLightRadar.Immobile = true;
            Entities.Add(BeaconLightRadar.GetID(), BeaconLightRadar);

            Polygon boundsBush1 = new Polygon();
            boundsBush1.Points.Add(new Vector(9, 16));
            boundsBush1.Points.Add(new Vector(9, 41));
            boundsBush1.Points.Add(new Vector(58, 41));
            boundsBush1.Points.Add(new Vector(58, 16));
            boundsBush1.BuildEdges();
            TextureLibrary.Textures.Add("Bush1.png", new Texture(new Image("Images\\Bush1.png")));
            RoomEntity Bush1 = new RoomEntity("Bush1", new Vector(63, 42), "Bush1.png");
            Bush1.SetCollisionBounds(boundsBush1);
            Bush1.Immobile = true;
            Entities.Add(Bush1.GetID(), Bush1);

            Polygon boundsBush2 = new Polygon();
            boundsBush2.Points.Add(new Vector(5, 42));
            boundsBush2.Points.Add(new Vector(53, 73));
            boundsBush2.Points.Add(new Vector(96, 56));
            boundsBush2.Points.Add(new Vector(110, 30));
            boundsBush2.Points.Add(new Vector(59, 15));
            boundsBush2.BuildEdges();
            TextureLibrary.Textures.Add("Bush2.png", new Texture(new Image("Images\\Bush2.png")));
            RoomEntity Bush2 = new RoomEntity("Bush2", new Vector(110, 73), "Bush2.png");
            Bush2.SetCollisionBounds(boundsBush2);
            Bush2.Immobile = true;
            Entities.Add(Bush2.GetID(), Bush2);

            Polygon boundsBush3 = new Polygon();
            boundsBush3.Points.Add(new Vector(18, 68));
            boundsBush3.Points.Add(new Vector(97, 68));
            boundsBush3.Points.Add(new Vector(100, 35));
            boundsBush3.Points.Add(new Vector(13, 30));
            boundsBush3.BuildEdges();
            TextureLibrary.Textures.Add("Bush3.png", new Texture(new Image("Images\\Bush3.png")));
            RoomEntity Bush3 = new RoomEntity("Bush3", new Vector(110, 70), "Bush3.png");
            Bush3.SetCollisionBounds(boundsBush3);
            Bush3.Immobile = true;
            Entities.Add(Bush3.GetID(), Bush3);

            Polygon boundsBush4 = new Polygon();
            boundsBush4.Points.Add(new Vector(11, 45));
            boundsBush4.Points.Add(new Vector(109, 41));
            boundsBush4.Points.Add(new Vector(105, 16));
            boundsBush4.Points.Add(new Vector(10, 19));
            boundsBush4.BuildEdges();
            TextureLibrary.Textures.Add("Bush4.png", new Texture(new Image("Images\\Bush4.png")));
            RoomEntity Bush4 = new RoomEntity("Bush4", new Vector(114, 48), "Bush4.png");
            Bush4.SetCollisionBounds(boundsBush4);
            Bush4.Immobile = true;
            Entities.Add(Bush4.GetID(), Bush4);

            Polygon boundsCargoMod = new Polygon();
            boundsCargoMod.Points.Add(new Vector(0, 227));
            boundsCargoMod.Points.Add(new Vector(29, 227));
            boundsCargoMod.Points.Add(new Vector(39, 231));
            boundsCargoMod.Points.Add(new Vector(55, 231));
            boundsCargoMod.Points.Add(new Vector(65, 227));
            boundsCargoMod.Points.Add(new Vector(133, 227));
            boundsCargoMod.Points.Add(new Vector(143, 231));
            boundsCargoMod.Points.Add(new Vector(159, 231));
            boundsCargoMod.Points.Add(new Vector(169, 227));
            boundsCargoMod.Points.Add(new Vector(196, 227));
            boundsCargoMod.Points.Add(new Vector(196, 127));
            boundsCargoMod.Points.Add(new Vector(0, 127));
            boundsCargoMod.BuildEdges();
            TextureLibrary.Textures.Add("CargoMod.png", new Texture(new Image("Images\\CargoMod.png")));
            RoomEntity CargoMod = new RoomEntity("CargoMod", new Vector(196, 231), "CargoMod.png");
            BeaconLightRadar.SetCollisionBounds(boundsCargoMod);
            BeaconLightRadar.Immobile = true;
            Entities.Add(CargoMod.GetID(), CargoMod);

            TextureLibrary.Textures.Add("ClothingLine.png", new Texture(new Image("Images\\ClothingLine.png")));
            RoomEntity ClothingLine = new RoomEntity("ClothingLine", new Vector(108, 46), "ClothingLine.png");
            Entities.Add(ClothingLine.GetID(), ClothingLine);

            Polygon boundsCryoMod = new Polygon();
            boundsCryoMod.Points.Add(new Vector(0, 227));
            boundsCryoMod.Points.Add(new Vector(29, 227));
            boundsCryoMod.Points.Add(new Vector(39, 231));
            boundsCryoMod.Points.Add(new Vector(55, 231));
            boundsCryoMod.Points.Add(new Vector(65, 227));
            boundsCryoMod.Points.Add(new Vector(133, 227));
            boundsCryoMod.Points.Add(new Vector(143, 231));
            boundsCryoMod.Points.Add(new Vector(159, 231));
            boundsCryoMod.Points.Add(new Vector(169, 227));
            boundsCryoMod.Points.Add(new Vector(196, 227));
            boundsCryoMod.Points.Add(new Vector(196, 127));
            boundsCryoMod.Points.Add(new Vector(0, 127));
            boundsCryoMod.BuildEdges();
            TextureLibrary.Textures.Add("CryoMod.png", new Texture(new Image("Images\\CryoMod.png")));
            RoomEntity CryoMod = new RoomEntity("CryoMod", new Vector(196, 231), "CryoMod.png");
            BeaconLightRadar.SetCollisionBounds(boundsCryoMod);
            BeaconLightRadar.Immobile = true;
            Entities.Add(CryoMod.GetID(), CryoMod);

            TextureLibrary.Textures.Add("DirtForeBeacon.png", new Texture(new Image("Images\\DirtForeBeacon.png")));
            RoomEntity DirtForeBeacon = new RoomEntity("DirtForeBeacon", new Vector(218, 31), "DirtForeBeacon.png");
            Entities.Add(DirtForeBeacon.GetID(), DirtForeBeacon);

            TextureLibrary.Textures.Add("DirtForeBeacon2.png", new Texture(new Image("Images\\DirtForeBeacon2.png")));
            RoomEntity DirtForeBeacon2 = new RoomEntity("DirtForeBeacon2", new Vector(218, 31), "DirtForeBeacon2.png");
            Entities.Add(DirtForeBeacon2.GetID(), DirtForeBeacon2);

            Polygon boundsGarden = new Polygon();
            boundsGarden.Points.Add(new Vector(10, 140));
            boundsGarden.Points.Add(new Vector(313, 131));
            boundsGarden.Points.Add(new Vector(313, 9));
            boundsGarden.Points.Add(new Vector(5, 9));
            boundsGarden.BuildEdges();
            TextureLibrary.Textures.Add("Garden.png", new Texture(new Image("Images\\Garden.png")));
            RoomEntity Garden = new RoomEntity("Garden", new Vector(114, 48), "Garden.png");
            Garden.SetCollisionBounds(boundsGarden);
            Garden.Immobile = true;
            Entities.Add(Garden.GetID(), Garden);

            Polygon boundsMedMod = new Polygon();
            boundsMedMod.Points.Add(new Vector(0, 227));
            boundsMedMod.Points.Add(new Vector(29, 227));
            boundsMedMod.Points.Add(new Vector(39, 231));
            boundsMedMod.Points.Add(new Vector(55, 231));
            boundsMedMod.Points.Add(new Vector(65, 227));
            boundsMedMod.Points.Add(new Vector(133, 227));
            boundsMedMod.Points.Add(new Vector(143, 231));
            boundsMedMod.Points.Add(new Vector(159, 231));
            boundsMedMod.Points.Add(new Vector(169, 227));
            boundsMedMod.Points.Add(new Vector(196, 227));
            boundsMedMod.Points.Add(new Vector(196, 127));
            boundsMedMod.Points.Add(new Vector(0, 127));
            boundsMedMod.BuildEdges();
            TextureLibrary.Textures.Add("MedMod.png", new Texture(new Image("Images\\MedMod.png")));
            RoomEntity MedMod = new RoomEntity("MedMod", new Vector(196, 231), "MedMod.png");
            BeaconLightRadar.SetCollisionBounds(boundsMedMod);
            BeaconLightRadar.Immobile = true;
            Entities.Add(MedMod.GetID(), MedMod);

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

            TextureLibrary.Textures.Add("NuclearBeaconWire.png", new Texture(new Image("Images\\NuclearBeaconWire.png")));
            RoomEntity NuclearBeaconWire = new RoomEntity("NuclearBeaconWire", new Vector(732, 89), "NuclearBeaconWire.png");
            Entities.Add(NuclearBeaconWire.GetID(), NuclearBeaconWire);

            Polygon boundsNuclearMod = new Polygon();
            boundsNuclearMod.Points.Add(new Vector(0, 227));
            boundsNuclearMod.Points.Add(new Vector(29, 227));
            boundsNuclearMod.Points.Add(new Vector(39, 231));
            boundsNuclearMod.Points.Add(new Vector(55, 231));
            boundsNuclearMod.Points.Add(new Vector(65, 227));
            boundsNuclearMod.Points.Add(new Vector(133, 227));
            boundsNuclearMod.Points.Add(new Vector(143, 231));
            boundsNuclearMod.Points.Add(new Vector(159, 231));
            boundsNuclearMod.Points.Add(new Vector(169, 227));
            boundsNuclearMod.Points.Add(new Vector(196, 227));
            boundsNuclearMod.Points.Add(new Vector(196, 127));
            boundsNuclearMod.Points.Add(new Vector(0, 127));
            boundsNuclearMod.BuildEdges();
            TextureLibrary.Textures.Add("NuclearMod.png", new Texture(new Image("Images\\NuclearMod.png")));
            RoomEntity NuclearMod = new RoomEntity("NuclearMod", new Vector(196, 231), "NuclearMod.png");
            BeaconLightRadar.SetCollisionBounds(boundsNuclearMod);
            BeaconLightRadar.Immobile = true;
            Entities.Add(NuclearMod.GetID(), NuclearMod);

            TextureLibrary.Textures.Add("Plants.png", new Texture(new Image("Images\\Plants.png")));
            RoomEntity Plants = new RoomEntity("Plants", new Vector(305, 144), "Plants.png");
            Entities.Add(Plants.GetID(), Plants);

            Polygon boundsRock1 = new Polygon();
            boundsRock1.Points.Add(new Vector(0, 21));
            boundsRock1.Points.Add(new Vector(8, 24));
            boundsRock1.Points.Add(new Vector(12, 24));
            boundsRock1.Points.Add(new Vector(28, 20));
            boundsRock1.Points.Add(new Vector(31, 13));
            boundsRock1.Points.Add(new Vector(22, 6));
            boundsRock1.Points.Add(new Vector(4, 8));
            boundsRock1.BuildEdges();
            TextureLibrary.Textures.Add("Rock1.png", new Texture(new Image("Images\\Rock1.png")));
            RoomEntity Rock1 = new RoomEntity("Rock1", new Vector(31, 24), "Rock1.png");
            BeaconLightRadar.SetCollisionBounds(boundsRock1);
            BeaconLightRadar.Immobile = true;
            Entities.Add(Rock1.GetID(), Rock1);

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
            Animation anim;
            if ((anim = AnimationLibrary.Create("HavishamRunE")) != null) AHavisham.AddAnimation(anim.Type, anim);
            if ((anim = AnimationLibrary.Create("HavishamRunNE")) != null) AHavisham.AddAnimation(anim.Type, anim);
            if ((anim = AnimationLibrary.Create("HavishamRunN")) != null) AHavisham.AddAnimation(anim.Type, anim);
            if ((anim = AnimationLibrary.Create("HavishamRunNW")) != null) AHavisham.AddAnimation(anim.Type, anim);
            if ((anim = AnimationLibrary.Create("HavishamRunW")) != null) AHavisham.AddAnimation(anim.Type, anim);
            if ((anim = AnimationLibrary.Create("HavishamRunSW")) != null) AHavisham.AddAnimation(anim.Type, anim);
            if ((anim = AnimationLibrary.Create("HavishamRunS")) != null) AHavisham.AddAnimation(anim.Type, anim);
            if ((anim = AnimationLibrary.Create("HavishamRunSE")) != null) AHavisham.AddAnimation(anim.Type, anim);
            if ((anim = AnimationLibrary.Create("AHavishamIdleE")) != null) AHavisham.AddAnimation(anim.Type, anim);
            if ((anim = AnimationLibrary.Create("AHavishamIdleW")) != null) AHavisham.AddAnimation(anim.Type, anim);
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
            if ((anim = AnimationLibrary.Create("JBreechIdleE")) != null) JBreech.AddAnimation(anim.Type, anim);
            if ((anim = AnimationLibrary.Create("JBreechIdleW")) != null) JBreech.AddAnimation(anim.Type, anim);
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
