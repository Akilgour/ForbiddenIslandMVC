using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcForbiddenIsland.Validation.CanWin;
using MvcForbiddenIsland.Models;
using System.Collections.Generic;
using MvcForbiddenIsland.Constants;

namespace MvcForbiddenIsland.Tests.Validation.CanWin
{
    [TestClass]
    public class CanWin_AllAtFoolsLandingTest
    {
        [TestMethod]
        public void ReturnsValidationResults()
        {
            //Arrange 
            var canWin = new CanWin_AllAtFoolsLanding();
            var islandTile = new IslandTile();
            islandTile.PlayersOnTile = new List<Player>();
            var playerList = new List<Player>();

            //Act 
            var result = canWin.CanWin(islandTile);

            //Assert
            Assert.IsInstanceOfType(result, typeof(ValidationResults));
        }

        [TestMethod]
        public void CanWinConstantsAndDriverName()
        {
            //Arrange 

            //Act 
            var diver = new Player() { Name = PlayerConstants.DIVER_NAME };
            string output = String.Format(CanWinConstants.AT_FOOLS_LANDING, diver.Name);

            //Assert
            Assert.AreEqual(output, "Only Diver at fools landing.");
        }

        [TestMethod]
        public void OnePlayersAtFoolsLanding()
        {
            //Arrange 
            var canWin = new CanWin_AllAtFoolsLanding();
            var islandTile = new IslandTile();
            islandTile.PlayersOnTile = new List<Player>();
            var playerList = new List<Player>();
            var diver = new Player() { Name = PlayerConstants.DIVER_NAME };
            islandTile.PlayersOnTile.Add(diver);

            //Act 
            var result = canWin.CanWin(islandTile);

            //Assert
            Assert.AreEqual(result.IsValid, false);
            Assert.AreEqual(result.ErrorMessage, "Only Diver at fools landing.");
        }

        [TestMethod]
        public void TwoPlayersAtFoolsLanding()
        {
            //Arrange 
            var canWin = new CanWin_AllAtFoolsLanding();
            var islandTile = new IslandTile();
            islandTile.PlayersOnTile = new List<Player>();
            var playerList = new List<Player>();

            var messenger = new Player() { Name = PlayerConstants.MESSENGER_NAME };
            var diver = new Player() { Name = PlayerConstants.DIVER_NAME };

            islandTile.PlayersOnTile.Add(diver);
            islandTile.PlayersOnTile.Add(messenger);

            //Act 
            var result = canWin.CanWin(islandTile);

            //Assert
            Assert.AreEqual(result.IsValid, false);
            Assert.AreEqual(result.ErrorMessage, "Only Diver and Messenger at fools landing.");
        }

        [TestMethod]
        public void ThreePlayersAtFoolsLanding()
        {
            //Arrange 
            var canWin = new CanWin_AllAtFoolsLanding();
            var islandTile = new IslandTile();
            islandTile.PlayersOnTile = new List<Player>();
            var playerList = new List<Player>();

            var messenger = new Player() { Name = PlayerConstants.MESSENGER_NAME };
            var diver = new Player() { Name = PlayerConstants.DIVER_NAME };
            var explorer = new Player() { Name = PlayerConstants.EXPLORER_NAME };

            islandTile.PlayersOnTile.Add(diver);
            islandTile.PlayersOnTile.Add(messenger);
            islandTile.PlayersOnTile.Add(explorer);

            //Act 
            var result = canWin.CanWin(islandTile);

            //Assert
            Assert.AreEqual(result.IsValid, false);
            Assert.AreEqual(result.ErrorMessage, "Only Diver, Messenger and Explorer at fools landing.");
        }

        [TestMethod]
        public void AllPlayersAtFoolsLanding()
        {
            //Arrange 
            var canWin = new CanWin_AllAtFoolsLanding();
            var islandTile = new IslandTile();
            islandTile.PlayersOnTile = new List<Player>();
            var playerList = new List<Player>();

            var messenger = new Player() { Name = PlayerConstants.MESSENGER_NAME };
            var diver = new Player() { Name = PlayerConstants.DIVER_NAME };
            var explorer = new Player() { Name = PlayerConstants.EXPLORER_NAME };
            var pilot = new Player() { Name = PlayerConstants.PILOT_NAME };

            islandTile.PlayersOnTile.Add(diver);
            islandTile.PlayersOnTile.Add(messenger);
            islandTile.PlayersOnTile.Add(explorer);
            islandTile.PlayersOnTile.Add(pilot);

            //Act 
            var result = canWin.CanWin(islandTile);

            //Assert
            Assert.AreEqual(result.IsValid, true);
            Assert.AreEqual(result.ErrorMessage, null);
        }
    }
}
