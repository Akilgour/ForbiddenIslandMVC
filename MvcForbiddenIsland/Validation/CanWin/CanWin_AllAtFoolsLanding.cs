using MvcForbiddenIsland.Constants;
using MvcForbiddenIsland.Models;
using MvcForbiddenIsland.Validation.CanWin.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcForbiddenIsland.Validation.CanWin
{
    public class CanWin_AllAtFoolsLanding : ICanWin
    {

        public Models.ValidationResults CanWin(IslandTile FoolsLanding)
        {

            if (FoolsLanding.PlayersOnTile.Count != 4)
            {
                var playerNames = new List<string>();
                foreach (var player in FoolsLanding.PlayersOnTile)
                {
                    playerNames.Add(player.Name);
                }

                string playerOnTile = string.Join(", ", playerNames);
                var commaIndex = playerOnTile.LastIndexOf(",");

                if (commaIndex != -1)
                {
                    playerOnTile = playerOnTile.Remove(commaIndex, 1);
                    playerOnTile = playerOnTile.Insert(commaIndex, " and");
                }

                return new ValidationResults() { IsValid = false, ErrorMessage = String.Format(CanWinConstants.AT_FOOLS_LANDING, playerOnTile) };
            }

            return new ValidationResults() { IsValid = true };
        }
    }
}