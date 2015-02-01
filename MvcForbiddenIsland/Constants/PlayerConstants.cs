using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcForbiddenIsland.Constants
{
   public static class PlayerConstants
    {
        public static string MESSENGER_ACTION = "Give Treasure card to a player anywhere on the island for 1 action per card.";
        public static string EXPLORER_ACTION = "Move and/or short up diagonally.";
        public static string DIVER_ACTION = "Move throught 1 onr more adjacent flooded and/or missing tiles for 1 action. (Must end your turn on a tile.)";
        public static string PILOT_ACTION = "Once per turn, fly to any tile on the island for 1 action.";
        public static string NAVIGATOR_ACTION = "Move another player up to 2 adjacent tiles for 1 action.";
        public static string ENGINEER_ACTION = "Shore up 2 tiles for 1 action.";

    }
}