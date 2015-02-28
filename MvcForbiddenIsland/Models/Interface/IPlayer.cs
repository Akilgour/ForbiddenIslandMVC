using MvcForbiddenIsland.Enum;
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
        PlayerColour Colour { get; set; }
        TeasureCardDeckId PlayerHandId { get; set; }
    }
}
