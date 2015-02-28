using MvcForbiddenIsland.Enum;
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
        public TileState SubmergedState { get; set; }
        public PlayerColour StartingTileForPlayer { get; set; }
        public bool HelicopterSite { get; set; }
        public int rowNumber { get; set; }
        public int columnNumber { get; set; }
        public List<Player> PlayersOnTile { get; set; }
    }
}