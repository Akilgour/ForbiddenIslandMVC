using Model;
using MvcForbiddenIsland.Constants;
using MvcForbiddenIsland.Models;
using MvcForbiddenIsland.Validation.CanWin.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcForbiddenIsland.Validation.CanWin
{
    public class CanWin_AtFoolsLanding : ICanWin
    {

        public Models.ValidationResults CanWin(IslandTile FoolsLanding, List<TreasureCard> TreasureCards)
        {
            if (FoolsLanding.HelicopterSite)
            {
                return new ValidationResults() { IsValid = true };
            }
            else
            {
                return new ValidationResults() { IsValid = false, ErrorMessage = CanWinConstants.NOT_FOOLS_LANDING };
            }
        }
    }
}