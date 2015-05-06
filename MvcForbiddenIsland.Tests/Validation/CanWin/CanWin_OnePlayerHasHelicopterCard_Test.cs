using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcForbiddenIsland.Validation.CanMove;
using MvcForbiddenIsland.Models;
using MvcForbiddenIsland.Constants;
using System.Linq;
using MvcForbiddenIsland.Factory;

namespace MvcForbiddenIsland.Tests.Validation.CanWin
{
    /// <summary>
    /// Summary description for CanWin_OnePlayerHasHelicopterCard_Test
    /// </summary>
    [TestClass]
    public class CanWin_OnePlayerHasHelicopterCard_Test
    {

        [TestMethod]
        public void ReturnsValidationResults()
        {
            //Arrange 
            var canWin = new CanWin_OnePlayerHasHelicopterCard();
            var islandTile = new IslandTile();
            var playerTreasureCards = new List<TreasureCard>();

            //Act 
            var result = canWin.CanWin(islandTile, playerTreasureCards);

            //Assert
            Assert.IsInstanceOfType(result, typeof(ValidationResults));
        }

        /// <summary>
        /// Creates a island tile and give it people
        /// </summary>
        /// <returns></returns>
        private static IslandTile CreateIslandTile()
        {
            var islandTile = new IslandTile();
            islandTile.PlayersOnTile = new List<Player>();

            var messenger = new Player() { Name = PlayerConstants.MESSENGER_NAME };
            var diver = new Player() { Name = PlayerConstants.DIVER_NAME };
            var explorer = new Player() { Name = PlayerConstants.EXPLORER_NAME };
            var pilot = new Player() { Name = PlayerConstants.PILOT_NAME };

            islandTile.PlayersOnTile.Add(diver);
            islandTile.PlayersOnTile.Add(messenger);
            islandTile.PlayersOnTile.Add(explorer);
            islandTile.PlayersOnTile.Add(pilot);

            return islandTile;
        }

        [TestMethod]
        public void NoOneHasAnyCards()
        {
            //Arrange 
            var canWin = new CanWin_OnePlayerHasHelicopterCard();

            var islandTile = CreateIslandTile();
            var treasureDeckFactory = new TreasureDeckFactory();
            var playerTreasureCards = new TreasureDrawDeckFactory(treasureDeckFactory.Create()).Create();

            //Act 
            var result = canWin.CanWin(islandTile, playerTreasureCards);

            //Assert
            Assert.AreEqual(result.IsValid, false);
            Assert.AreEqual(result.ErrorMessage, CanWinConstants.NO_HELICOTER_LIFT_CARD);
        }

        [TestMethod]
        public void PlayerOneHasOneSandBagCard()
        {
            //Arrange 
            var canWin = new CanWin_OnePlayerHasHelicopterCard();
            var islandTile = CreateIslandTile();

            var treasureDeckFactory = new TreasureDeckFactory();
            var playerTreasureCards = new TreasureDrawDeckFactory(treasureDeckFactory.Create()).Create();
            playerTreasureCards.First(x => x.Name == CardConstants.SANDBAG_NAME.ToString()).DeckTheCardIsIn = Enum.TeasureCardDeckId.PlayerOneDeck.ToString();

            //Act 
            var result = canWin.CanWin(islandTile, playerTreasureCards);

            //Assert
            Assert.AreEqual(result.IsValid, false);
            Assert.AreEqual(result.ErrorMessage, CanWinConstants.NO_HELICOTER_LIFT_CARD.ToString());
        }

        [TestMethod]
        public void PlayerTwoHasOneSandBagCard()
        {
            //Arrange 
            var canWin = new CanWin_OnePlayerHasHelicopterCard();
            var islandTile = CreateIslandTile();

            var treasureDeckFactory = new TreasureDeckFactory();
            var playerTreasureCards = new TreasureDrawDeckFactory(treasureDeckFactory.Create()).Create();
            playerTreasureCards.First(x => x.Name == CardConstants.SANDBAG_NAME.ToString()).DeckTheCardIsIn = Enum.TeasureCardDeckId.PlayerTwoDeck.ToString();

            //Act 
            var result = canWin.CanWin(islandTile, playerTreasureCards);

            //Assert
            Assert.AreEqual(result.IsValid, false);
            Assert.AreEqual(result.ErrorMessage, CanWinConstants.NO_HELICOTER_LIFT_CARD.ToString());
        }

        [TestMethod]
        public void PlayerThreeHasOneSandBagCard()
        {
            //Arrange 
            var canWin = new CanWin_OnePlayerHasHelicopterCard();
            var islandTile = CreateIslandTile();

            var treasureDeckFactory = new TreasureDeckFactory();
            var playerTreasureCards = new TreasureDrawDeckFactory(treasureDeckFactory.Create()).Create();
            playerTreasureCards.First(x => x.Name == CardConstants.SANDBAG_NAME.ToString()).DeckTheCardIsIn = Enum.TeasureCardDeckId.PlayerThreeDeck.ToString();

            //Act 
            var result = canWin.CanWin(islandTile, playerTreasureCards);

            //Assert
            Assert.AreEqual(result.IsValid, false);
            Assert.AreEqual(result.ErrorMessage, CanWinConstants.NO_HELICOTER_LIFT_CARD);
        }

        [TestMethod]
        public void PlayerFourHasOneSandBagCard()
        {
            //Arrange 
            var canWin = new CanWin_OnePlayerHasHelicopterCard();
            var islandTile = CreateIslandTile();

            var treasureDeckFactory = new TreasureDeckFactory();
            var playerTreasureCards = new TreasureDrawDeckFactory(treasureDeckFactory.Create()).Create();
            playerTreasureCards.First(x => x.Name == CardConstants.SANDBAG_NAME.ToString()).DeckTheCardIsIn = Enum.TeasureCardDeckId.PlayerFourDeck.ToString();

            //Act 
            var result = canWin.CanWin(islandTile, playerTreasureCards);

            //Assert
            Assert.AreEqual(result.IsValid, false);
            Assert.AreEqual(result.ErrorMessage, CanWinConstants.NO_HELICOTER_LIFT_CARD);
        }

        [TestMethod]
        public void PlayerOneHasOneHelicopterCard()
        {
            //Arrange 
            var canWin = new CanWin_OnePlayerHasHelicopterCard();
            var islandTile = CreateIslandTile();

            var treasureDeckFactory = new TreasureDeckFactory();
            var playerTreasureCards = new TreasureDrawDeckFactory(treasureDeckFactory.Create()).Create();
            playerTreasureCards.First(x => x.Name == CardConstants.HELICOPTERLIFT_NAME).DeckTheCardIsIn = Enum.TeasureCardDeckId.PlayerOneDeck.ToString();

            //Act 
            var result = canWin.CanWin(islandTile, playerTreasureCards);

            //Assert
            Assert.AreEqual(result.IsValid, true);
            Assert.AreEqual(result.ErrorMessage, null);
        }

        [TestMethod]
        public void PlayerTwoHasOneHelicopterCard()
        {
            //Arrange 
            var canWin = new CanWin_OnePlayerHasHelicopterCard();
            var islandTile = CreateIslandTile();

            var treasureDeckFactory = new TreasureDeckFactory();
            var playerTreasureCards = new TreasureDrawDeckFactory(treasureDeckFactory.Create()).Create();
            playerTreasureCards.First(x => x.Name == CardConstants.HELICOPTERLIFT_NAME).DeckTheCardIsIn = Enum.TeasureCardDeckId.PlayerTwoDeck.ToString();

            //Act 
            var result = canWin.CanWin(islandTile, playerTreasureCards);

            //Assert
            Assert.AreEqual(result.IsValid, true);
            Assert.AreEqual(result.ErrorMessage, null);
        }

        [TestMethod]
        public void PlayerThreeHasOneHelicopterCard()
        {
            //Arrange 
            var canWin = new CanWin_OnePlayerHasHelicopterCard();
            var islandTile = CreateIslandTile();

            var treasureDeckFactory = new TreasureDeckFactory();
            var playerTreasureCards = new TreasureDrawDeckFactory(treasureDeckFactory.Create()).Create();
            playerTreasureCards.First(x => x.Name == CardConstants.HELICOPTERLIFT_NAME).DeckTheCardIsIn = Enum.TeasureCardDeckId.PlayerThreeDeck.ToString();

            //Act 
            var result = canWin.CanWin(islandTile, playerTreasureCards);

            //Assert
            Assert.AreEqual(result.IsValid, true);
            Assert.AreEqual(result.ErrorMessage, null);
        }

        [TestMethod]
        public void PlayerFourHasOneHelicopterCard()
        {
            //Arrange 
            var canWin = new CanWin_OnePlayerHasHelicopterCard();
            var islandTile = CreateIslandTile();

            var treasureDeckFactory = new TreasureDeckFactory();
            var playerTreasureCards = new TreasureDrawDeckFactory(treasureDeckFactory.Create()).Create();
            playerTreasureCards.First(x => x.Name == CardConstants.HELICOPTERLIFT_NAME).DeckTheCardIsIn = Enum.TeasureCardDeckId.PlayerFourDeck.ToString();

            //Act 
            var result = canWin.CanWin(islandTile, playerTreasureCards);

            //Assert
            Assert.AreEqual(result.IsValid, true);
            Assert.AreEqual(result.ErrorMessage, null);
        }
    
    }
}
