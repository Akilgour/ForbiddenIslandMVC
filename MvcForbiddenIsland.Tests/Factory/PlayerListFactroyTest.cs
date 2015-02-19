﻿using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcForbiddenIsland.Factory;
using MvcForbiddenIsland.Models;
using System.Linq;
using MvcForbiddenIsland.Constants;

namespace MvcForbiddenIsland.Tests.Factory
{
    /// <summary>
    /// Summary description for PlayerListFactroyTest
    /// </summary>
    [TestClass]
    public class PlayerListFactroyTest
    {
        [TestMethod]
        public void CreatePlayerList_IsValid()
        {
            //Arrange 
            var playerListFactory = new PlayerListFactory();

            //Act 
            var playerList = playerListFactory.Create();

            //Assert
            Assert.IsInstanceOfType(playerList, typeof(List<Player>));
        }

        [TestMethod]
        public void PlayerCountSix_IsValid()
        {
            //Arrange 
            var playerListFactory = new PlayerListFactory();

            //Act 
            var playerList = playerListFactory.Create();

            //Assert
            Assert.AreEqual(playerList.Count, 6);
        }

        
        [TestMethod]
        public void HasMessenger_IsValid()
        {
            //Arrange 
            var playerListFactory = new PlayerListFactory();

            //Act 
            var playerList = playerListFactory.Create();

            var item = playerList.SingleOrDefault(x => x.Name == "Messenger");

            //Assert
            Assert.AreEqual(item.Colour, Enum.Enums.PlayerColour.Grey);
            Assert.AreEqual(item.Action, PlayerConstants.MESSENGER_ACTION);
            Assert.AreEqual(item.Name, "Messenger");
        }

        [TestMethod]
        public void HasExplorer_IsValid()
        {
            //Arrange 
            var playerListFactory = new PlayerListFactory();

            //Act 
            var playerList = playerListFactory.Create();

            var item = playerList.SingleOrDefault(x => x.Name == "Explorer");

            //Assert
            Assert.AreEqual(item.Colour, Enum.Enums.PlayerColour.Green);
            Assert.AreEqual(item.Action, PlayerConstants.EXPLORER_ACTION);
            Assert.AreEqual(item.Name, "Explorer");
        }

        [TestMethod]
        public void HasDiver_IsValid()
        {
            //Arrange 
            var playerListFactory = new PlayerListFactory();

            //Act 
            var playerList = playerListFactory.Create();

            var item = playerList.SingleOrDefault(x => x.Name == "Diver");

            //Assert
            Assert.AreEqual(item.Colour, Enum.Enums.PlayerColour.Black);
            Assert.AreEqual(item.Action, PlayerConstants.DIVER_ACTION);
            Assert.AreEqual(item.Name, "Diver");
        }

        [TestMethod]
        public void HasPilot_IsValid()
        {
            //Arrange 
            var playerListFactory = new PlayerListFactory();

            //Act 
            var playerList = playerListFactory.Create();

            var item = playerList.SingleOrDefault(x => x.Name == "Pilot");

            //Assert
            Assert.AreEqual(item.Colour, Enum.Enums.PlayerColour.Blue);
            Assert.AreEqual(item.Action, PlayerConstants.PILOT_ACTION);
            Assert.AreEqual(item.Name, "Pilot");
        }

        [TestMethod]
        public void HasNavigator_IsValid()
        {
            //Arrange 
            var playerListFactory = new PlayerListFactory();

            //Act 
            var playerList = playerListFactory.Create();

            var item = playerList.SingleOrDefault(x => x.Name == "Navigator");

            //Assert
            Assert.AreEqual(item.Colour, Enum.Enums.PlayerColour.Yellow);
            Assert.AreEqual(item.Action, PlayerConstants.NAVIGATOR_ACTION);
            Assert.AreEqual(item.Name, "Navigator");
        }

        [TestMethod]
        public void HasEngineer_IsValid()
        {
            //Arrange 
            var playerListFactory = new PlayerListFactory();

            //Act 
            var playerList = playerListFactory.Create();

            var item = playerList.SingleOrDefault(x => x.Name == "Engineer");

            //Assert
            Assert.AreEqual(item.Colour, Enum.Enums.PlayerColour.Red);
            Assert.AreEqual(item.Action, PlayerConstants.ENGINEER_ACTION);
            Assert.AreEqual(item.Name, "Engineer");
        }
    }
}