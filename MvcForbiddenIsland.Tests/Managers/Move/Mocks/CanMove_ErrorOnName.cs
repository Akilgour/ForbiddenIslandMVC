using MvcForbiddenIsland.Models;
using MvcForbiddenIsland.Validation.CanMove;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcForbiddenIsland.Tests.Managers.Mocks
{
    public class CanMove_ErrorOnName : ICanMoveValidation
    {
        /// <summary>
        /// This Mock will throw an CAN_MOVE_ERROR when the tiles name is the constant error tile name
        /// </summary>
        /// <param name="FirstIslandTile"></param>
        /// <param name="SecondIslandTile"></param>
        /// <param name="Player"></param>
        /// <returns></returns>
        public ValidationResults IsValid(IslandTile FirstIslandTile, IslandTile SecondIslandTile, Player Player)
        {
            if   ((FirstIslandTile.Name == ManagersTestConstants.ERROR_TILE_NAME) || (SecondIslandTile.Name == ManagersTestConstants.ERROR_TILE_NAME))
            {
                return new ValidationResults() { IsValid = false, ErrorMessage = ManagersTestConstants.CAN_MOVE_ERROR };
            }
            return new ValidationResults() { IsValid = true };
        }
    }
}
