using MvcForbiddenIsland.Enum;
using MvcForbiddenIsland.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcForbiddenIsland.Models
{
    public class Player : IPlayer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Action { get; set; }
        public PlayerColour Colour { get; set; }
        public TeasureCardDeckId PlayerHandId { get; set; }
        public bool HasEarthStoneTreasureStatue { get; set; }
        public bool HasStatueOfTheWindTreasureStatue { get; set; }
        public bool HasCrystalOfFireTreasureStatue { get; set; }
        public bool HasOceansChaliceTreasureStatue { get; set; }
    }
}