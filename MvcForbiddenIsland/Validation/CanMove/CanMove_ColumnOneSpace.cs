using MvcForbiddenIsland.Constants;
using MvcForbiddenIsland.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcForbiddenIsland.Validation.CanMove.Interface
{
    public class CanMove_ColumnOneSpace : ICanMoveValidation
    {
        public ValidationResults IsValid(IslandTile FirstIslandTile, IslandTile SecondIslandTile, Player Player)
        {

            int result = FirstIslandTile.columnNumber > SecondIslandTile.columnNumber ? FirstIslandTile.columnNumber - SecondIslandTile.columnNumber : SecondIslandTile.columnNumber - FirstIslandTile.columnNumber;

            if (result > 1)
            {
                return new ValidationResults() { IsValid = false, ErrorMessage = CanMoveErrorConstants.ONLY_MOVE_ONE_COLUMN };
            }

            return new ValidationResults() { IsValid = true };
        }
    }
}