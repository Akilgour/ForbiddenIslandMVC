using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcForbiddenIsland.Models.Interface
{
    public interface IPlayer
    {
        Guid Id { get; set; }
        string Name { get; set; }
        string Action { get; set; }
        MvcForbiddenIsland.Enum.Enums.PlayerColour Colour { get; set; }
        Enum.Enums.TeasureCardDeckId PlayerHandId { get; set; }
    }
}
