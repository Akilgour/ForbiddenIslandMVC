using MvcForbiddenIsland.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MvcForbiddenIsland.Models.Interface
{
    public interface IIslandTile
    {
        Guid Id { get; set; }
        string Name { get; set; }
        TileState SubmergedState { get; set; }
        PlayerColour StartingTileForPlayer { get; set; }
        bool HelicopterSite { get; set; }
        int rowNumber { get; set; }
        int columnNumber { get; set; }
        List<Player> PlayersOnTile { get; set; }
        TreasureStatue CanHaveStatue { get; set; }
        bool HasStatus { get; set; }
    }
}
