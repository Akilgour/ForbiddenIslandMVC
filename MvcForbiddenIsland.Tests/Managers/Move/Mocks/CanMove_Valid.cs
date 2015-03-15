using MvcForbiddenIsland.Models;
using MvcForbiddenIsland.Validation.CanMove;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcForbiddenIsland.Tests.Managers.Mocks
{
    public class CanMove_Valid : ICanMoveValidation
    {
        public ValidationResults IsValid(IslandTile FirstIslandTile, IslandTile SecondIslandTile, Player Player)
        {
            return new ValidationResults() { IsValid = true };
        }
    }
}
