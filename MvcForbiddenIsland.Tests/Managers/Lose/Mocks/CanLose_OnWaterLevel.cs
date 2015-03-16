using MvcForbiddenIsland.Models;
using MvcForbiddenIsland.Validation.CanLose.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcForbiddenIsland.Tests.Managers.Lose.Mocks
{
    public class CanLose_OnWaterLevel : ICanLose
    {
        /// <summary>
        /// If water lever is 99 this will throw an error, this mock was writen to test the varables a correctly mapped
        /// </summary>
        /// <param name="IslandBoard"></param>
        /// <param name="WaterLevel"></param>
        /// <returns></returns>
        public ValidationResults IsValid(List<IslandTile> IslandBoard, int WaterLevel)
        {
            if (WaterLevel == 99)
            {
                return new ValidationResults() { IsValid = false, ErrorMessage = LoseManagerTestConstants.CAN_LOSE_ON_WATER_LEVEL_ERROR };
            }
            return new ValidationResults() { IsValid = true };
        }
    }
}
