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
        public ValidationResults IsValid (List<IslandTile> IslandBoard, int WaterLevel)
        {
            var foolsLanding = IslandBoard.Single(x => x.Name == "Fools' Landing");

            if (TileGone(foolsLanding))
            {
                return new ValidationResults() { IsValid = false, ErrorMessage = String.Format(CanLoseConstants.TILE_GONE, foolsLanding.Name) };
            }

            return new ValidationResults() { IsValid = true };

           
        }
    }
}