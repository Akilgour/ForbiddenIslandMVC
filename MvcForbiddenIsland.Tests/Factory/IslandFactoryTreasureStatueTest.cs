using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcForbiddenIsland.Factory;
using System.Linq;
using MvcForbiddenIsland.Enum;

namespace MvcForbiddenIsland.Tests.Factory
{
    /// <summary>
    /// Summary description for IslandFactoryTreasureStatueTest
    /// </summary>
    [TestClass]
    public class IslandFactoryTreasureStatueTest
    {
        [TestMethod]
        public void TileTempleOfTheMoonCanHaveStatue()
        {
            //Arrange 
            var islandFactory = new IslandFactory();

            //Act 
            var island = islandFactory.Create();

            //Assert
            var islandTile = island.IslandBoard.SingleOrDefault(x => x.Name == "Temple of the Moon");
            Assert.AreEqual(islandTile.CanHaveStatue, TreasureStatue.EarthStone);
        }

        [TestMethod]
        public void TileTempleOfTheSunCanHaveStatue()
        {
            //Arrange 
            var islandFactory = new IslandFactory();

            //Act 
            var island = islandFactory.Create();

            //Assert
            var islandTile = island.IslandBoard.SingleOrDefault(x => x.Name == "Temple of the Sun");
            Assert.AreEqual(islandTile.CanHaveStatue, TreasureStatue.EarthStone);
        }
        
        [TestMethod]
        public void TileCoralPalaceCanHaveStatue()
        {
            //Arrange 
            var islandFactory = new IslandFactory();

            //Act 
            var island = islandFactory.Create();

            //Assert
            var islandTile = island.IslandBoard.SingleOrDefault(x => x.Name == "Coral Palace");
            Assert.AreEqual(islandTile.CanHaveStatue, TreasureStatue.OceansChalice);
        }

        [TestMethod]
        public void TileTidlePalaceCanHaveStatue()
        {
            //Arrange 
            var islandFactory = new IslandFactory();

            //Act 
            var island = islandFactory.Create();

            //Assert
            var islandTile = island.IslandBoard.SingleOrDefault(x => x.Name == "Tidal Palace");
            Assert.AreEqual(islandTile.CanHaveStatue, TreasureStatue.OceansChalice);
        }


        [TestMethod]
        public void TileCaveOfEmbersCanHaveStatue()
        {
            //Arrange 
            var islandFactory = new IslandFactory();

            //Act 
            var island = islandFactory.Create();

            //Assert
            var islandTile = island.IslandBoard.SingleOrDefault(x => x.Name == "Cave of Embers");
            Assert.AreEqual(islandTile.CanHaveStatue, TreasureStatue.CrystalOfFire);
        }


        [TestMethod]
        public void TileCaveOfShadowsCanHaveStatue()
        {
            //Arrange 
            var islandFactory = new IslandFactory();

            //Act 
            var island = islandFactory.Create();

            //Assert
            var islandTile = island.IslandBoard.SingleOrDefault(x => x.Name == "Cave of Shadows");
            Assert.AreEqual(islandTile.CanHaveStatue, TreasureStatue.CrystalOfFire);
        }
           
        [TestMethod]
        public void TileHowlingGardenCanHaveStatue()
        {
            //Arrange 
            var islandFactory = new IslandFactory();

            //Act 
            var island = islandFactory.Create();

            //Assert
            var islandTile = island.IslandBoard.SingleOrDefault(x => x.Name == "Howling Garden");
            Assert.AreEqual(islandTile.CanHaveStatue, TreasureStatue.StatueOfTheWind);
        }

        [TestMethod]
        public void TileWhisperingGardenCanHaveStatue()
        {
            //Arrange 
            var islandFactory = new IslandFactory();

            //Act 
            var island = islandFactory.Create();

            //Assert
            var islandTile = island.IslandBoard.SingleOrDefault(x => x.Name == "Whispering Garden");
            Assert.AreEqual(islandTile.CanHaveStatue, TreasureStatue.StatueOfTheWind);
        }

        [TestMethod]
        public void TileThatDontStatueCount20()
        {
            //Arrange 
            var islandFactory = new IslandFactory();

            //Act 
            var island = islandFactory.Create();

            //Assert
            var islandTileCount = island.IslandBoard.Count(x => x.CanHaveStatue == TreasureStatue.None);
            Assert.AreEqual(islandTileCount, 28);
        }


        [TestMethod]
        public void OneTileHasOceansChaliceStatue()
        {
            //Arrange 
            var islandFactory = new IslandFactory();

            //Act 
            var island = islandFactory.Create();

            //Assert
            var tiles = island.IslandBoard.Where(x => x.CanHaveStatue == TreasureStatue.OceansChalice);
            var hasTilesCount = tiles.Where(x => x.HasStatus).Count();
            Assert.AreEqual(hasTilesCount, 1);
        }

        [TestMethod]
        public void OneTileHasCrystalOfFireStatue()
        {
            //Arrange 
            var islandFactory = new IslandFactory();

            //Act 
            var island = islandFactory.Create();

            //Assert
            var tiles = island.IslandBoard.Where(x => x.CanHaveStatue == TreasureStatue.CrystalOfFire);
            var hasTilesCount = tiles.Where(x => x.HasStatus).Count();
            Assert.AreEqual(hasTilesCount, 1);
        }


        [TestMethod]
        public void OneTileHasEarthStoneStatue()
        {
            //Arrange 
            var islandFactory = new IslandFactory();

            //Act 
            var island = islandFactory.Create();

            //Assert
            var tiles = island.IslandBoard.Where(x => x.CanHaveStatue == TreasureStatue.EarthStone);
            var hasTilesCount = tiles.Where(x => x.HasStatus).Count();
            Assert.AreEqual(hasTilesCount, 1);
        }


        [TestMethod]
        public void OneTileHasStatueOfTheWindStatue()
        {
            //Arrange 
            var islandFactory = new IslandFactory();

            //Act 
            var island = islandFactory.Create();

            //Assert
            var tiles = island.IslandBoard.Where(x => x.CanHaveStatue == TreasureStatue.StatueOfTheWind);
            var hasTilesCount = tiles.Where(x => x.HasStatus).Count();
            Assert.AreEqual(hasTilesCount, 1);
        }
    }
}
