using MvcForbiddenIsland.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcForbiddenIsland.Models
{
    public class TreasureCard : ITreasureCard
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Action { get; set; }
        public Enum.Enums.TreasureCardType TreasureCardType { get; set; }
        public int Order { get; set; }
        public Enum.Enums.TeasureCardDeckId DeckTheCardIsIn { get; set; }
    }
}