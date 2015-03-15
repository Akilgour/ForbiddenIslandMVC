using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcForbiddenIsland.Constants
{
    public static class CanMoveErrorConstants
    {
        public static string ONLY_MOVE_ONE_ROW = "Can only move one row at a time";
        public static string ONLY_MOVE_ONE_COLUMN = "Can only move one column at a time";
        public static string NEED_FOUR_MOVE_TILES = "MoveType four player move tiles";
        public static string CANMOVEVALIDATION_CANNOT_BE_NULL = "CanMoveValidation cannot be null";
        public static string PLAYERMOVES_CANNOT_BE_NULL = "PlayerMoves cannot be null";
    }
}