using MvcForbiddenIsland.Enum;
using MvcForbiddenIsland.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcForbiddenIsland.Factory
{
    public class TreasureDrawDeckFactory
    {
        private List<TreasureCard> treasureCardList;

        public TreasureDrawDeckFactory(List<TreasureCard> TreasureCardList)
        {
            treasureCardList = TreasureCardList;
        }

        public List<TreasureCard> Create()
        {
            foreach (var card in treasureCardList)
            {
                card.DeckTheCardIsIn = TeasureCardDeckId.DrawDeck;
            }
            return treasureCardList;
        }
    }
}