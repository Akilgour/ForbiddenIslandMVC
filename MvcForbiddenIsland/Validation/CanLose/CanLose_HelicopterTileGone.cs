using MvcForbiddenIsland.Constants;
using MvcForbiddenIsland.Models;
using MvcForbiddenIsland.Validation.CanLose.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcForbiddenIsland.Validation.CanLose
{
    public class CanLose_HelicopterTileGone : CanLoseBase, ICanLose
    {
        public ValidationResults IsValid(IslandTile FoolsLanding, List<Models.IslandTile> PlayerTiles, List<Models.IslandTile> TreasureTiles, int WaterLevel)
        {
          //  string output = String.Format(CanWinConstants.AT_FOOLS_LANDING, diver.Name);

            if (TileGone(FoolsLanding))
            {
                return new ValidationResults() { IsValid = false, ErrorMessage = String.Format(CanLoseConstants.TILE_GONE, FoolsLanding.Name) };
            }

            return new ValidationResults() { IsValid = true };

           
        }
    }
}