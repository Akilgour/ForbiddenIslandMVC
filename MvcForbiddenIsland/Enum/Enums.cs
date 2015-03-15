using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcForbiddenIsland.Enum
{
  
        public enum TileState
        {
            Normal,
            Flodded,
            Gone
        }

        public enum PlayerColour
        {
            Red,
            Yellow,
            Blue,
            Black,
            Green,
            Grey,
            None
        }

        public enum TreasureCardType
        {
            EarthStone,
            StatueOfTheWind,
            CrystalOfFire,
            OceansChalice,
            WaterRises,
            HelicopterLift,
            SandBags,
        }

        public enum TeasureCardDeckId
        {
            DrawDeck,
            DiscardDeck,
            PlayerOneDeck,
            PlayerTwoDeck,
            PlayerThreeDeck,
            PlayerFourDeck,
        }

        public enum TreasureStatue
        {
            EarthStone,
            StatueOfTheWind,
            CrystalOfFire,
            OceansChalice,
            None,
        }


        public enum MoveType
        {
            FirstMyPawnMoveTile,
            SecondMyPawnMoveTile,
            ThirdMyPawnMoveTile,
            FourthMyPawnMoveTile,
        }
}