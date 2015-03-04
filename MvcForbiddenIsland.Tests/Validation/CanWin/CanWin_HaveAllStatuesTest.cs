using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcForbiddenIsland.Validation.CanWin;
using MvcForbiddenIsland.Models;
using System.Collections.Generic;
using MvcForbiddenIsland.Constants;
using System.Linq;

namespace MvcForbiddenIsland.Tests.Validation.CanWin
{
    [TestClass]
    public class CanWin_HaveAllStatuesTest
    {
        IslandTile islandTile;
        List<TreasureCard> treasureCards;

        /// <summary>
        /// This will get run before every test
        /// </summary>
        [TestInitialize()]
        public void TestInitialize() { 
            
            islandTile = new IslandTile();
            islandTile.PlayersOnTile = new List<Player>();

            var messenger = new Player() { Name = PlayerConstants.MESSENGER_NAME };
            var diver = new Player() { Name = PlayerConstants.DIVER_NAME };
            var explorer = new Player() { Name = PlayerConstants.EXPLORER_NAME };
            var pilot = new Player() { Name = PlayerConstants.PILOT_NAME };

            islandTile.PlayersOnTile.Add(diver);
            islandTile.PlayersOnTile.Add(messenger);
            islandTile.PlayersOnTile.Add(explorer);
            islandTile.PlayersOnTile.Add(pilot);

            treasureCards = new List<TreasureCard>();
        
        }

        [TestMethod]
        public void ReturnsValidationResults()
        {
            //Arrange 
            var canWin = new CanWin_HaveAllStatues();

            //Act 
            var result = canWin.CanWin(islandTile, treasureCards);

            //Assert
            Assert.IsInstanceOfType(result, typeof(ValidationResults));
        }

        [TestMethod]
        public void HaveNoStatues()
        {
            //Arrange 
            var canWin = new CanWin_HaveAllStatues();

            //Act 
            var result = canWin.CanWin(islandTile, treasureCards);

            //Assert
            Assert.AreEqual(result.IsValid, false);
            Assert.AreEqual(result.ErrorMessage, CanWinConstants.DONT_HAVE_ALL_STATUES);
        }

        [TestMethod]
        public void PlayerOneStatueOfTheWindTreasureStatue()
        {
            //Arrange 
            var canWin = new CanWin_HaveAllStatues();
            islandTile.PlayersOnTile.First(x => x.Name == PlayerConstants.MESSENGER_NAME).HasStatueOfTheWindTreasureStatue = true;
            islandTile.PlayersOnTile.First(x => x.Name == PlayerConstants.MESSENGER_NAME).HasOceansChaliceTreasureStatue = false;
            islandTile.PlayersOnTile.First(x => x.Name == PlayerConstants.MESSENGER_NAME).HasEarthStoneTreasureStatue = false;
            islandTile.PlayersOnTile.First(x => x.Name == PlayerConstants.MESSENGER_NAME).HasCrystalOfFireTreasureStatue = false;

            //Act 
            var result = canWin.CanWin(islandTile, treasureCards);

            //Assert
            Assert.AreEqual(result.IsValid, false);
            Assert.AreEqual(result.ErrorMessage, CanWinConstants.DONT_HAVE_ALL_STATUES);
        }

        [TestMethod]
        public void EachPlayerHasATreasureStatue()
        {
            //Arrange 
            var canWin = new CanWin_HaveAllStatues();
            islandTile.PlayersOnTile.First(x => x.Name == PlayerConstants.MESSENGER_NAME).HasStatueOfTheWindTreasureStatue = true;
            islandTile.PlayersOnTile.First(x => x.Name == PlayerConstants.DIVER_NAME).HasOceansChaliceTreasureStatue = true;
            islandTile.PlayersOnTile.First(x => x.Name == PlayerConstants.EXPLORER_NAME).HasEarthStoneTreasureStatue = true;
            islandTile.PlayersOnTile.First(x => x.Name == PlayerConstants.PILOT_NAME).HasCrystalOfFireTreasureStatue = true;

            //Act 
            var result = canWin.CanWin(islandTile, treasureCards);

            //Assert
            Assert.AreEqual(result.IsValid, true);
            Assert.AreEqual(result.ErrorMessage, null);
        }


        [TestMethod]
        public void PlayerOneHasAllTheStatues()
        {
            //Arrange 
            var canWin = new CanWin_HaveAllStatues();
            islandTile.PlayersOnTile.First(x => x.Name == PlayerConstants.MESSENGER_NAME).HasStatueOfTheWindTreasureStatue = true;
            islandTile.PlayersOnTile.First(x => x.Name == PlayerConstants.MESSENGER_NAME).HasOceansChaliceTreasureStatue = true;
            islandTile.PlayersOnTile.First(x => x.Name == PlayerConstants.MESSENGER_NAME).HasEarthStoneTreasureStatue = true;
            islandTile.PlayersOnTile.First(x => x.Name == PlayerConstants.MESSENGER_NAME).HasCrystalOfFireTreasureStatue = true;

            //Act 
            var result = canWin.CanWin(islandTile, treasureCards);

            //Assert
            Assert.AreEqual(result.IsValid, true);
            Assert.AreEqual(result.ErrorMessage, null);
        }

        [TestMethod]
        public void PlayerOneHasTwoTheStatues()
        {
            //Arrange 
            var canWin = new CanWin_HaveAllStatues();
            islandTile.PlayersOnTile.First(x => x.Name == PlayerConstants.MESSENGER_NAME).HasStatueOfTheWindTreasureStatue = true;
            islandTile.PlayersOnTile.First(x => x.Name == PlayerConstants.MESSENGER_NAME).HasOceansChaliceTreasureStatue = true;
            islandTile.PlayersOnTile.First(x => x.Name == PlayerConstants.MESSENGER_NAME).HasEarthStoneTreasureStatue = false;
            islandTile.PlayersOnTile.First(x => x.Name == PlayerConstants.MESSENGER_NAME).HasCrystalOfFireTreasureStatue = false;

            //Act 
            var result = canWin.CanWin(islandTile, treasureCards);

            //Assert
            Assert.AreEqual(result.IsValid, false);
            Assert.AreEqual(result.ErrorMessage, CanWinConstants.DONT_HAVE_ALL_STATUES);
        }

        [TestMethod]
        public void PlayerOneHasThreeTheStatues()
        {
            //Arrange 
            var canWin = new CanWin_HaveAllStatues();
            islandTile.PlayersOnTile.First(x => x.Name == PlayerConstants.MESSENGER_NAME).HasStatueOfTheWindTreasureStatue = true;
            islandTile.PlayersOnTile.First(x => x.Name == PlayerConstants.MESSENGER_NAME).HasOceansChaliceTreasureStatue = true;
            islandTile.PlayersOnTile.First(x => x.Name == PlayerConstants.MESSENGER_NAME).HasEarthStoneTreasureStatue = false;
            islandTile.PlayersOnTile.First(x => x.Name == PlayerConstants.MESSENGER_NAME).HasCrystalOfFireTreasureStatue = true;

            //Act 
            var result = canWin.CanWin(islandTile, treasureCards);

            //Assert
            Assert.AreEqual(result.IsValid, false);
            Assert.AreEqual(result.ErrorMessage, CanWinConstants.DONT_HAVE_ALL_STATUES);
        }

        [TestMethod]
        public void PlayerTwoHasAllTheStatues()
        {
            //Arrange 
            var canWin = new CanWin_HaveAllStatues();
            islandTile.PlayersOnTile.First(x => x.Name == PlayerConstants.DIVER_NAME).HasStatueOfTheWindTreasureStatue = true;
            islandTile.PlayersOnTile.First(x => x.Name == PlayerConstants.DIVER_NAME).HasOceansChaliceTreasureStatue = true;
            islandTile.PlayersOnTile.First(x => x.Name == PlayerConstants.DIVER_NAME).HasEarthStoneTreasureStatue = true;
            islandTile.PlayersOnTile.First(x => x.Name == PlayerConstants.DIVER_NAME).HasCrystalOfFireTreasureStatue = true;

            //Act 
            var result = canWin.CanWin(islandTile, treasureCards);

            //Assert
            Assert.AreEqual(result.IsValid, true);
            Assert.AreEqual(result.ErrorMessage, null);
        }

        [TestMethod]
        public void PlayerTwoHasTwoStatues()
        {
            //Arrange 
            var canWin = new CanWin_HaveAllStatues();
            islandTile.PlayersOnTile.First(x => x.Name == PlayerConstants.DIVER_NAME).HasStatueOfTheWindTreasureStatue = true;
            islandTile.PlayersOnTile.First(x => x.Name == PlayerConstants.DIVER_NAME).HasOceansChaliceTreasureStatue = false;
            islandTile.PlayersOnTile.First(x => x.Name == PlayerConstants.DIVER_NAME).HasEarthStoneTreasureStatue = true;
            islandTile.PlayersOnTile.First(x => x.Name == PlayerConstants.DIVER_NAME).HasCrystalOfFireTreasureStatue = false;

            //Act 
            var result = canWin.CanWin(islandTile, treasureCards);

            //Assert
            Assert.AreEqual(result.IsValid, false);
            Assert.AreEqual(result.ErrorMessage, CanWinConstants.DONT_HAVE_ALL_STATUES);
        }

        [TestMethod]
        public void PlayerTwoHasThreeStatues()
        {
            //Arrange 
            var canWin = new CanWin_HaveAllStatues();
            islandTile.PlayersOnTile.First(x => x.Name == PlayerConstants.DIVER_NAME).HasStatueOfTheWindTreasureStatue = true;
            islandTile.PlayersOnTile.First(x => x.Name == PlayerConstants.DIVER_NAME).HasOceansChaliceTreasureStatue = false;
            islandTile.PlayersOnTile.First(x => x.Name == PlayerConstants.DIVER_NAME).HasEarthStoneTreasureStatue = true;
            islandTile.PlayersOnTile.First(x => x.Name == PlayerConstants.DIVER_NAME).HasCrystalOfFireTreasureStatue = true;

            //Act 
            var result = canWin.CanWin(islandTile, treasureCards);

            //Assert
            Assert.AreEqual(result.IsValid, false);
            Assert.AreEqual(result.ErrorMessage, CanWinConstants.DONT_HAVE_ALL_STATUES);
        }

        [TestMethod]
        public void PlayerThreeHasAllTheStatues()
        {
            //Arrange 
            var canWin = new CanWin_HaveAllStatues();
            islandTile.PlayersOnTile.First(x => x.Name == PlayerConstants.EXPLORER_NAME).HasStatueOfTheWindTreasureStatue = true;
            islandTile.PlayersOnTile.First(x => x.Name == PlayerConstants.EXPLORER_NAME).HasOceansChaliceTreasureStatue = true;
            islandTile.PlayersOnTile.First(x => x.Name == PlayerConstants.EXPLORER_NAME).HasEarthStoneTreasureStatue = true;
            islandTile.PlayersOnTile.First(x => x.Name == PlayerConstants.EXPLORER_NAME).HasCrystalOfFireTreasureStatue = true;

            //Act 
            var result = canWin.CanWin(islandTile, treasureCards);

            //Assert
            Assert.AreEqual(result.IsValid, true);
            Assert.AreEqual(result.ErrorMessage, null);
        }

        [TestMethod]
        public void PlayerThreeHasTwoStatues()
        {
            //Arrange 
            var canWin = new CanWin_HaveAllStatues();
            islandTile.PlayersOnTile.First(x => x.Name == PlayerConstants.EXPLORER_NAME).HasStatueOfTheWindTreasureStatue = false;
            islandTile.PlayersOnTile.First(x => x.Name == PlayerConstants.EXPLORER_NAME).HasOceansChaliceTreasureStatue = false;
            islandTile.PlayersOnTile.First(x => x.Name == PlayerConstants.EXPLORER_NAME).HasEarthStoneTreasureStatue = true;
            islandTile.PlayersOnTile.First(x => x.Name == PlayerConstants.EXPLORER_NAME).HasCrystalOfFireTreasureStatue = true;

            //Act 
            var result = canWin.CanWin(islandTile, treasureCards);

            //Assert
            Assert.AreEqual(result.IsValid, false);
            Assert.AreEqual(result.ErrorMessage, CanWinConstants.DONT_HAVE_ALL_STATUES);
        }

        [TestMethod]
        public void PlayerThreeHasThreeStatues()
        {
            //Arrange 
            var canWin = new CanWin_HaveAllStatues();
            islandTile.PlayersOnTile.First(x => x.Name == PlayerConstants.EXPLORER_NAME).HasStatueOfTheWindTreasureStatue = true;
            islandTile.PlayersOnTile.First(x => x.Name == PlayerConstants.EXPLORER_NAME).HasOceansChaliceTreasureStatue = false;
            islandTile.PlayersOnTile.First(x => x.Name == PlayerConstants.EXPLORER_NAME).HasEarthStoneTreasureStatue = true;
            islandTile.PlayersOnTile.First(x => x.Name == PlayerConstants.EXPLORER_NAME).HasCrystalOfFireTreasureStatue = true;

            //Act 
            var result = canWin.CanWin(islandTile, treasureCards);

            //Assert
            Assert.AreEqual(result.IsValid, false);
            Assert.AreEqual(result.ErrorMessage, CanWinConstants.DONT_HAVE_ALL_STATUES);
        }

        [TestMethod]
        public void PlayerFourHasAllTheStatues()
        {
            //Arrange 
            var canWin = new CanWin_HaveAllStatues();
            islandTile.PlayersOnTile.First(x => x.Name == PlayerConstants.PILOT_NAME).HasStatueOfTheWindTreasureStatue = true;
            islandTile.PlayersOnTile.First(x => x.Name == PlayerConstants.PILOT_NAME).HasOceansChaliceTreasureStatue = true;
            islandTile.PlayersOnTile.First(x => x.Name == PlayerConstants.PILOT_NAME).HasEarthStoneTreasureStatue = true;
            islandTile.PlayersOnTile.First(x => x.Name == PlayerConstants.PILOT_NAME).HasCrystalOfFireTreasureStatue = true;

            //Act 
            var result = canWin.CanWin(islandTile, treasureCards);

            //Assert
            Assert.AreEqual(result.IsValid, true);
            Assert.AreEqual(result.ErrorMessage, null);
        }

        [TestMethod]
        public void PlayerFourHasTwoStatues()
        {
            //Arrange 
            var canWin = new CanWin_HaveAllStatues();
            islandTile.PlayersOnTile.First(x => x.Name == PlayerConstants.PILOT_NAME).HasStatueOfTheWindTreasureStatue = false;
            islandTile.PlayersOnTile.First(x => x.Name == PlayerConstants.PILOT_NAME).HasOceansChaliceTreasureStatue = true;
            islandTile.PlayersOnTile.First(x => x.Name == PlayerConstants.PILOT_NAME).HasEarthStoneTreasureStatue = false;
            islandTile.PlayersOnTile.First(x => x.Name == PlayerConstants.PILOT_NAME).HasCrystalOfFireTreasureStatue = true;

            //Act 
            var result = canWin.CanWin(islandTile, treasureCards);

            //Assert
            Assert.AreEqual(result.IsValid, false);
            Assert.AreEqual(result.ErrorMessage, CanWinConstants.DONT_HAVE_ALL_STATUES);
        }

        [TestMethod]
        public void PlayerFourHasThreeStatues()
        {
            //Arrange 
            var canWin = new CanWin_HaveAllStatues();
            islandTile.PlayersOnTile.First(x => x.Name == PlayerConstants.PILOT_NAME).HasStatueOfTheWindTreasureStatue = false;
            islandTile.PlayersOnTile.First(x => x.Name == PlayerConstants.PILOT_NAME).HasOceansChaliceTreasureStatue = true;
            islandTile.PlayersOnTile.First(x => x.Name == PlayerConstants.PILOT_NAME).HasEarthStoneTreasureStatue = false;
            islandTile.PlayersOnTile.First(x => x.Name == PlayerConstants.PILOT_NAME).HasCrystalOfFireTreasureStatue = true;

            //Act 
            var result = canWin.CanWin(islandTile, treasureCards);

            //Assert
            Assert.AreEqual(result.IsValid, false);
            Assert.AreEqual(result.ErrorMessage, CanWinConstants.DONT_HAVE_ALL_STATUES);
        }

        [TestMethod]
        public void PlayerOneHasThreePlayerTwoHasOneStatues()
        {
            //Arrange 
            var canWin = new CanWin_HaveAllStatues();
            islandTile.PlayersOnTile.First(x => x.Name == PlayerConstants.MESSENGER_NAME).HasStatueOfTheWindTreasureStatue = true;
            islandTile.PlayersOnTile.First(x => x.Name == PlayerConstants.MESSENGER_NAME).HasOceansChaliceTreasureStatue = true;
            islandTile.PlayersOnTile.First(x => x.Name == PlayerConstants.MESSENGER_NAME).HasEarthStoneTreasureStatue = true;
            islandTile.PlayersOnTile.First(x => x.Name == PlayerConstants.DIVER_NAME).HasCrystalOfFireTreasureStatue = true;

            //Act 
            var result = canWin.CanWin(islandTile, treasureCards);

            //Assert
            Assert.AreEqual(result.IsValid, true);
            Assert.AreEqual(result.ErrorMessage, null);
        }


        [TestMethod]
        public void PlayerOneHasThreePlayerThreeHasOneStatues()
        {
            //Arrange 
            var canWin = new CanWin_HaveAllStatues();
            islandTile.PlayersOnTile.First(x => x.Name == PlayerConstants.MESSENGER_NAME).HasStatueOfTheWindTreasureStatue = true;
            islandTile.PlayersOnTile.First(x => x.Name == PlayerConstants.MESSENGER_NAME).HasOceansChaliceTreasureStatue = true;
            islandTile.PlayersOnTile.First(x => x.Name == PlayerConstants.MESSENGER_NAME).HasEarthStoneTreasureStatue = true;
            islandTile.PlayersOnTile.First(x => x.Name == PlayerConstants.EXPLORER_NAME).HasCrystalOfFireTreasureStatue = true;

            //Act 
            var result = canWin.CanWin(islandTile, treasureCards);

            //Assert
            Assert.AreEqual(result.IsValid, true);
            Assert.AreEqual(result.ErrorMessage, null);
        }

        [TestMethod]
        public void PlayerOneHasThreePlayerFourHasOneStatues()
        {
            //Arrange 
            var canWin = new CanWin_HaveAllStatues();
            islandTile.PlayersOnTile.First(x => x.Name == PlayerConstants.MESSENGER_NAME).HasStatueOfTheWindTreasureStatue = true;
            islandTile.PlayersOnTile.First(x => x.Name == PlayerConstants.MESSENGER_NAME).HasOceansChaliceTreasureStatue = true;
            islandTile.PlayersOnTile.First(x => x.Name == PlayerConstants.MESSENGER_NAME).HasEarthStoneTreasureStatue = true;
            islandTile.PlayersOnTile.First(x => x.Name == PlayerConstants.PILOT_NAME).HasCrystalOfFireTreasureStatue = true;

            //Act 
            var result = canWin.CanWin(islandTile, treasureCards);

            //Assert
            Assert.AreEqual(result.IsValid, true);
            Assert.AreEqual(result.ErrorMessage, null);
        }

        [TestMethod]
        public void PlayerOneHasTwoPlayerTwoHasTwoStatues()
        {
            //Arrange 
            var canWin = new CanWin_HaveAllStatues();
            islandTile.PlayersOnTile.First(x => x.Name == PlayerConstants.MESSENGER_NAME).HasStatueOfTheWindTreasureStatue = true;
            islandTile.PlayersOnTile.First(x => x.Name == PlayerConstants.MESSENGER_NAME).HasOceansChaliceTreasureStatue = true;
            islandTile.PlayersOnTile.First(x => x.Name == PlayerConstants.DIVER_NAME).HasEarthStoneTreasureStatue = true;
            islandTile.PlayersOnTile.First(x => x.Name == PlayerConstants.DIVER_NAME).HasCrystalOfFireTreasureStatue = true;

            //Act 
            var result = canWin.CanWin(islandTile, treasureCards);

            //Assert
            Assert.AreEqual(result.IsValid, true);
            Assert.AreEqual(result.ErrorMessage, null);
        }

        [TestMethod]
        public void PlayerOneHasTwoPlayerThreeHasTwoStatues()
        {
            //Arrange 
            var canWin = new CanWin_HaveAllStatues();
            islandTile.PlayersOnTile.First(x => x.Name == PlayerConstants.MESSENGER_NAME).HasStatueOfTheWindTreasureStatue = true;
            islandTile.PlayersOnTile.First(x => x.Name == PlayerConstants.MESSENGER_NAME).HasOceansChaliceTreasureStatue = true;
            islandTile.PlayersOnTile.First(x => x.Name == PlayerConstants.EXPLORER_NAME).HasEarthStoneTreasureStatue = true;
            islandTile.PlayersOnTile.First(x => x.Name == PlayerConstants.EXPLORER_NAME).HasCrystalOfFireTreasureStatue = true;

            //Act 
            var result = canWin.CanWin(islandTile, treasureCards);

            //Assert
            Assert.AreEqual(result.IsValid, true);
            Assert.AreEqual(result.ErrorMessage, null);
        }

        [TestMethod]
        public void PlayerOneHasTwoPlayerFourHasTwoStatues()
        {
            //Arrange 
            var canWin = new CanWin_HaveAllStatues();
            islandTile.PlayersOnTile.First(x => x.Name == PlayerConstants.MESSENGER_NAME).HasStatueOfTheWindTreasureStatue = true;
            islandTile.PlayersOnTile.First(x => x.Name == PlayerConstants.MESSENGER_NAME).HasOceansChaliceTreasureStatue = true;
            islandTile.PlayersOnTile.First(x => x.Name == PlayerConstants.PILOT_NAME).HasEarthStoneTreasureStatue = true;
            islandTile.PlayersOnTile.First(x => x.Name == PlayerConstants.PILOT_NAME).HasCrystalOfFireTreasureStatue = true;

            //Act 
            var result = canWin.CanWin(islandTile, treasureCards);

            //Assert
            Assert.AreEqual(result.IsValid, true);
            Assert.AreEqual(result.ErrorMessage, null);
        }

        [TestMethod]
        public void PlayerOneHasTwoPlayerThreeHasOnePlayerFourOneStatues()
        {
            //Arrange 
            var canWin = new CanWin_HaveAllStatues();
            islandTile.PlayersOnTile.First(x => x.Name == PlayerConstants.MESSENGER_NAME).HasStatueOfTheWindTreasureStatue = true;
            islandTile.PlayersOnTile.First(x => x.Name == PlayerConstants.MESSENGER_NAME).HasOceansChaliceTreasureStatue = true;
            islandTile.PlayersOnTile.First(x => x.Name == PlayerConstants.EXPLORER_NAME).HasEarthStoneTreasureStatue = true;
            islandTile.PlayersOnTile.First(x => x.Name == PlayerConstants.PILOT_NAME).HasCrystalOfFireTreasureStatue = true;

            //Act 
            var result = canWin.CanWin(islandTile, treasureCards);

            //Assert
            Assert.AreEqual(result.IsValid, true);
            Assert.AreEqual(result.ErrorMessage, null);
        }
    }
}
