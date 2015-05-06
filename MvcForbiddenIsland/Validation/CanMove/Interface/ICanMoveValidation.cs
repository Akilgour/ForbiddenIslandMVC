using Model;
using MvcForbiddenIsland.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvcForbiddenIsland.Validation.CanMove
{
    public interface ICanMoveValidation
    {
        ValidationResults IsValid(IslandTile FirstIslandTile, IslandTile SecondIslandTile, Player Player);
    }
}
