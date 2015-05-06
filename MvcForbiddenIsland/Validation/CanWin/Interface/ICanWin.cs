using Model;
using MvcForbiddenIsland.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcForbiddenIsland.Validation.CanWin.Interface
{
    public interface ICanWin
    {
        ValidationResults CanWin(IslandTile FoolsLanding, List<TreasureCard> TreasureCards);
    }
}