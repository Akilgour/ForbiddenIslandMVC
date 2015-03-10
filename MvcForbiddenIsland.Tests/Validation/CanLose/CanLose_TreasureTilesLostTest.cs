using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcForbiddenIsland.Models;
using System.Collections.Generic;
using MvcForbiddenIsland.Factory;
using MvcForbiddenIsland.Validation.CanLose;
using System.Linq;

namespace MvcForbiddenIsland.Tests.Validation.CanLose
{
    [TestClass]
    public class CanLose_TreasureTilesLostTest
    {
        private List<IslandTile> IslandBoard;
        private List<IslandTile> OceansChaliceTiles;
        private List<IslandTile> CrystalOfFireTiles;
        private List<IslandTile> StatueOfTheWindTiles;
        private List<IslandTile> EarthStoneTiles;

        private string OceansChaliceGone = "Oceans Chalice gone.";
        private string CrystalOfFireGone = "Crystal Of Fire gone.";
        private string StatueOfTheWindGone = "Statue Of The Wind gone.";
        private string EarthStoneGone = "Earth Stone gone.";
        private string AllGone = "Crystal Of Fire, Earth Stone, Oceans Chalice and Statue Of The Wind gone.";

        /// <summary>
        /// This will get run before every test
        /// </summary>
        [TestInitialize()]
        public void TestInitialize()
        {
            IslandBoard = new IslandFactory().Create().IslandBoard;
            OceansChaliceTiles = IslandBoard.Where(x => x.CanHaveStatue == Enum.TreasureStatue.OceansChalice).ToList();
            CrystalOfFireTiles = IslandBoard.Where(x => x.CanHaveStatue == Enum.TreasureStatue.CrystalOfFire).ToList();
            StatueOfTheWindTiles = IslandBoard.Where(x => x.CanHaveStatue == Enum.TreasureStatue.StatueOfTheWind).ToList();
            EarthStoneTiles = IslandBoard.Where(x => x.CanHaveStatue == Enum.TreasureStatue.EarthStone).ToList();
        }

        [TestMethod]
        public void BoardAtDefaultSettings()
        {
            //Arrange 
            var canLose = new CanLose_TreasureTilesLost();

            //Act           
            var result = canLose.IsValid(IslandBoard, 0);

            //Assert
            Assert.AreEqual(result.IsValid, true);
            Assert.AreEqual(result.ErrorMessage, null);
        }

        [TestMethod]
        public void OneOceansChaliceGone()
        {
            //Arrange 
            var canLose = new CanLose_TreasureTilesLost();
            OceansChaliceTiles.First().SubmergedState = Enum.TileState.Gone;

            //Act           
            var result = canLose.IsValid(IslandBoard, 0);

            //Assert
            Assert.AreEqual(result.IsValid, true);
            Assert.AreEqual(result.ErrorMessage, null);
        }

        [TestMethod]
        public void TwoOceansChaliceGone()
        {
            //Arrange 
            var canLose = new CanLose_TreasureTilesLost();
            OceansChaliceTiles.First().SubmergedState = Enum.TileState.Gone;
            OceansChaliceTiles.Last().SubmergedState = Enum.TileState.Gone;

            //Act           
            var result = canLose.IsValid(IslandBoard, 0);

            //Assert
            Assert.AreEqual(result.IsValid, false);
            Assert.AreEqual(result.ErrorMessage, OceansChaliceGone);
        }

        [TestMethod]
        public void LastOceansChaliceGone()
        {
            //Arrange 
            var canLose = new CanLose_TreasureTilesLost();
            OceansChaliceTiles.Last().SubmergedState = Enum.TileState.Gone;

            //Act           
            var result = canLose.IsValid(IslandBoard, 0);

            //Assert
            Assert.AreEqual(result.IsValid, true);
            Assert.AreEqual(result.ErrorMessage, null);
        }


        [TestMethod]
        public void OneCrystalOfFireGone()
        {
            //Arrange 
            var canLose = new CanLose_TreasureTilesLost();
            CrystalOfFireTiles.First().SubmergedState = Enum.TileState.Gone;

            //Act           
            var result = canLose.IsValid(IslandBoard, 0);

            //Assert
            Assert.AreEqual(result.IsValid, true);
            Assert.AreEqual(result.ErrorMessage, null);
        }

        [TestMethod]
        public void TwoCrystalOfFireGone()
        {
            //Arrange 
            var canLose = new CanLose_TreasureTilesLost();
            CrystalOfFireTiles.First().SubmergedState = Enum.TileState.Gone;
            CrystalOfFireTiles.Last().SubmergedState = Enum.TileState.Gone;

            //Act           
            var result = canLose.IsValid(IslandBoard, 0);

            //Assert
            Assert.AreEqual(result.IsValid, false);
            Assert.AreEqual(result.ErrorMessage, CrystalOfFireGone);
        }

        [TestMethod]
        public void LastCrystalOfFireGone()
        {
            //Arrange 
            var canLose = new CanLose_TreasureTilesLost();
            CrystalOfFireTiles.Last().SubmergedState = Enum.TileState.Gone;

            //Act           
            var result = canLose.IsValid(IslandBoard, 0);

            //Assert
            Assert.AreEqual(result.IsValid, true);
            Assert.AreEqual(result.ErrorMessage, null);
        }

        [TestMethod]
        public void OneStatueOfTheWindGone()
        {
            //Arrange 
            var canLose = new CanLose_TreasureTilesLost();
            StatueOfTheWindTiles.First().SubmergedState = Enum.TileState.Gone;

            //Act           
            var result = canLose.IsValid(IslandBoard, 0);

            //Assert
            Assert.AreEqual(result.IsValid, true);
            Assert.AreEqual(result.ErrorMessage, null);
        }

        [TestMethod]
        public void TwoStatueOfTheWindGone()
        {
            //Arrange 
            var canLose = new CanLose_TreasureTilesLost();
            StatueOfTheWindTiles.First().SubmergedState = Enum.TileState.Gone;
            StatueOfTheWindTiles.Last().SubmergedState = Enum.TileState.Gone;

            //Act           
            var result = canLose.IsValid(IslandBoard, 0);

            //Assert
            Assert.AreEqual(result.IsValid, false);
            Assert.AreEqual(result.ErrorMessage, StatueOfTheWindGone);
        }

        [TestMethod]
        public void LastStatueOfTheWindGone()
        {
            //Arrange 
            var canLose = new CanLose_TreasureTilesLost();
            StatueOfTheWindTiles.Last().SubmergedState = Enum.TileState.Gone;

            //Act           
            var result = canLose.IsValid(IslandBoard, 0);

            //Assert
            Assert.AreEqual(result.IsValid, true);
            Assert.AreEqual(result.ErrorMessage, null);
        }

        [TestMethod]
        public void OneEarthStoneGone()
        {
            //Arrange 
            var canLose = new CanLose_TreasureTilesLost();
            EarthStoneTiles.First().SubmergedState = Enum.TileState.Gone;

            //Act           
            var result = canLose.IsValid(IslandBoard, 0);

            //Assert
            Assert.AreEqual(result.IsValid, true);
            Assert.AreEqual(result.ErrorMessage, null);
        }

        [TestMethod]
        public void TwoEarthStoneGone()
        {
            //Arrange 
            var canLose = new CanLose_TreasureTilesLost();
            EarthStoneTiles.First().SubmergedState = Enum.TileState.Gone;
            EarthStoneTiles.Last().SubmergedState = Enum.TileState.Gone;

            //Act           
            var result = canLose.IsValid(IslandBoard, 0);

            //Assert
            Assert.AreEqual(result.IsValid, false);
            Assert.AreEqual(result.ErrorMessage, EarthStoneGone);
        }

        [TestMethod]
        public void LastEarthStoneGone()
        {
            //Arrange 
            var canLose = new CanLose_TreasureTilesLost();
            EarthStoneTiles.Last().SubmergedState = Enum.TileState.Gone;

            //Act           
            var result = canLose.IsValid(IslandBoard, 0);

            //Assert
            Assert.AreEqual(result.IsValid, true);
            Assert.AreEqual(result.ErrorMessage, null);
        }

        [TestMethod]
        public void OneOfEachGone()
        {
            //Arrange 
            var canLose = new CanLose_TreasureTilesLost();
            EarthStoneTiles.Last().SubmergedState = Enum.TileState.Gone;
            OceansChaliceTiles.First().SubmergedState = Enum.TileState.Gone;
            StatueOfTheWindTiles.Last().SubmergedState = Enum.TileState.Gone;
            CrystalOfFireTiles.First().SubmergedState = Enum.TileState.Gone;

            //Act           
            var result = canLose.IsValid(IslandBoard, 0);

            //Assert
            Assert.AreEqual(result.IsValid, true);
            Assert.AreEqual(result.ErrorMessage, null);
        }

        [TestMethod]
        public void AllTreasureTilesGone()
        {
            //Arrange 
            var canLose = new CanLose_TreasureTilesLost();
            EarthStoneTiles.Last().SubmergedState = Enum.TileState.Gone;
            OceansChaliceTiles.Last().SubmergedState = Enum.TileState.Gone;
            StatueOfTheWindTiles.Last().SubmergedState = Enum.TileState.Gone;
            CrystalOfFireTiles.Last().SubmergedState = Enum.TileState.Gone;

            EarthStoneTiles.First().SubmergedState = Enum.TileState.Gone;
            OceansChaliceTiles.First().SubmergedState = Enum.TileState.Gone;
            StatueOfTheWindTiles.First().SubmergedState = Enum.TileState.Gone;
            CrystalOfFireTiles.First().SubmergedState = Enum.TileState.Gone;

            //Act           
            var result = canLose.IsValid(IslandBoard, 0);

            //Assert
            Assert.AreEqual(result.IsValid, false);
            Assert.AreEqual(result.ErrorMessage, AllGone);
        }

        [TestMethod]
        public void AllTreasureTilesFlooded()
        {
            //Arrange 
            var canLose = new CanLose_TreasureTilesLost();
            EarthStoneTiles.Last().SubmergedState = Enum.TileState.Flodded;
            OceansChaliceTiles.First().SubmergedState = Enum.TileState.Flodded;
            StatueOfTheWindTiles.Last().SubmergedState = Enum.TileState.Flodded;
            CrystalOfFireTiles.Last().SubmergedState = Enum.TileState.Flodded;

            EarthStoneTiles.First().SubmergedState = Enum.TileState.Flodded;
            OceansChaliceTiles.First().SubmergedState = Enum.TileState.Flodded;
            StatueOfTheWindTiles.First().SubmergedState = Enum.TileState.Flodded;
            CrystalOfFireTiles.First().SubmergedState = Enum.TileState.Flodded;

            //Act           
            var result = canLose.IsValid(IslandBoard, 0);

            //Assert
            Assert.AreEqual(result.IsValid, true);
            Assert.AreEqual(result.ErrorMessage, null);
        }

        [TestMethod]
        public void OneOfEachFloodedOneOfEachGoneTreasureTilesFlooded()
        {
            //Arrange 
            var canLose = new CanLose_TreasureTilesLost();
            EarthStoneTiles.Last().SubmergedState = Enum.TileState.Flodded;
            OceansChaliceTiles.First().SubmergedState = Enum.TileState.Flodded;
            StatueOfTheWindTiles.Last().SubmergedState = Enum.TileState.Flodded;
            CrystalOfFireTiles.Last().SubmergedState = Enum.TileState.Flodded;

            EarthStoneTiles.First().SubmergedState = Enum.TileState.Gone;
            OceansChaliceTiles.First().SubmergedState = Enum.TileState.Gone;
            StatueOfTheWindTiles.First().SubmergedState = Enum.TileState.Gone;
            CrystalOfFireTiles.First().SubmergedState = Enum.TileState.Gone;

            //Act           
            var result = canLose.IsValid(IslandBoard, 0);

            //Assert
            Assert.AreEqual(result.IsValid, true);
            Assert.AreEqual(result.ErrorMessage, null);
        }
    }
}
