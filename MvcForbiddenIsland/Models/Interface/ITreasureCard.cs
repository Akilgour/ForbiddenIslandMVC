using MvcForbiddenIsland.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcForbiddenIsland.Models.Interface
{
    public interface ITreasureCard
    {
        Guid Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        string Action { get; set; }
        TreasureCardType TreasureCardType { get; set; }
        int Order { get; set; }
        TeasureCardDeckId DeckTheCardIsIn { get; set; }
    }
}
