using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcForbiddenIsland.Models;
using System.Collections.Generic;
using MvcForbiddenIsland.Factory;

namespace MvcForbiddenIsland.Tests.Factory
{
    [TestClass]
    public class TreasureDrawDeckFactoryTest
    {
        [TestMethod]
        public void Create_IsValid()
        {     //Arrange 
            var deck = new List<TreasureCard>();
            var factory = new TreasureDrawDeckFactory(deck);

            //Act 
            var treasureCardDeck = factory.Create();

            //Assert
            Assert.IsInstanceOfType(treasureCardDeck, typeof(List<TreasureCard>));
        }
      
        [TestMethod]
        public void AllCardMarkedInDrawDeck_IsValid()
        {     
            //Arrange 
            var treasureDeckFactory = new TreasureDeckFactory();
            var deck = treasureDeckFactory.Create();
            var factory = new TreasureDrawDeckFactory(deck);

            //Act 
            var treasureCardDeck = factory.Create();

            //Assert
            foreach (var card in treasureCardDeck)
            {
                Assert.AreEqual(card.DeckTheCardIsIn, Enum.Enums.TeasureCardDeckId.DrawDeck);
            }
        }



    }
}
