using MvcForbiddenIsland.Constants;
using MvcForbiddenIsland.Models;
using MvcForbiddenIsland.Validation.CanWin.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcForbiddenIsland.Validation.CanWin
{
    public class CanWin_HaveAllStatues : ICanWin
    {
        public Models.ValidationResults CanWin( IslandTile FoolsLanding, List<TreasureCard> TreasureCards)
        {
            bool hasCrystalOfFireTreasureStatue = false;
            bool hasEarthStoneTreasureStatue = false;
            bool hasOceansChaliceTreasureStatue = false;
            bool hasStatueOfTheWindTreasureStatue = false;

            foreach (var player in FoolsLanding.PlayersOnTile)
            {
                if (player.HasCrystalOfFireTreasureStatue)
                {
                    hasCrystalOfFireTreasureStatue = true;
                }
                if (player.HasEarthStoneTreasureStatue)
                {
                    hasEarthStoneTreasureStatue = true;
                }
                if (player.HasOceansChaliceTreasureStatue)
                {
                    hasOceansChaliceTreasureStatue = true;
                }
                if (player.HasStatueOfTheWindTreasureStatue)
                {
                    hasStatueOfTheWindTreasureStatue = true;
                }

            }

            if (hasCrystalOfFireTreasureStatue && hasEarthStoneTreasureStatue && hasOceansChaliceTreasureStatue && hasStatueOfTheWindTreasureStatue)
            {
                return new ValidationResults() { IsValid = true };
            }

            return new ValidationResults() { IsValid = false, ErrorMessage = CanWinConstants.DONT_HAVE_ALL_STATUES };
        }
    }
}