using MvcForbiddenIsland.Constants;
using MvcForbiddenIsland.Models;
using MvcForbiddenIsland.Validation.CanLose.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcForbiddenIsland.Validation.CanLose
{
    public class CanLose_WaterAtMaxLevel : CanLoseBase, ICanLose
    {
        /// <summary>
        /// This checks that the water level hasnt passed its max value
        /// </summary>
        /// <param name="IslandBoard">Not needed for this test </param>
        /// <param name="WaterLevel">The lever the water is at</param>
        /// <returns></returns>
        public ValidationResults IsValid(List<IslandTile> IslandBoard, int WaterLevel)
        {
            if (WaterLevel >= WaterLevelConstants.MAX_LEVEL)
            {
                return new ValidationResults() { IsValid = false, ErrorMessage = CanLoseConstants.ISLAND_IS_GONE };
            }
            return new ValidationResults() { IsValid = true };
        }
    }
}