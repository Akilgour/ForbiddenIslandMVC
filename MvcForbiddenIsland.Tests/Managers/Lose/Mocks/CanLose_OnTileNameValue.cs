using MvcForbiddenIsland.Models;
using MvcForbiddenIsland.Validation.CanLose.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcForbiddenIsland.Tests.Managers.Lose.Mocks
{
    class CanLose_OnTileNameValue : ICanLose
    {
        /// <summary>
        /// If first island tiles name is CAN_LOSE_ERROR it will throw an error
        /// </summary>
        /// <param name="IslandBoard"></param>
        /// <param name="WaterLevel"></param>
        /// <returns></returns>
        public ValidationResults IsValid(List<IslandTile> IslandBoard, int WaterLevel)
        {
            if (IslandBoard.First().Name == LoseManagerTestConstants.ERROR_TILE_NAME)
            {
                return new ValidationResults() { IsValid = false, ErrorMessage = LoseManagerTestConstants.CAN_LOSE_ON_TILE_ERROR };
            }
            return new ValidationResults() { IsValid = true };
        }
    }
}
