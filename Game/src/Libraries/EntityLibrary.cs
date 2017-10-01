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
            Entities.Add(DebugBackground.GetID(), DebugBackground);

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
            TextureLibrary.Textures.Add("BeaconLightRadar.png", new Texture(new Image("Images\\Objects\\BeaconLightRadar.png")));
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
            TextureLibrary.Textures.Add("Bush1.png", new Texture(new Image("Images\\Objects\\Bush1.png")));
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
            TextureLibrary.Textures.Add("Bush2.png", new Texture(new Image("Images\\Objects\\Bush2.png")));
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
            TextureLibrary.Textures.Add("Bush3.png", new Texture(new Image("Images\\Objects\\Bush3.png")));
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
            TextureLibrary.Textures.Add("Bush4.png", new Texture(new Image("Images\\Objects\\Bush4.png")));
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
            TextureLibrary.Textures.Add("CargoMod.png", new Texture(new Image("Images\\Objects\\CargoMod.png")));
            RoomEntity CargoMod = new RoomEntity("CargoMod", new Vector(196, 231), "CargoMod.png");
            CargoMod.SetCollisionBounds(boundsCargoMod);
            CargoMod.Immobile = true;
            Entities.Add(CargoMod.GetID(), CargoMod);

            TextureLibrary.Textures.Add("ClothingLine.png", new Texture(new Image("Images\\Objects\\ClothingLine.png")));
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
            TextureLibrary.Textures.Add("CryoMod.png", new Texture(new Image("Images\\Objects\\CryoMod.png")));
            RoomEntity CryoMod = new RoomEntity("CryoMod", new Vector(196, 231), "CryoMod.png");
            CryoMod.SetCollisionBounds(boundsCryoMod);
            CryoMod.Immobile = true;
            Entities.Add(CryoMod.GetID(), CryoMod);

            TextureLibrary.Textures.Add("DirtForeBeacon.png", new Texture(new Image("Images\\Objects\\DirtForeBeacon.png")));
            RoomEntity DirtForeBeacon = new RoomEntity("DirtForeBeacon", new Vector(218, 31), "DirtForeBeacon.png");
            Entities.Add(DirtForeBeacon.GetID(), DirtForeBeacon);

            TextureLibrary.Textures.Add("DirtForeBeacon2.png", new Texture(new Image("Images\\Objects\\DirtForeBeacon2.png")));
            RoomEntity DirtForeBeacon2 = new RoomEntity("DirtForeBeacon2", new Vector(218, 31), "DirtForeBeacon2.png");
            Entities.Add(DirtForeBeacon2.GetID(), DirtForeBeacon2);

            Polygon boundsGarden = new Polygon();
            boundsGarden.Points.Add(new Vector(10, 140));
            boundsGarden.Points.Add(new Vector(313, 131));
            boundsGarden.Points.Add(new Vector(313, 9));
            boundsGarden.Points.Add(new Vector(5, 9));
            boundsGarden.BuildEdges();
            TextureLibrary.Textures.Add("Garden.png", new Texture(new Image("Images\\Objects\\Garden.png")));
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
            TextureLibrary.Textures.Add("MedMod.png", new Texture(new Image("Images\\Objects\\MedMod.png")));
            RoomEntity MedMod = new RoomEntity("MedMod", new Vector(196, 231), "MedMod.png");
            MedMod.SetCollisionBounds(boundsMedMod);
            MedMod.Immobile = true;
            Entities.Add(MedMod.GetID(), MedMod);

            TextureLibrary.Textures.Add("NuclearBeaconWire.png", new Texture(new Image("Images\\Objects\\NuclearBeaconWire.png")));
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
            TextureLibrary.Textures.Add("NuclearMod.png", new Texture(new Image("Images\\Objects\\NuclearMod.png")));
            RoomEntity NuclearMod = new RoomEntity("NuclearMod", new Vector(196, 231), "NuclearMod.png");
            NuclearMod.SetCollisionBounds(boundsNuclearMod);
            NuclearMod.Immobile = true;
            Entities.Add(NuclearMod.GetID(), NuclearMod);

            TextureLibrary.Textures.Add("Plants.png", new Texture(new Image("Images\\Objects\\Plants.png")));
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
            TextureLibrary.Textures.Add("Rock1.png", new Texture(new Image("Images\\Objects\\Rock1.png")));
            RoomEntity Rock1 = new RoomEntity("Rock1", new Vector(31, 24), "Rock1.png");
            Rock1.SetCollisionBounds(boundsRock1);
            Rock1.Immobile = true;
            Entities.Add(Rock1.GetID(), Rock1);

            Polygon boundsRock2 = new Polygon();
            boundsRock2.Points.Add(new Vector(2, 19));
            boundsRock2.Points.Add(new Vector(8, 18));
            boundsRock2.Points.Add(new Vector(10, 20));
            boundsRock2.Points.Add(new Vector(15, 20));
            boundsRock2.Points.Add(new Vector(21, 16));
            boundsRock2.Points.Add(new Vector(11, 3));
            boundsRock2.Points.Add(new Vector(3, 5));
            boundsRock2.BuildEdges();
            TextureLibrary.Textures.Add("Rock2.png", new Texture(new Image("Images\\Objects\\Rock2.png")));
            RoomEntity Rock2 = new RoomEntity("Rock2", new Vector(21, 20), "Rock2.png");
            Rock2.SetCollisionBounds(boundsRock2);
            Rock2.Immobile = true;
            Entities.Add(Rock2.GetID(), Rock2);

            Polygon boundsRock3 = new Polygon();
            boundsRock3.Points.Add(new Vector(10, 31));
            boundsRock3.Points.Add(new Vector(37, 33));
            boundsRock3.Points.Add(new Vector(44, 38));
            boundsRock3.Points.Add(new Vector(63, 28));
            boundsRock3.Points.Add(new Vector(34, 4));
            boundsRock3.Points.Add(new Vector(13, 7));
            boundsRock3.Points.Add(new Vector(4, 11));
            boundsRock3.BuildEdges();
            TextureLibrary.Textures.Add("Rock3.png", new Texture(new Image("Images\\Objects\\Rock3.png")));
            RoomEntity Rock3 = new RoomEntity("Rock3", new Vector(64, 38), "Rock3.png");
            Rock3.SetCollisionBounds(boundsRock3);
            Rock3.Immobile = true;
            Entities.Add(Rock3.GetID(), Rock3);

            Polygon boundsRock4 = new Polygon();
            boundsRock4.Points.Add(new Vector(0, 27));
            boundsRock4.Points.Add(new Vector(14, 33));
            boundsRock4.Points.Add(new Vector(25, 49));
            boundsRock4.Points.Add(new Vector(52, 51));
            boundsRock4.Points.Add(new Vector(64, 43));
            boundsRock4.Points.Add(new Vector(78, 35));
            boundsRock4.Points.Add(new Vector(66, 17));
            boundsRock4.Points.Add(new Vector(5, 11));
            boundsRock4.BuildEdges();
            TextureLibrary.Textures.Add("Rock4.png", new Texture(new Image("Images\\Objects\\Rock4.png")));
            RoomEntity Rock4 = new RoomEntity("Rock4", new Vector(81, 51), "Rock4.png");
            Rock4.SetCollisionBounds(boundsRock4);
            Rock4.Immobile = true;
            Entities.Add(Rock4.GetID(), Rock4);

            Polygon boundsRock5 = new Polygon();
            boundsRock5.Points.Add(new Vector(0, 22));
            boundsRock5.Points.Add(new Vector(4, 26));
            boundsRock5.Points.Add(new Vector(32, 27));
            boundsRock5.Points.Add(new Vector(39, 20));
            boundsRock5.Points.Add(new Vector(41, 11));
            boundsRock5.Points.Add(new Vector(9, 9));
            boundsRock5.Points.Add(new Vector(7, 19));
            boundsRock5.BuildEdges();
            TextureLibrary.Textures.Add("Rock5.png", new Texture(new Image("Images\\Objects\\Rock5.png")));
            RoomEntity Rock5 = new RoomEntity("Rock5", new Vector(42, 28), "Rock5.png");
            Rock5.SetCollisionBounds(boundsRock5);
            Rock5.Immobile = true;
            Entities.Add(Rock5.GetID(), Rock5);

            Polygon boundsRock6 = new Polygon();
            boundsRock6.Points.Add(new Vector(2, 19));
            boundsRock6.Points.Add(new Vector(8, 18));
            boundsRock6.Points.Add(new Vector(10, 20));
            boundsRock6.Points.Add(new Vector(15, 20));
            boundsRock6.Points.Add(new Vector(21, 16));
            boundsRock6.Points.Add(new Vector(11, 3));
            boundsRock6.Points.Add(new Vector(3, 5));
            boundsRock6.BuildEdges();
            TextureLibrary.Textures.Add("Rock6.png", new Texture(new Image("Images\\Objects\\Rock6.png")));
            RoomEntity Rock6 = new RoomEntity("Rock6", new Vector(21, 20), "Rock6.png");
            Rock6.SetCollisionBounds(boundsRock6);
            Rock6.Immobile = true;
            Entities.Add(Rock6.GetID(), Rock6);

            Polygon boundsRock7 = new Polygon();
            boundsRock7.Points.Add(new Vector(0, 11));
            boundsRock7.Points.Add(new Vector(6, 20));
            boundsRock7.Points.Add(new Vector(36, 24));
            boundsRock7.Points.Add(new Vector(36, 18));
            boundsRock7.Points.Add(new Vector(32, 16));
            boundsRock7.Points.Add(new Vector(32, 10));
            boundsRock7.Points.Add(new Vector(22, 3));
            boundsRock7.Points.Add(new Vector(8, 3));
            boundsRock7.BuildEdges();
            TextureLibrary.Textures.Add("Rock7.png", new Texture(new Image("Images\\Objects\\Rock7.png")));
            RoomEntity Rock7 = new RoomEntity("Rock7", new Vector(36, 24), "Rock7.png");
            Rock7.SetCollisionBounds(boundsRock7);
            Rock7.Immobile = true;
            Entities.Add(Rock7.GetID(), Rock7);

            Polygon boundsRock8 = new Polygon();
            boundsRock8.Points.Add(new Vector(4, 24));
            boundsRock8.Points.Add(new Vector(25, 42));
            boundsRock8.Points.Add(new Vector(61, 12));
            boundsRock8.Points.Add(new Vector(38, 6));
            boundsRock8.BuildEdges();
            TextureLibrary.Textures.Add("Rock8.png", new Texture(new Image("Images\\Objects\\Rock8.png")));
            RoomEntity Rock8 = new RoomEntity("Rock8", new Vector(61, 42), "Rock8.png");
            Rock8.SetCollisionBounds(boundsRock8);
            Rock8.Immobile = true;
            Entities.Add(Rock8.GetID(), Rock8);

            Polygon boundsRock9 = new Polygon();
            boundsRock9.Points.Add(new Vector(10, 31));
            boundsRock9.Points.Add(new Vector(37, 33));
            boundsRock9.Points.Add(new Vector(44, 38));
            boundsRock9.Points.Add(new Vector(63, 28));
            boundsRock9.Points.Add(new Vector(34, 4));
            boundsRock9.Points.Add(new Vector(13, 7));
            boundsRock9.Points.Add(new Vector(4, 11));
            boundsRock9.BuildEdges();
            TextureLibrary.Textures.Add("Rock9.png", new Texture(new Image("Images\\Objects\\Rock9.png")));
            RoomEntity Rock9 = new RoomEntity("Rock9", new Vector(64, 38), "Rock9.png");
            Rock9.SetCollisionBounds(boundsRock9);
            Rock9.Immobile = true;
            Entities.Add(Rock9.GetID(), Rock9);

            Polygon boundsRock10 = new Polygon();
            boundsRock10.Points.Add(new Vector(0, 21));
            boundsRock10.Points.Add(new Vector(8, 24));
            boundsRock10.Points.Add(new Vector(12, 24));
            boundsRock10.Points.Add(new Vector(28, 20));
            boundsRock10.Points.Add(new Vector(31, 13));
            boundsRock10.Points.Add(new Vector(22, 6));
            boundsRock10.Points.Add(new Vector(4, 8));
            boundsRock10.BuildEdges();
            TextureLibrary.Textures.Add("Rock10.png", new Texture(new Image("Images\\Objects\\Rock10.png")));
            RoomEntity Rock10 = new RoomEntity("Rock10", new Vector(31, 24), "Rock10.png");
            Rock10.SetCollisionBounds(boundsRock10);
            Rock10.Immobile = true;
            Entities.Add(Rock10.GetID(), Rock10);

            Polygon boundsRock11 = new Polygon();
            boundsRock11.Points.Add(new Vector(2, 28));
            boundsRock11.Points.Add(new Vector(14, 33));
            boundsRock11.Points.Add(new Vector(24, 49));
            boundsRock11.Points.Add(new Vector(50, 51));
            boundsRock11.Points.Add(new Vector(64, 64));
            boundsRock11.Points.Add(new Vector(74, 64));
            boundsRock11.Points.Add(new Vector(100, 44));
            boundsRock11.Points.Add(new Vector(34, 8));
            boundsRock11.Points.Add(new Vector(1, 21));
            boundsRock11.BuildEdges();
            TextureLibrary.Textures.Add("Rock11.png", new Texture(new Image("Images\\Objects\\Rock11.png")));
            RoomEntity Rock11 = new RoomEntity("Rock11", new Vector(102, 64), "Rock11.png");
            Rock11.SetCollisionBounds(boundsRock11);
            Rock11.Immobile = true;
            Entities.Add(Rock11.GetID(), Rock11);

            Polygon boundsSawmill = new Polygon();
            boundsSawmill.Points.Add(new Vector(7, 89));
            boundsSawmill.Points.Add(new Vector(55, 89));
            boundsSawmill.Points.Add(new Vector(55, 25));
            boundsSawmill.Points.Add(new Vector(7, 25));
            boundsSawmill.BuildEdges();
            TextureLibrary.Textures.Add("Sawmill.png", new Texture(new Image("Images\\Objects\\Sawmill.png")));
            RoomEntity Sawmill = new RoomEntity("Sawmill", new Vector(106, 90), "Sawmill.png");
            Sawmill.SetCollisionBounds(boundsSawmill);
            Sawmill.Immobile = true;
            Entities.Add(Sawmill.GetID(), Sawmill);

            Polygon boundsShelter1 = new Polygon();
            boundsShelter1.Points.Add(new Vector(5, 87));
            boundsShelter1.Points.Add(new Vector(0, 114));
            boundsShelter1.Points.Add(new Vector(114, 114));
            boundsShelter1.Points.Add(new Vector(135, 104));
            boundsShelter1.Points.Add(new Vector(135, 78));
            boundsShelter1.Points.Add(new Vector(119, 69));
            boundsShelter1.Points.Add(new Vector(99, 37));
            boundsShelter1.Points.Add(new Vector(9, 37));
            boundsShelter1.BuildEdges();
            TextureLibrary.Textures.Add("Shelter1.png", new Texture(new Image("Images\\Objects\\Shelter1.png")));
            RoomEntity Shelter1 = new RoomEntity("Shelter1", new Vector(136, 114), "Shelter1.png");
            Shelter1.SetCollisionBounds(boundsShelter1);
            Shelter1.Immobile = true;
            Entities.Add(Shelter1.GetID(), Shelter1);

            Polygon boundsShelter2 = new Polygon();
            boundsShelter2.Points.Add(new Vector(0, 110));
            boundsShelter2.Points.Add(new Vector(192, 110));
            boundsShelter2.Points.Add(new Vector(184, 73));
            boundsShelter2.Points.Add(new Vector(169, 62));
            boundsShelter2.Points.Add(new Vector(25, 62));
            boundsShelter2.Points.Add(new Vector(6, 69));
            boundsShelter2.BuildEdges();
            TextureLibrary.Textures.Add("Shelter2.png", new Texture(new Image("Images\\Objects\\Shelter2.png")));
            RoomEntity Shelter2 = new RoomEntity("Shelter2", new Vector(192, 110), "Shelter2.png");
            Shelter2.SetCollisionBounds(boundsShelter2);
            Shelter2.Immobile = true;
            Entities.Add(Shelter2.GetID(), Shelter2);

            Polygon boundsShelter3 = new Polygon();
            boundsShelter3.Points.Add(new Vector(0, 130));
            boundsShelter3.Points.Add(new Vector(112, 130));
            boundsShelter3.Points.Add(new Vector(112, 72));
            boundsShelter3.Points.Add(new Vector(0, 72));
            boundsShelter3.BuildEdges();
            TextureLibrary.Textures.Add("Shelter3.png", new Texture(new Image("Images\\Objects\\Shelter3.png")));
            RoomEntity Shelter3 = new RoomEntity("Shelter3", new Vector(112, 130), "Shelter3.png");
            Shelter3.SetCollisionBounds(boundsShelter3);
            Shelter3.Immobile = true;
            Entities.Add(Shelter3.GetID(), Shelter3);

            Polygon boundsShelter4 = new Polygon();
            boundsShelter4.Points.Add(new Vector(6, 98));
            boundsShelter4.Points.Add(new Vector(110, 98));
            boundsShelter4.Points.Add(new Vector(110, 57));
            boundsShelter4.Points.Add(new Vector(16, 57));
            boundsShelter4.BuildEdges();
            TextureLibrary.Textures.Add("Shelter4.png", new Texture(new Image("Images\\Objects\\Shelter4.png")));
            RoomEntity Shelter4 = new RoomEntity("Shelter4", new Vector(111, 98), "Shelter4.png");
            Shelter4.SetCollisionBounds(boundsShelter4);
            Shelter4.Immobile = true;
            Entities.Add(Shelter4.GetID(), Shelter4);

            Polygon boundsShelter5 = new Polygon();
            boundsShelter5.Points.Add(new Vector(0, 90));
            boundsShelter5.Points.Add(new Vector(23, 101));
            boundsShelter5.Points.Add(new Vector(160, 101));
            boundsShelter5.Points.Add(new Vector(186, 71));
            boundsShelter5.Points.Add(new Vector(160, 47));
            boundsShelter5.Points.Add(new Vector(21, 47));
            boundsShelter5.Points.Add(new Vector(0, 52));
            boundsShelter5.BuildEdges();
            TextureLibrary.Textures.Add("Shelter5.png", new Texture(new Image("Images\\Objects\\Shelter5.png")));
            RoomEntity Shelter5 = new RoomEntity("Shelter5", new Vector(186, 105), "Shelter5.png");
            Shelter5.SetCollisionBounds(boundsShelter5);
            Shelter5.Immobile = true;
            Entities.Add(Shelter5.GetID(), Shelter5);

            Polygon boundsShelter6 = new Polygon();
            boundsShelter6.Points.Add(new Vector(0, 107));
            boundsShelter6.Points.Add(new Vector(167, 107));
            boundsShelter6.Points.Add(new Vector(167, 64));
            boundsShelter6.Points.Add(new Vector(0, 64));
            boundsShelter6.BuildEdges();
            TextureLibrary.Textures.Add("Shelter6.png", new Texture(new Image("Images\\Objects\\Shelter6.png")));
            RoomEntity Shelter6 = new RoomEntity("Shelter6", new Vector(176, 107), "Shelter6.png");
            Shelter6.SetCollisionBounds(boundsShelter6);
            Shelter6.Immobile = true;
            Entities.Add(Shelter6.GetID(), Shelter6);

            Polygon boundsShelter7 = new Polygon();
            boundsShelter7.Points.Add(new Vector(0, 110));
            boundsShelter7.Points.Add(new Vector(192, 110));
            boundsShelter7.Points.Add(new Vector(184, 73));
            boundsShelter7.Points.Add(new Vector(169, 62));
            boundsShelter7.Points.Add(new Vector(25, 62));
            boundsShelter7.Points.Add(new Vector(6, 69));
            boundsShelter7.BuildEdges();
            TextureLibrary.Textures.Add("Shelter7.png", new Texture(new Image("Images\\Objects\\Shelter7.png")));
            RoomEntity Shelter7 = new RoomEntity("Shelter7", new Vector(192, 110), "Shelter7.png");
            Shelter7.SetCollisionBounds(boundsShelter7);
            Shelter7.Immobile = true;
            Entities.Add(Shelter7.GetID(), Shelter7);

            Polygon boundsShelter8 = new Polygon();
            boundsShelter8.Points.Add(new Vector(0, 99));
            boundsShelter8.Points.Add(new Vector(161, 99));
            boundsShelter8.Points.Add(new Vector(183, 92));
            boundsShelter8.Points.Add(new Vector(183, 64));
            boundsShelter8.Points.Add(new Vector(4, 64));
            boundsShelter8.BuildEdges();
            TextureLibrary.Textures.Add("Shelter8.png", new Texture(new Image("Images\\Objects\\Shelter8.png")));
            RoomEntity Shelter8 = new RoomEntity("Shelter8", new Vector(183, 99), "Shelter8.png");
            Shelter8.SetCollisionBounds(boundsShelter8);
            Shelter8.Immobile = true;
            Entities.Add(Shelter8.GetID(), Shelter8);

            Polygon boundsTree1 = new Polygon();
            boundsTree1.Points.Add(new Vector(51, 156));
            boundsTree1.Points.Add(new Vector(72, 156));
            boundsTree1.Points.Add(new Vector(72, 141));
            boundsTree1.Points.Add(new Vector(51, 141));
            boundsTree1.BuildEdges();
            TextureLibrary.Textures.Add("Tree1.png", new Texture(new Image("Images\\Objects\\Tree1.png")));
            RoomEntity Tree1 = new RoomEntity("Tree1", new Vector(122, 167), "Tree1.png");
            Tree1.SetCollisionBounds(boundsTree1);
            Tree1.Immobile = true;
            Entities.Add(Tree1.GetID(), Tree1);

            Polygon boundsTree2 = new Polygon();
            boundsTree2.Points.Add(new Vector(38, 115));
            boundsTree2.Points.Add(new Vector(54, 115));
            boundsTree2.Points.Add(new Vector(54, 107));
            boundsTree2.Points.Add(new Vector(38, 107));
            boundsTree2.BuildEdges();
            TextureLibrary.Textures.Add("Tree2.png", new Texture(new Image("Images\\Objects\\Tree2.png")));
            RoomEntity Tree2 = new RoomEntity("Tree2", new Vector(90, 124), "Tree2.png");
            Tree2.SetCollisionBounds(boundsTree2);
            Tree2.Immobile = true;
            Entities.Add(Tree2.GetID(), Tree2);

            Polygon boundsTree3 = new Polygon();
            boundsTree3.Points.Add(new Vector(50, 153));
            boundsTree3.Points.Add(new Vector(71, 153));
            boundsTree3.Points.Add(new Vector(71, 139));
            boundsTree3.Points.Add(new Vector(50, 139));
            boundsTree3.BuildEdges();
            TextureLibrary.Textures.Add("Tree3.png", new Texture(new Image("Images\\Objects\\Tree3.png")));
            RoomEntity Tree3 = new RoomEntity("Tree3", new Vector(122, 167), "Tree3.png");
            Tree3.SetCollisionBounds(boundsTree3);
            Tree3.Immobile = true;
            Entities.Add(Tree3.GetID(), Tree3);

            Polygon boundsTreesBack = new Polygon();
            boundsTreesBack.Points.Add(new Vector(0, 0));
            boundsTreesBack.Points.Add(new Vector(0, 260));
            boundsTreesBack.Points.Add(new Vector(69, 276));
            boundsTreesBack.Points.Add(new Vector(148, 276));
            boundsTreesBack.Points.Add(new Vector(238, 261));
            boundsTreesBack.Points.Add(new Vector(241, 212));
            boundsTreesBack.Points.Add(new Vector(356, 220));
            boundsTreesBack.Points.Add(new Vector(602, 169));
            boundsTreesBack.Points.Add(new Vector(602, 113));
            boundsTreesBack.Points.Add(new Vector(787, 113));
            boundsTreesBack.Points.Add(new Vector(844, 125));
            boundsTreesBack.Points.Add(new Vector(927, 125));
            boundsTreesBack.Points.Add(new Vector(1009, 109));
            boundsTreesBack.Points.Add(new Vector(1066, 62));
            boundsTreesBack.Points.Add(new Vector(2000, 62));
            boundsTreesBack.Points.Add(new Vector(2000, 0));
            boundsTreesBack.BuildEdges();
            TextureLibrary.Textures.Add("TreesBack.png", new Texture(new Image("Images\\Objects\\TreesBack.png")));
            RoomEntity TreesBack = new RoomEntity("TreesBack", new Vector(2000, 397), "TreesBack.png");
            TreesBack.SetCollisionBounds(boundsTreesBack);
            TreesBack.Immobile = true;
            Entities.Add(TreesBack.GetID(), TreesBack);

            Polygon boundsTreesFore = new Polygon();
            boundsTreesFore.Points.Add(new Vector(0, 422));
            boundsTreesFore.Points.Add(new Vector(532, 510));
            boundsTreesFore.Points.Add(new Vector(578, 600));
            boundsTreesFore.Points.Add(new Vector(0, 600));
            boundsTreesFore.BuildEdges();
            TextureLibrary.Textures.Add("TreesFore.png", new Texture(new Image("Images\\Objects\\TreesFore.png")));
            RoomEntity TreesFore = new RoomEntity("TreesFore", new Vector(2000, 397), "TreesFore.png");
            TreesFore.SetCollisionBounds(boundsTreesFore);
            TreesFore.Immobile = true;
            Entities.Add(TreesFore.GetID(), TreesFore);

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

            Polygon boundsDebugCube = new Polygon();
            boundsDebugCube.Points.Add(new Vector(1, 126));
            boundsDebugCube.Points.Add(new Vector(152, 126));
            boundsDebugCube.Points.Add(new Vector(152, 226));
            boundsDebugCube.Points.Add(new Vector(1, 226));
            boundsDebugCube.BuildEdges();
            TextureLibrary.Textures.Add("DebugCube.png", new Texture(new Image("Images\\DebugCube.png")));
            RoomEntity DebugCube = new RoomEntity("DebugCube", new Vector(152, 226), "DebugCube.png");
            DebugCube.SetCollisionBounds(boundsDebugCube);
            Entities.Add(DebugCube.GetID(), DebugCube);

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
