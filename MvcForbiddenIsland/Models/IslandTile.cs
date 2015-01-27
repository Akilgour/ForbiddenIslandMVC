using MvcForbiddenIsland.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcForbiddenIsland.Models
{
    public class IslandTile : IIslandTile
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Enum.Enums.TileState SubmergedState { get; set; }
        public Enum.Enums.PlayerColour StartingTileForPlayer { get; set; }
        public bool HelicopterSite { get; set; }
    }
}