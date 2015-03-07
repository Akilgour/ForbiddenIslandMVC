using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcForbiddenIsland.Validation.CanLose;
using MvcForbiddenIsland.Models;
using System.Collections.Generic;

namespace MvcForbiddenIsland.Tests.Validation.CanLose
{
    [TestClass]
    public class CanLose_HelicopterTileGoneTest
    {
        [TestMethod]
        public void TileSubmergedStateNormal()
        {
            //Arrange 
            var canLose = new CanLose_HelicopterTileGone();
            var islandTile = new IslandTile();
            islandTile.Name = "Fools' Landing";
            islandTile.SubmergedState = Enum.TileState.Normal;
            List<IslandTile> islandBoard = new List<IslandTile>();
            islandBoard.Add(islandTile);

            //Act 
            var result = canLose.IsValid(islandBoard, 0);

            //Assert
            Assert.AreEqual(result.IsValid, true);
            Assert.AreEqual(result.ErrorMessage, null);
        }

        [TestMethod]
        public void TileSubmergedStateFlooded()
        {
            //Arrange 
            var canLose = new CanLose_HelicopterTileGone();
            var islandTile = new IslandTile();
            islandTile.Name = "Fools' Landing";
            islandTile.SubmergedState = Enum.TileState.Flodded;
            List<IslandTile> islandBoard = new List<IslandTile>();
            islandBoard.Add(islandTile);

            //Act 
            var result = canLose.IsValid(islandBoard, 0);

            //Assert
            Assert.AreEqual(result.IsValid, true);
            Assert.AreEqual(result.ErrorMessage, null);
        }

        [TestMethod]
        public void TileSubmergedStateGone()
        {
            //Arrange 
            var canLose = new CanLose_HelicopterTileGone();
            var islandTile = new IslandTile();
            islandTile.SubmergedState = Enum.TileState.Gone;
            islandTile.Name = "Fools' Landing";
            List<IslandTile> islandBoard = new List<IslandTile>();
            islandBoard.Add(islandTile);

            //Act 
            var result = canLose.IsValid(islandBoard, 0);

            //Assert
            Assert.AreEqual(result.IsValid, false);   
            Assert.AreEqual(result.ErrorMessage, "Tile Fools' Landing gone.");
        }
    }
}
