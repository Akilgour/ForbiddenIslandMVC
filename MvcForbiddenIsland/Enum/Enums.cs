using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcForbiddenIsland.Enum
{
    public class Enums
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
    }
}