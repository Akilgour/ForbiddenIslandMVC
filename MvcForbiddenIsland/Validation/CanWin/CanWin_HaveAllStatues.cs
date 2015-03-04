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
        public Models.ValidationResults CanWin(IslandTile FoolsLanding, List<TreasureCard> TreasureCards)
        {
            if (FoolsLanding.PlayersOnTile.Any(x => x.HasCrystalOfFireTreasureStatue)
              && FoolsLanding.PlayersOnTile.Any(x => x.HasEarthStoneTreasureStatue)
              && FoolsLanding.PlayersOnTile.Any(x => x.HasOceansChaliceTreasureStatue)
              && FoolsLanding.PlayersOnTile.Any(x => x.HasStatueOfTheWindTreasureStatue))
            {
                return new ValidationResults() { IsValid = true };
            }

            return new ValidationResults() { IsValid = false, ErrorMessage = CanWinConstants.DONT_HAVE_ALL_STATUES };
        }
    }
}