using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcForbiddenIsland.Models;
using System.Collections.Generic;
using MvcForbiddenIsland.Constants;
using MvcForbiddenIsland.Factory;
using System.Linq;
using MvcForbiddenIsland.Validation.CanLose;
using MvcForbiddenIsland.Enum;

namespace MvcForbiddenIsland.Tests.Validation.CanLose
{
    [TestClass]
    public class CanLose_PlayerTilesLostTest
    {

        private Player Diver;
        private Player Pilot;
        private List<IslandTile> IslandBoard;
        private string DiverHasDrowned = "Diver has drowned.";
        private string DiverAndPilotHasDrowned = "Diver and Pilot has drowned.";

        /// <summary>
        /// This will get run before every test
        /// </summary>
        [TestInitialize()]
        public void TestInitialize()
        {
             Diver = new Player() { Name = PlayerConstants.DIVER_NAME };
             Pilot = new Player() { Name = PlayerConstants.PILOT_NAME };

             IslandBoard = new IslandFactory().Create().IslandBoard;

            //Clears all the players on the board so there all wher they are testable, this save creating a mock
             var tileThatHavePlayers = IslandBoard.Where(x => x.PlayersOnTile.Any());

             foreach (var tile in tileThatHavePlayers)
             {
                 tile.PlayersOnTile = new List<Player>();
             }

        }

        [TestMethod]
        public void PlayerAtThreeXThreeAllTilesOkay()
        {
            //Arrange 
            var islandTile = IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 3);
            islandTile.PlayersOnTile.Add(Diver);
            var canLose = new CanLose_PlayerTilesLost();

            //Act           
            var result = canLose.IsValid(IslandBoard, 0);

            //Assert
            Assert.AreEqual(result.IsValid, true);
            Assert.AreEqual(result.ErrorMessage, null);
        }

        [TestMethod]
        public void PlayerAtThreeXThreeTileOnFloodedAllOthersOkay()
        {
            //Arrange 
            var islandTile = IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 3);
            islandTile.PlayersOnTile.Add(Diver);
            islandTile.SubmergedState = TileState.Flodded.ToString();

            var canLose = new CanLose_PlayerTilesLost();

            //Act           
            var result = canLose.IsValid(IslandBoard, 0);

            //Assert
            Assert.AreEqual(result.IsValid, true);
            Assert.AreEqual(result.ErrorMessage, null);
        }

        [TestMethod]
        public void PlayerAtThreeXThreeTileOnGoneAllOthersOkay()
        {
            //Arrange 
            var islandTile = IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 3);
            islandTile.PlayersOnTile.Add(Diver);
            islandTile.SubmergedState = TileState.Gone.ToString();

            var canLose = new CanLose_PlayerTilesLost();

            //Act           
            var result = canLose.IsValid(IslandBoard, 0);

            //Assert
            Assert.AreEqual(result.IsValid, true);
            Assert.AreEqual(result.ErrorMessage, null);
        }

        [TestMethod]
        public void PlayerAtThreeXThreeTileOnOkaySurroundedGone()
        {
            //Arrange 
            var islandTile = IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 3);
            islandTile.PlayersOnTile.Add(Diver);

            IslandBoard.Single(x => x.RowNumber == 2 && x.ColumnNumber == 2).SubmergedState = TileState.Gone.ToString();
            IslandBoard.Single(x => x.RowNumber == 2 && x.ColumnNumber == 3).SubmergedState = TileState.Gone.ToString();
            IslandBoard.Single(x => x.RowNumber == 2 && x.ColumnNumber == 4).SubmergedState = TileState.Gone.ToString();
          
            IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 2).SubmergedState = TileState.Gone.ToString();
            IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 3).SubmergedState = TileState.Normal.ToString();
            IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 4).SubmergedState = TileState.Gone.ToString();

            IslandBoard.Single(x => x.RowNumber == 4 && x.ColumnNumber == 2).SubmergedState = TileState.Gone.ToString();
            IslandBoard.Single(x => x.RowNumber == 4 && x.ColumnNumber == 3).SubmergedState = TileState.Gone.ToString();
            IslandBoard.Single(x => x.RowNumber == 4 && x.ColumnNumber == 4).SubmergedState = TileState.Gone.ToString();

            var canLose = new CanLose_PlayerTilesLost();

            //Act           
            var result = canLose.IsValid(IslandBoard, 0);

            //Assert
            Assert.AreEqual(result.IsValid, true);
            Assert.AreEqual(result.ErrorMessage, null);
        }

        [TestMethod]
        public void PlayerAtThreeXThreeTileOnFloddedSurroundedGone()
        {
            //Arrange 
            var islandTile = IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 3);
            islandTile.PlayersOnTile.Add(Diver);

            IslandBoard.Single(x => x.RowNumber == 2 && x.ColumnNumber == 2).SubmergedState = TileState.Gone.ToString();
            IslandBoard.Single(x => x.RowNumber == 2 && x.ColumnNumber == 3).SubmergedState = TileState.Gone.ToString();
            IslandBoard.Single(x => x.RowNumber == 2 && x.ColumnNumber == 4).SubmergedState = TileState.Gone.ToString();

            IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 2).SubmergedState = TileState.Gone.ToString();
            IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 3).SubmergedState = TileState.Flodded.ToString();
            IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 4).SubmergedState = TileState.Gone.ToString();

            IslandBoard.Single(x => x.RowNumber == 4 && x.ColumnNumber == 2).SubmergedState = TileState.Gone.ToString();
            IslandBoard.Single(x => x.RowNumber == 4 && x.ColumnNumber == 3).SubmergedState = TileState.Gone.ToString();
            IslandBoard.Single(x => x.RowNumber == 4 && x.ColumnNumber == 4).SubmergedState = TileState.Gone.ToString();

            var canLose = new CanLose_PlayerTilesLost();

            //Act           
            var result = canLose.IsValid(IslandBoard, 0);

            //Assert
            Assert.AreEqual(result.IsValid, true);
            Assert.AreEqual(result.ErrorMessage, null);
        }

        [TestMethod]
        public void PlayerAtThreeXThreeTileOnGoneSurroundedGone()
        {
            //Arrange 
            var islandTile = IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 3);
            islandTile.PlayersOnTile.Add(Diver);

            IslandBoard.Single(x => x.RowNumber == 2 && x.ColumnNumber == 2).SubmergedState = TileState.Gone.ToString();
            IslandBoard.Single(x => x.RowNumber == 2 && x.ColumnNumber == 3).SubmergedState = TileState.Gone.ToString();
            IslandBoard.Single(x => x.RowNumber == 2 && x.ColumnNumber == 4).SubmergedState = TileState.Gone.ToString();

            IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 2).SubmergedState = TileState.Gone.ToString();
            IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 3).SubmergedState = TileState.Gone.ToString();
            IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 4).SubmergedState = TileState.Gone.ToString();

            IslandBoard.Single(x => x.RowNumber == 4 && x.ColumnNumber == 2).SubmergedState = TileState.Gone.ToString();
            IslandBoard.Single(x => x.RowNumber == 4 && x.ColumnNumber == 3).SubmergedState = TileState.Gone.ToString();
            IslandBoard.Single(x => x.RowNumber == 4 && x.ColumnNumber == 4).SubmergedState = TileState.Gone.ToString();

            var canLose = new CanLose_PlayerTilesLost();

            //Act           
            var result = canLose.IsValid(IslandBoard, 0);

            //Assert
            Assert.AreEqual(result.IsValid, false);
            Assert.AreEqual(result.ErrorMessage, DiverHasDrowned);
        }

        [TestMethod]
        public void PlayerAtThreeXThreeTileOnGoneTwoTwoNormalRestGone()
        {
            //Arrange 
            var islandTile = IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 3);
            islandTile.PlayersOnTile.Add(Diver);

            IslandBoard.Single(x => x.RowNumber == 2 && x.ColumnNumber == 2).SubmergedState = TileState.Normal.ToString();
            IslandBoard.Single(x => x.RowNumber == 2 && x.ColumnNumber == 3).SubmergedState = TileState.Gone.ToString();
            IslandBoard.Single(x => x.RowNumber == 2 && x.ColumnNumber == 4).SubmergedState = TileState.Gone.ToString();

            IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 2).SubmergedState = TileState.Gone.ToString();
            IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 3).SubmergedState = TileState.Gone.ToString();
            IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 4).SubmergedState = TileState.Gone.ToString();

            IslandBoard.Single(x => x.RowNumber == 4 && x.ColumnNumber == 2).SubmergedState = TileState.Gone.ToString();
            IslandBoard.Single(x => x.RowNumber == 4 && x.ColumnNumber == 3).SubmergedState = TileState.Gone.ToString();
            IslandBoard.Single(x => x.RowNumber == 4 && x.ColumnNumber == 4).SubmergedState = TileState.Gone.ToString();

            var canLose = new CanLose_PlayerTilesLost();

            //Act           
            var result = canLose.IsValid(IslandBoard, 0);

            //Assert
            Assert.AreEqual(result.IsValid, true);
            Assert.AreEqual(result.ErrorMessage, null);
        }

        [TestMethod]
        public void PlayerAtThreeXThreeTileOnGoneTwoThreeNormalRestGone()
        {
            //Arrange 
            var islandTile = IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 3);
            islandTile.PlayersOnTile.Add(Diver);

            IslandBoard.Single(x => x.RowNumber == 2 && x.ColumnNumber == 2).SubmergedState = TileState.Gone.ToString();
            IslandBoard.Single(x => x.RowNumber == 2 && x.ColumnNumber == 3).SubmergedState = TileState.Normal.ToString();
            IslandBoard.Single(x => x.RowNumber == 2 && x.ColumnNumber == 4).SubmergedState = TileState.Gone.ToString();

            IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 2).SubmergedState = TileState.Gone.ToString();
            IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 3).SubmergedState = TileState.Gone.ToString();
            IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 4).SubmergedState = TileState.Gone.ToString();

            IslandBoard.Single(x => x.RowNumber == 4 && x.ColumnNumber == 2).SubmergedState = TileState.Gone.ToString();
            IslandBoard.Single(x => x.RowNumber == 4 && x.ColumnNumber == 3).SubmergedState = TileState.Gone.ToString();
            IslandBoard.Single(x => x.RowNumber == 4 && x.ColumnNumber == 4).SubmergedState = TileState.Gone.ToString();

            var canLose = new CanLose_PlayerTilesLost();

            //Act           
            var result = canLose.IsValid(IslandBoard, 0);

            //Assert
            Assert.AreEqual(result.IsValid, true);
            Assert.AreEqual(result.ErrorMessage, null);
        }

        [TestMethod]
        public void PlayerAtThreeXThreeTileOnGoneTwoFourNormalRestGone()
        {
            //Arrange 
            var islandTile = IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 3);
            islandTile.PlayersOnTile.Add(Diver);

            IslandBoard.Single(x => x.RowNumber == 2 && x.ColumnNumber == 2).SubmergedState = TileState.Gone.ToString();
            IslandBoard.Single(x => x.RowNumber == 2 && x.ColumnNumber == 3).SubmergedState = TileState.Gone.ToString();
            IslandBoard.Single(x => x.RowNumber == 2 && x.ColumnNumber == 4).SubmergedState = TileState.Normal.ToString();

            IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 2).SubmergedState = TileState.Gone.ToString();
            IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 3).SubmergedState = TileState.Gone.ToString();
            IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 4).SubmergedState = TileState.Gone.ToString();

            IslandBoard.Single(x => x.RowNumber == 4 && x.ColumnNumber == 2).SubmergedState = TileState.Gone.ToString();
            IslandBoard.Single(x => x.RowNumber == 4 && x.ColumnNumber == 3).SubmergedState = TileState.Gone.ToString();
            IslandBoard.Single(x => x.RowNumber == 4 && x.ColumnNumber == 4).SubmergedState = TileState.Gone.ToString();

            var canLose = new CanLose_PlayerTilesLost();

            //Act           
            var result = canLose.IsValid(IslandBoard, 0);

            //Assert
            Assert.AreEqual(result.IsValid, true);
            Assert.AreEqual(result.ErrorMessage, null);
        }

        [TestMethod]
        public void PlayerAtThreeXThreeTileOnGoneThreeTwoNormalRestGone()
        {
            //Arrange 
            var islandTile = IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 3);
            islandTile.PlayersOnTile.Add(Diver);

            IslandBoard.Single(x => x.RowNumber == 2 && x.ColumnNumber == 2).SubmergedState = TileState.Gone.ToString();
            IslandBoard.Single(x => x.RowNumber == 2 && x.ColumnNumber == 3).SubmergedState = TileState.Gone.ToString();
            IslandBoard.Single(x => x.RowNumber == 2 && x.ColumnNumber == 4).SubmergedState = TileState.Gone.ToString();

            IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 2).SubmergedState = TileState.Normal.ToString();
            IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 3).SubmergedState = TileState.Gone.ToString();
            IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 4).SubmergedState = TileState.Gone.ToString();

            IslandBoard.Single(x => x.RowNumber == 4 && x.ColumnNumber == 2).SubmergedState = TileState.Gone.ToString();
            IslandBoard.Single(x => x.RowNumber == 4 && x.ColumnNumber == 3).SubmergedState = TileState.Gone.ToString();
            IslandBoard.Single(x => x.RowNumber == 4 && x.ColumnNumber == 4).SubmergedState = TileState.Gone.ToString();

            var canLose = new CanLose_PlayerTilesLost();

            //Act           
            var result = canLose.IsValid(IslandBoard, 0);

            //Assert
            Assert.AreEqual(result.IsValid, true);
            Assert.AreEqual(result.ErrorMessage, null);
        }

        [TestMethod]
        public void PlayerAtThreeXThreeTileOnGoneThreeFourNormalRestGone()
        {
            //Arrange 
            var islandTile = IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 3);
            islandTile.PlayersOnTile.Add(Diver);

            IslandBoard.Single(x => x.RowNumber == 2 && x.ColumnNumber == 2).SubmergedState = TileState.Gone.ToString();
            IslandBoard.Single(x => x.RowNumber == 2 && x.ColumnNumber == 3).SubmergedState = TileState.Gone.ToString();
            IslandBoard.Single(x => x.RowNumber == 2 && x.ColumnNumber == 4).SubmergedState = TileState.Gone.ToString();

            IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 2).SubmergedState = TileState.Gone.ToString();
            IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 3).SubmergedState = TileState.Gone.ToString();
            IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 4).SubmergedState = TileState.Normal.ToString();

            IslandBoard.Single(x => x.RowNumber == 4 && x.ColumnNumber == 2).SubmergedState = TileState.Gone.ToString();
            IslandBoard.Single(x => x.RowNumber == 4 && x.ColumnNumber == 3).SubmergedState = TileState.Gone.ToString();
            IslandBoard.Single(x => x.RowNumber == 4 && x.ColumnNumber == 4).SubmergedState = TileState.Gone.ToString();

            var canLose = new CanLose_PlayerTilesLost();

            //Act           
            var result = canLose.IsValid(IslandBoard, 0);

            //Assert
            Assert.AreEqual(result.IsValid, true);
            Assert.AreEqual(result.ErrorMessage, null);
        }

        [TestMethod]
        public void PlayerAtThreeXThreeTileOnGoneFourTwoNormalRestGone()
        {
            //Arrange 
            var islandTile = IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 3);
            islandTile.PlayersOnTile.Add(Diver);

            IslandBoard.Single(x => x.RowNumber == 2 && x.ColumnNumber == 2).SubmergedState = TileState.Gone.ToString();
            IslandBoard.Single(x => x.RowNumber == 2 && x.ColumnNumber == 3).SubmergedState = TileState.Gone.ToString();
            IslandBoard.Single(x => x.RowNumber == 2 && x.ColumnNumber == 4).SubmergedState = TileState.Gone.ToString();

            IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 2).SubmergedState = TileState.Gone.ToString();
            IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 3).SubmergedState = TileState.Gone.ToString();
            IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 4).SubmergedState = TileState.Gone.ToString();

            IslandBoard.Single(x => x.RowNumber == 4 && x.ColumnNumber == 2).SubmergedState = TileState.Normal.ToString();
            IslandBoard.Single(x => x.RowNumber == 4 && x.ColumnNumber == 3).SubmergedState = TileState.Gone.ToString();
            IslandBoard.Single(x => x.RowNumber == 4 && x.ColumnNumber == 4).SubmergedState = TileState.Gone.ToString();

            var canLose = new CanLose_PlayerTilesLost();

            //Act           
            var result = canLose.IsValid(IslandBoard, 0);

            //Assert
            Assert.AreEqual(result.IsValid, true);
            Assert.AreEqual(result.ErrorMessage, null);
        }

        [TestMethod]
        public void PlayerAtThreeXThreeTileOnGoneFourThreeNormalRestGone()
        {
            //Arrange 
            var islandTile = IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 3);
            islandTile.PlayersOnTile.Add(Diver);

            IslandBoard.Single(x => x.RowNumber == 2 && x.ColumnNumber == 2).SubmergedState = TileState.Gone.ToString();
            IslandBoard.Single(x => x.RowNumber == 2 && x.ColumnNumber == 3).SubmergedState = TileState.Gone.ToString();
            IslandBoard.Single(x => x.RowNumber == 2 && x.ColumnNumber == 4).SubmergedState = TileState.Gone.ToString();

            IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 2).SubmergedState = TileState.Gone.ToString();
            IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 3).SubmergedState = TileState.Gone.ToString();
            IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 4).SubmergedState = TileState.Gone.ToString();

            IslandBoard.Single(x => x.RowNumber == 4 && x.ColumnNumber == 2).SubmergedState = TileState.Gone.ToString();
            IslandBoard.Single(x => x.RowNumber == 4 && x.ColumnNumber == 3).SubmergedState = TileState.Normal.ToString();
            IslandBoard.Single(x => x.RowNumber == 4 && x.ColumnNumber == 4).SubmergedState = TileState.Gone.ToString();

            var canLose = new CanLose_PlayerTilesLost();

            //Act           
            var result = canLose.IsValid(IslandBoard, 0);

            //Assert
            Assert.AreEqual(result.IsValid, true);
            Assert.AreEqual(result.ErrorMessage, null);
        }

        [TestMethod]
        public void PlayerAtThreeXThreeTileOnGoneFourFourNormalRestGone()
        {
            //Arrange 
            var islandTile = IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 3);
            islandTile.PlayersOnTile.Add(Diver);

            IslandBoard.Single(x => x.RowNumber == 2 && x.ColumnNumber == 2).SubmergedState = TileState.Gone.ToString();
            IslandBoard.Single(x => x.RowNumber == 2 && x.ColumnNumber == 3).SubmergedState = TileState.Gone.ToString();
            IslandBoard.Single(x => x.RowNumber == 2 && x.ColumnNumber == 4).SubmergedState = TileState.Gone.ToString();

            IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 2).SubmergedState = TileState.Gone.ToString();
            IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 3).SubmergedState = TileState.Gone.ToString();
            IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 4).SubmergedState = TileState.Gone.ToString();

            IslandBoard.Single(x => x.RowNumber == 4 && x.ColumnNumber == 2).SubmergedState = TileState.Gone.ToString();
            IslandBoard.Single(x => x.RowNumber == 4 && x.ColumnNumber == 3).SubmergedState = TileState.Gone.ToString();
            IslandBoard.Single(x => x.RowNumber == 4 && x.ColumnNumber == 4).SubmergedState = TileState.Normal.ToString();

            var canLose = new CanLose_PlayerTilesLost();

            //Act           
            var result = canLose.IsValid(IslandBoard, 0);

            //Assert
            Assert.AreEqual(result.IsValid, true);
            Assert.AreEqual(result.ErrorMessage, null);
        }



        [TestMethod]
        public void PlayerAtThreeXThreeTileOnGoneTwoTwoNormalRestFlodded()
        {
            //Arrange 
            var islandTile = IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 3);
            islandTile.PlayersOnTile.Add(Diver);

            IslandBoard.Single(x => x.RowNumber == 2 && x.ColumnNumber == 2).SubmergedState = TileState.Normal.ToString();
            IslandBoard.Single(x => x.RowNumber == 2 && x.ColumnNumber == 3).SubmergedState = TileState.Flodded.ToString();
            IslandBoard.Single(x => x.RowNumber == 2 && x.ColumnNumber == 4).SubmergedState = TileState.Flodded.ToString();

            IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 2).SubmergedState = TileState.Flodded.ToString();
            IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 3).SubmergedState = TileState.Flodded.ToString();
            IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 4).SubmergedState = TileState.Flodded.ToString();

            IslandBoard.Single(x => x.RowNumber == 4 && x.ColumnNumber == 2).SubmergedState = TileState.Flodded.ToString();
            IslandBoard.Single(x => x.RowNumber == 4 && x.ColumnNumber == 3).SubmergedState = TileState.Flodded.ToString();
            IslandBoard.Single(x => x.RowNumber == 4 && x.ColumnNumber == 4).SubmergedState = TileState.Flodded.ToString();

            var canLose = new CanLose_PlayerTilesLost();

            //Act           
            var result = canLose.IsValid(IslandBoard, 0);

            //Assert
            Assert.AreEqual(result.IsValid, true);
            Assert.AreEqual(result.ErrorMessage, null);
        }

        [TestMethod]
        public void PlayerAtThreeXThreeTileOnGoneTwoThreeNormalRestFlodded()
        {
            //Arrange 
            var islandTile = IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 3);
            islandTile.PlayersOnTile.Add(Diver);

            IslandBoard.Single(x => x.RowNumber == 2 && x.ColumnNumber == 2).SubmergedState = TileState.Flodded.ToString();
            IslandBoard.Single(x => x.RowNumber == 2 && x.ColumnNumber == 3).SubmergedState = TileState.Normal.ToString();
            IslandBoard.Single(x => x.RowNumber == 2 && x.ColumnNumber == 4).SubmergedState = TileState.Flodded.ToString();

            IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 2).SubmergedState = TileState.Flodded.ToString();
            IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 3).SubmergedState = TileState.Flodded.ToString();
            IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 4).SubmergedState = TileState.Flodded.ToString();

            IslandBoard.Single(x => x.RowNumber == 4 && x.ColumnNumber == 2).SubmergedState = TileState.Flodded.ToString();
            IslandBoard.Single(x => x.RowNumber == 4 && x.ColumnNumber == 3).SubmergedState = TileState.Flodded.ToString();
            IslandBoard.Single(x => x.RowNumber == 4 && x.ColumnNumber == 4).SubmergedState = TileState.Flodded.ToString();

            var canLose = new CanLose_PlayerTilesLost();

            //Act           
            var result = canLose.IsValid(IslandBoard, 0);

            //Assert
            Assert.AreEqual(result.IsValid, true);
            Assert.AreEqual(result.ErrorMessage, null);
        }

        [TestMethod]
        public void PlayerAtThreeXThreeTileOnGoneTwoFourNormalRestFlodded()
        {
            //Arrange 
            var islandTile = IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 3);
            islandTile.PlayersOnTile.Add(Diver);

            IslandBoard.Single(x => x.RowNumber == 2 && x.ColumnNumber == 2).SubmergedState = TileState.Flodded.ToString();
            IslandBoard.Single(x => x.RowNumber == 2 && x.ColumnNumber == 3).SubmergedState = TileState.Flodded.ToString();
            IslandBoard.Single(x => x.RowNumber == 2 && x.ColumnNumber == 4).SubmergedState = TileState.Normal.ToString();

            IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 2).SubmergedState = TileState.Flodded.ToString();
            IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 3).SubmergedState = TileState.Flodded.ToString();
            IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 4).SubmergedState = TileState.Flodded.ToString();

            IslandBoard.Single(x => x.RowNumber == 4 && x.ColumnNumber == 2).SubmergedState = TileState.Flodded.ToString();
            IslandBoard.Single(x => x.RowNumber == 4 && x.ColumnNumber == 3).SubmergedState = TileState.Flodded.ToString();
            IslandBoard.Single(x => x.RowNumber == 4 && x.ColumnNumber == 4).SubmergedState = TileState.Flodded.ToString();

            var canLose = new CanLose_PlayerTilesLost();

            //Act           
            var result = canLose.IsValid(IslandBoard, 0);

            //Assert
            Assert.AreEqual(result.IsValid, true);
            Assert.AreEqual(result.ErrorMessage, null);
        }

        [TestMethod]
        public void PlayerAtThreeXThreeTileOnGoneThreeTwoNormalRestFlodded()
        {
            //Arrange 
            var islandTile = IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 3);
            islandTile.PlayersOnTile.Add(Diver);

            IslandBoard.Single(x => x.RowNumber == 2 && x.ColumnNumber == 2).SubmergedState = TileState.Flodded.ToString();
            IslandBoard.Single(x => x.RowNumber == 2 && x.ColumnNumber == 3).SubmergedState = TileState.Flodded.ToString();
            IslandBoard.Single(x => x.RowNumber == 2 && x.ColumnNumber == 4).SubmergedState = TileState.Flodded.ToString();

            IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 2).SubmergedState = TileState.Normal.ToString();
            IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 3).SubmergedState = TileState.Flodded.ToString();
            IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 4).SubmergedState = TileState.Flodded.ToString();

            IslandBoard.Single(x => x.RowNumber == 4 && x.ColumnNumber == 2).SubmergedState = TileState.Flodded.ToString();
            IslandBoard.Single(x => x.RowNumber == 4 && x.ColumnNumber == 3).SubmergedState = TileState.Flodded.ToString();
            IslandBoard.Single(x => x.RowNumber == 4 && x.ColumnNumber == 4).SubmergedState = TileState.Flodded.ToString();

            var canLose = new CanLose_PlayerTilesLost();

            //Act           
            var result = canLose.IsValid(IslandBoard, 0);

            //Assert
            Assert.AreEqual(result.IsValid, true);
            Assert.AreEqual(result.ErrorMessage, null);
        }

        [TestMethod]
        public void PlayerAtThreeXThreeTileOnGoneThreeFourNormalRestFlodded()
        {
            //Arrange 
            var islandTile = IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 3);
            islandTile.PlayersOnTile.Add(Diver);

            IslandBoard.Single(x => x.RowNumber == 2 && x.ColumnNumber == 2).SubmergedState = TileState.Flodded.ToString();
            IslandBoard.Single(x => x.RowNumber == 2 && x.ColumnNumber == 3).SubmergedState = TileState.Flodded.ToString();
            IslandBoard.Single(x => x.RowNumber == 2 && x.ColumnNumber == 4).SubmergedState = TileState.Flodded.ToString();

            IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 2).SubmergedState = TileState.Flodded.ToString();
            IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 3).SubmergedState = TileState.Flodded.ToString();
            IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 4).SubmergedState = TileState.Normal.ToString();

            IslandBoard.Single(x => x.RowNumber == 4 && x.ColumnNumber == 2).SubmergedState = TileState.Flodded.ToString();
            IslandBoard.Single(x => x.RowNumber == 4 && x.ColumnNumber == 3).SubmergedState = TileState.Flodded.ToString();
            IslandBoard.Single(x => x.RowNumber == 4 && x.ColumnNumber == 4).SubmergedState = TileState.Flodded.ToString();

            var canLose = new CanLose_PlayerTilesLost();

            //Act           
            var result = canLose.IsValid(IslandBoard, 0);

            //Assert
            Assert.AreEqual(result.IsValid, true);
            Assert.AreEqual(result.ErrorMessage, null);
        }

        [TestMethod]
        public void PlayerAtThreeXThreeTileOnGoneFourTwoNormalRestFlodded()
        {
            //Arrange 
            var islandTile = IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 3);
            islandTile.PlayersOnTile.Add(Diver);

            IslandBoard.Single(x => x.RowNumber == 2 && x.ColumnNumber == 2).SubmergedState = TileState.Flodded.ToString();
            IslandBoard.Single(x => x.RowNumber == 2 && x.ColumnNumber == 3).SubmergedState = TileState.Flodded.ToString();
            IslandBoard.Single(x => x.RowNumber == 2 && x.ColumnNumber == 4).SubmergedState = TileState.Flodded.ToString();

            IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 2).SubmergedState = TileState.Flodded.ToString();
            IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 3).SubmergedState = TileState.Flodded.ToString();
            IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 4).SubmergedState = TileState.Flodded.ToString();

            IslandBoard.Single(x => x.RowNumber == 4 && x.ColumnNumber == 2).SubmergedState = TileState.Normal.ToString();
            IslandBoard.Single(x => x.RowNumber == 4 && x.ColumnNumber == 3).SubmergedState = TileState.Flodded.ToString();
            IslandBoard.Single(x => x.RowNumber == 4 && x.ColumnNumber == 4).SubmergedState = TileState.Flodded.ToString();

            var canLose = new CanLose_PlayerTilesLost();

            //Act           
            var result = canLose.IsValid(IslandBoard, 0);

            //Assert
            Assert.AreEqual(result.IsValid, true);
            Assert.AreEqual(result.ErrorMessage, null);
        }

        [TestMethod]
        public void PlayerAtThreeXThreeTileOnGoneFourThreeNormalRestFlodded()
        {
            //Arrange 
            var islandTile = IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 3);
            islandTile.PlayersOnTile.Add(Diver);

            IslandBoard.Single(x => x.RowNumber == 2 && x.ColumnNumber == 2).SubmergedState = TileState.Flodded.ToString();
            IslandBoard.Single(x => x.RowNumber == 2 && x.ColumnNumber == 3).SubmergedState = TileState.Flodded.ToString();
            IslandBoard.Single(x => x.RowNumber == 2 && x.ColumnNumber == 4).SubmergedState = TileState.Flodded.ToString();

            IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 2).SubmergedState = TileState.Flodded.ToString();
            IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 3).SubmergedState = TileState.Flodded.ToString();
            IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 4).SubmergedState = TileState.Flodded.ToString();

            IslandBoard.Single(x => x.RowNumber == 4 && x.ColumnNumber == 2).SubmergedState = TileState.Flodded.ToString();
            IslandBoard.Single(x => x.RowNumber == 4 && x.ColumnNumber == 3).SubmergedState = TileState.Normal.ToString();
            IslandBoard.Single(x => x.RowNumber == 4 && x.ColumnNumber == 4).SubmergedState = TileState.Flodded.ToString();

            var canLose = new CanLose_PlayerTilesLost();

            //Act           
            var result = canLose.IsValid(IslandBoard, 0);

            //Assert
            Assert.AreEqual(result.IsValid, true);
            Assert.AreEqual(result.ErrorMessage, null);
        }

        [TestMethod]
        public void PlayerAtThreeXThreeTileOnGoneFourFourNormalRestFlodded()
        {
            //Arrange 
            var islandTile = IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 3);
            islandTile.PlayersOnTile.Add(Diver);

            IslandBoard.Single(x => x.RowNumber == 2 && x.ColumnNumber == 2).SubmergedState = TileState.Flodded.ToString();
            IslandBoard.Single(x => x.RowNumber == 2 && x.ColumnNumber == 3).SubmergedState = TileState.Flodded.ToString();
            IslandBoard.Single(x => x.RowNumber == 2 && x.ColumnNumber == 4).SubmergedState = TileState.Flodded.ToString();

            IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 2).SubmergedState = TileState.Flodded.ToString();
            IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 3).SubmergedState = TileState.Flodded.ToString();
            IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 4).SubmergedState = TileState.Flodded.ToString();

            IslandBoard.Single(x => x.RowNumber == 4 && x.ColumnNumber == 2).SubmergedState = TileState.Flodded.ToString();
            IslandBoard.Single(x => x.RowNumber == 4 && x.ColumnNumber == 3).SubmergedState = TileState.Flodded.ToString();
            IslandBoard.Single(x => x.RowNumber == 4 && x.ColumnNumber == 4).SubmergedState = TileState.Normal.ToString();

            var canLose = new CanLose_PlayerTilesLost();

            //Act           
            var result = canLose.IsValid(IslandBoard, 0);

            //Assert
            Assert.AreEqual(result.IsValid, true);
            Assert.AreEqual(result.ErrorMessage, null);
        }
        
        [TestMethod]
        public void PlayerAtThreeXThreeAndPlayerAtFourXFourTileOnFloodedAllOthersOkay()
        {
            //Arrange 
            var islandTile = IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 3);
            islandTile.PlayersOnTile.Add(Diver);

             islandTile = IslandBoard.Single(x => x.RowNumber == 4 && x.ColumnNumber == 4);
            islandTile.PlayersOnTile.Add(Pilot);

            islandTile.SubmergedState = TileState.Flodded.ToString();

            var canLose = new CanLose_PlayerTilesLost();

            //Act           
            var result = canLose.IsValid(IslandBoard, 0);

            //Assert
            Assert.AreEqual(result.IsValid, true);
            Assert.AreEqual(result.ErrorMessage, null);
        }

        [TestMethod]
        public void PlayerAtThreeXThreeAndPlayerAtFourXFourTileOnGoneFourThreeNormalSurroundedGone()
        {
            //Arrange 
            var islandTile = IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 3);
            islandTile.PlayersOnTile.Add(Diver);
            islandTile = IslandBoard.Single(x => x.RowNumber == 4 && x.ColumnNumber == 4);
            islandTile.PlayersOnTile.Add(Pilot);

            IslandBoard.Single(x => x.RowNumber == 2 && x.ColumnNumber == 2).SubmergedState = TileState.Gone.ToString();
            IslandBoard.Single(x => x.RowNumber == 2 && x.ColumnNumber == 3).SubmergedState = TileState.Gone.ToString();
            IslandBoard.Single(x => x.RowNumber == 2 && x.ColumnNumber == 4).SubmergedState = TileState.Gone.ToString();

            IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 2).SubmergedState = TileState.Gone.ToString();
            IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 3).SubmergedState = TileState.Gone.ToString();
            IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 4).SubmergedState = TileState.Gone.ToString();

            IslandBoard.Single(x => x.RowNumber == 4 && x.ColumnNumber == 2).SubmergedState = TileState.Gone.ToString();
            IslandBoard.Single(x => x.RowNumber == 4 && x.ColumnNumber == 3).SubmergedState = TileState.Gone.ToString();
            IslandBoard.Single(x => x.RowNumber == 4 && x.ColumnNumber == 4).SubmergedState = TileState.Gone.ToString();

            var canLose = new CanLose_PlayerTilesLost();

            //Act           
            var result = canLose.IsValid(IslandBoard, 0);

            //Assert
            Assert.AreEqual(result.IsValid, false);
            Assert.AreEqual(result.ErrorMessage, DiverHasDrowned);
        }

        [TestMethod]
        public void PlayerAtThreeXThreeAndPlayerAtFourXFourEveryThingGone()
        {
            //Arrange 
            var islandTile = IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 3);
            islandTile.PlayersOnTile.Add(Diver);
            islandTile = IslandBoard.Single(x => x.RowNumber == 4 && x.ColumnNumber == 4);
            islandTile.PlayersOnTile.Add(Pilot);

            foreach(var tile in IslandBoard){
                tile.SubmergedState = TileState.Gone.ToString();
            }

            var canLose = new CanLose_PlayerTilesLost();

            //Act           
            var result = canLose.IsValid(IslandBoard, 0);

            //Assert
            Assert.AreEqual(result.IsValid, false);
            Assert.AreEqual(result.ErrorMessage, DiverAndPilotHasDrowned);
        }
        
        [TestMethod]
        public void PlayerAtOneXThreeeAndPlayerAtOneXFourEveryThingGone()
        {
            //Arrange 
            var islandTile = IslandBoard.Single(x => x.RowNumber == 1 && x.ColumnNumber == 3);
            islandTile.PlayersOnTile.Add(Diver);
            islandTile = IslandBoard.Single(x => x.RowNumber == 1 && x.ColumnNumber == 4);
            islandTile.PlayersOnTile.Add(Pilot);

            foreach (var tile in IslandBoard)
            {
                tile.SubmergedState = TileState.Gone.ToString();
            }

            var canLose = new CanLose_PlayerTilesLost();

            //Act           
            var result = canLose.IsValid(IslandBoard, 0);

            //Assert
            Assert.AreEqual(result.IsValid, false);
            Assert.AreEqual(result.ErrorMessage, DiverAndPilotHasDrowned);
        }

        [TestMethod]
        public void PlayerAtOneXThreeAndPlayerAtOneXFourEveryThingGone()
        {
            //Arrange 
            var islandTile = IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 1);
            islandTile.PlayersOnTile.Add(Diver);
            islandTile = IslandBoard.Single(x => x.RowNumber == 4 && x.ColumnNumber == 1);
            islandTile.PlayersOnTile.Add(Pilot);

            foreach (var tile in IslandBoard)
            {
                tile.SubmergedState = TileState.Gone.ToString();
            }

            var canLose = new CanLose_PlayerTilesLost();

            //Act           
            var result = canLose.IsValid(IslandBoard, 0);

            //Assert
            Assert.AreEqual(result.IsValid, false);
            Assert.AreEqual(result.ErrorMessage, DiverAndPilotHasDrowned);
        }

        [TestMethod]
        public void PlayerAtThreeXSixAndPlayerAtFourXSixEveryThingGone()
        {
            //Arrange 
            var islandTile = IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 6);
            islandTile.PlayersOnTile.Add(Diver);
            islandTile = IslandBoard.Single(x => x.RowNumber == 4 && x.ColumnNumber == 6);
            islandTile.PlayersOnTile.Add(Pilot);

            foreach (var tile in IslandBoard)
            {
                tile.SubmergedState = TileState.Gone.ToString();
            }

            var canLose = new CanLose_PlayerTilesLost();

            //Act           
            var result = canLose.IsValid(IslandBoard, 0);

            //Assert
            Assert.AreEqual(result.IsValid, false);
            Assert.AreEqual(result.ErrorMessage, DiverAndPilotHasDrowned);
        }

        [TestMethod]
        public void PlayerAtSixXThreeAndPlayerAtSixXFourEveryThingGone()
        {
            //Arrange 
            var islandTile = IslandBoard.Single(x => x.RowNumber == 6 && x.ColumnNumber == 3);
            islandTile.PlayersOnTile.Add(Diver);
            islandTile = IslandBoard.Single(x => x.RowNumber == 6 && x.ColumnNumber == 4);
            islandTile.PlayersOnTile.Add(Pilot);

            foreach (var tile in IslandBoard)
            {
                tile.SubmergedState = TileState.Gone.ToString();
            }

            var canLose = new CanLose_PlayerTilesLost();

            //Act           
            var result = canLose.IsValid(IslandBoard, 0);

            //Assert
            Assert.AreEqual(result.IsValid, false);
            Assert.AreEqual(result.ErrorMessage, DiverAndPilotHasDrowned);
        }


        [TestMethod]
        public void TwoPlayerOnSameTileEveryThingGone()
        {
            //Arrange 
            var islandTile = IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 3);
            islandTile.PlayersOnTile.Add(Diver);
            islandTile.PlayersOnTile.Add(Pilot);

            foreach (var tile in IslandBoard)
            {
                tile.SubmergedState = TileState.Gone.ToString();
            }

            var canLose = new CanLose_PlayerTilesLost();

            //Act           
            var result = canLose.IsValid(IslandBoard, 0);

            //Assert
            Assert.AreEqual(result.IsValid, false);
            Assert.AreEqual(result.ErrorMessage, DiverAndPilotHasDrowned);
        }

        [TestMethod]
        public void TwoPlayerOnSameTileEveryThingFlooded()
        {
            //Arrange 
            var islandTile = IslandBoard.Single(x => x.RowNumber == 3 && x.ColumnNumber == 3);
            islandTile.PlayersOnTile.Add(Diver);
            islandTile.PlayersOnTile.Add(Pilot);

            foreach (var tile in IslandBoard)
            {
                tile.SubmergedState = TileState.Flodded.ToString();
            }

            var canLose = new CanLose_PlayerTilesLost();

            //Act           
            var result = canLose.IsValid(IslandBoard, 0);

            //Assert
            Assert.AreEqual(result.IsValid, true);
            Assert.AreEqual(result.ErrorMessage, null);
        }
    }
}
