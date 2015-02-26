using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcForbiddenIsland.Constants
{
    public static class CardConstants
    {
        public static string SANDBAG_NAME = "Sandbags";
        public static string SANDBAG_DESCRIPTION = "Shore up any one tile on the island.";
        public static string SANDBAG_ACTION = CARD_ACTION;

        public static string HELICOPTERLIFT_NAME = "Helicopter Lift";
        public static string HELICOPTERLIFT_DESCRIPTION = "Move one or more pawns on  the same tile to any other tile - or - Lift your team off Fools' Land for the win!";
        public static string HELICOPTERLIFT_ACTION = CARD_ACTION;

        public static string CARD_ACTION = "Play at any time. Does not count as an action. Discard to Treasure discard pile after use.";

        public static string WATERRISE_NAME = "Water Rise!";
        public static string WATERRISE_DESCRIPTION = "1. Move the water level up one tick mark. 2. Shuffle the FLood discard pile and place it on top of te Flood draw pile.  3. Discard this card to the Treasure discard pile.";
        public static string WATERRISE_ACTION = "";

        public static string OCEANS_CHALICE_NAME = "Oceans Chalice";
        public static string CRYSTAL_OF_FIRE_NAME = "Crystal Of Fire";
        public static string STATUE_OF_THE_WIND_NAME = "Statue Of The Wind";
        public static string EARTH_STONE_NAME = "Earth Stone";
        
        
    }
}