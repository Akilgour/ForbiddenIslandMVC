using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcForbiddenIsland.Validation.CanLose;
using MvcForbiddenIsland.Models;

namespace MvcForbiddenIsland.Tests.Validation.CanLose
{
    [TestClass]
    public class CanLoseTest
    {
        [TestMethod]
        public void TileSubmergedStateNormal()
        {
            //Arrange 
            var canLose = new CanLoseBase();
            var islandTile = new IslandTile();
            islandTile.SubmergedState = Enum.TileState.Normal;
      
            //Act 
            var result = canLose.TileGone(islandTile);

            //Assert
            Assert.AreEqual(result, false);
        }

        [TestMethod]
        public void TileSubmergedStateFlooded()
        {
            //Arrange 
            var canLose = new CanLoseBase();
            var islandTile = new IslandTile();
            islandTile.SubmergedState = Enum.TileState.Flodded;

            //Act 
            var result = canLose.TileGone(islandTile);

            //Assert
            Assert.AreEqual(result, false);
        }

        [TestMethod]
        public void TileSubmergedStateGone()
        {
            //Arrange 
            var canLose = new CanLoseBase();
            var islandTile = new IslandTile();
            islandTile.SubmergedState = Enum.TileState.Gone;

            //Act 
            var result = canLose.TileGone(islandTile);

            //Assert
            Assert.AreEqual(result, true);
        }
    }
}
