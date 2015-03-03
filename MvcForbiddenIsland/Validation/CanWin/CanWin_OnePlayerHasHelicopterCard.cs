using MvcForbiddenIsland.Constants;
using MvcForbiddenIsland.Models;
using MvcForbiddenIsland.Validation.CanWin.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcForbiddenIsland.Validation.CanMove
{
    public class CanWin_OnePlayerHasHelicopterCard : ICanWin
    {
        public Models.ValidationResults CanWin(IslandTile FoolsLanding, List<TreasureCard> TreasureCards)
        {

            var playerTreasureCards = TreasureCards.Where(x => x.DeckTheCardIsIn == Enum.TeasureCardDeckId.PlayerOneDeck ||
                                                    x.DeckTheCardIsIn == Enum.TeasureCardDeckId.PlayerTwoDeck ||
                                                    x.DeckTheCardIsIn == Enum.TeasureCardDeckId.PlayerThreeDeck ||
                                                    x.DeckTheCardIsIn == Enum.TeasureCardDeckId.PlayerFourDeck);

            if (playerTreasureCards.Any(x => x.Name == CardConstants.HELICOPTERLIFT_NAME))
            {
                return new ValidationResults() { IsValid = true };
            }

            return new ValidationResults() { IsValid = false, ErrorMessage = CanWinConstants.NO_HELICOTER_LIFT_CARD };
        }
    }
}