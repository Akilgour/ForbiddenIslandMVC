using MvcForbiddenIsland.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcForbiddenIsland.Validation.CanLose
{
    public class CanLoseBase
    {

        public bool TileGone(IslandTile islandTile)
        {
            return (islandTile.SubmergedState == Enum.TileState.Gone);
        }
    }
}