using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MvcForbiddenIsland.Models.Interface
{
    public interface IIslandTile
    {
        int Id { get; set; }
        string Name { get; set; }
        MvcForbiddenIsland.Enum.Enums.TileState SubmergedState { get; set; }
        MvcForbiddenIsland.Enum.Enums.PlayerColour StartingTileForPlayer { get; set; }
    }
}
