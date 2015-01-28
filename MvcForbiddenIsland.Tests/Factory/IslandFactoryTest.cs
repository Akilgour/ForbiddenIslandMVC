using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcForbiddenIsland.Factory;
using MvcForbiddenIsland.Models.Interface;
using System.Collections.Generic;
using MvcForbiddenIsland.Models;
using System.Linq;

namespace MvcForbiddenIsland.Tests.Factory
{
    [TestClass]
    public class IslandFactoryTest
    {
        [TestMethod]
        public void CreateReturnsIsland_IsValid()
        {
            //Arrange 
            var islandFactory = new IslandFactory();

            //Act 
            var island = islandFactory.Create();

            //Assert
            Assert.IsInstanceOfType(island, typeof(Island));
        }

        [TestMethod]
        public void CreateReturnsIslandWithListOfIslandTiles_IsValid()
        {
            //Arrange 
            var islandFactory = new IslandFactory();

            //Act 
            var island = islandFactory.Create();

            //Assert
            Assert.IsInstanceOfType(island.IslandBoard, typeof(List<IslandTile>));
        }

        [TestMethod]
        public void CreateReturnsIslandWithListOfIslandTiles_FirstItemNotNull_IsValid()
        {
            //Arrange 
            var islandFactory = new IslandFactory();

            //Act 
            var island = islandFactory.Create();

            //Assert
            var islandTile = island.IslandBoard.SingleOrDefault(x => x.Name == "Phantom Rock");
            Assert.AreNotEqual(islandTile, null);
        }

        [TestMethod]
        public void CreateReturnsIslandWithListOfIslandTiles_FirstItemIslandTile_IsValid()
        {
            //Arrange 
            var islandFactory = new IslandFactory();

            //Act 
            var island = islandFactory.Create();

            //Assert
            var islandTile = island.IslandBoard.SingleOrDefault(x => x.Name == "Phantom Rock");
            Assert.IsInstanceOfType(islandTile, typeof(IslandTile));
        }

        [TestMethod]
        public void CreateReturnsIslandWithListOfIslandTiles_FirstItemIslandTileIsPhantomRock_IsValid()
        {
            //Arrange 
            var islandFactory = new IslandFactory();

            //Act 
            var island = islandFactory.Create();

            //Assert
            var islandTile = island.IslandBoard.SingleOrDefault(x => x.Name == "Phantom Rock");
            Assert.AreEqual(islandTile.Name, "Phantom Rock");
        }
        
        [TestMethod]
        public void CreateReturnsIslandWithListOfIslandTiles_PhantomRockNotStartingPostions_IsValid()
        {
            //Arrange 
            var islandFactory = new IslandFactory();

            //Act 
            var island = islandFactory.Create();

            //Assert
            var islandTile = island.IslandBoard.SingleOrDefault(x => x.Name == "Phantom Rock");
            Assert.AreEqual(islandTile.StartingTileForPlayer, Enum.Enums.PlayerColour.None);
        }

        [TestMethod]
        public void CreateReturnsIslandWithListOfIslandTiles_SecondItemNotNull_IsValid()
        {
            //Arrange 
            var islandFactory = new IslandFactory();

            //Act 
            var island = islandFactory.Create();

            //Assert
            var islandTile = island.IslandBoard.SingleOrDefault(x => x.Name == "Silver Gate");
            Assert.AreNotEqual(islandTile, null);
        }

        [TestMethod]
        public void CreateReturnsIslandWithListOfIslandTiles_SecondItemIslandTile_IsValid()
        {
            //Arrange 
            var islandFactory = new IslandFactory();

            //Act 
            var island = islandFactory.Create();

            //Assert
            var islandTile = island.IslandBoard.SingleOrDefault(x => x.Name == "Silver Gate");
            Assert.IsInstanceOfType(islandTile, typeof(IslandTile));
        }

        [TestMethod]
        public void CreateReturnsIslandWithListOfIslandTiles_FirstItemIslandTileIsSilverGate_IsValid()
        {
            //Arrange 
            var islandFactory = new IslandFactory();

            //Act 
            var island = islandFactory.Create();

            //Assert
            var islandTile = island.IslandBoard.SingleOrDefault(x => x.Name == "Silver Gate");
            Assert.AreEqual(islandTile.Name, "Silver Gate");
        }

        [TestMethod]
        public void CreateReturnsIslandWithListOfIslandTiles_SilverGatStartingPostionsForGrey_IsValid()
        {
            //Arrange 
            var islandFactory = new IslandFactory();

            //Act 
            var island = islandFactory.Create();

            //Assert
            var islandTile = island.IslandBoard.SingleOrDefault(x => x.Name == "Silver Gate");
            Assert.AreEqual(islandTile.StartingTileForPlayer, Enum.Enums.PlayerColour.Grey);
        }

        [TestMethod]
        public void CreateReturnsIslandWithListOfIslandTiles_SilverGatNotHelicopterSite_IsValid()
        {
            //Arrange 
            var islandFactory = new IslandFactory();

            //Act 
            var island = islandFactory.Create();

            //Assert
            var islandTile = island.IslandBoard.SingleOrDefault(x => x.Name == "Silver Gate");
            Assert.AreEqual(islandTile.HelicopterSite, false);
        }

        [TestMethod]
        public void CreateReturnsIslandWithListOfIslandTiles_FoolsLandingStartingPostionsForBlue_IsValid()
        {
            //Arrange 
            var islandFactory = new IslandFactory();

            //Act 
            var island = islandFactory.Create();

            //Assert
            var islandTile = island.IslandBoard.SingleOrDefault(x => x.Name == "Fools' Landing");
            Assert.AreEqual(islandTile.StartingTileForPlayer, Enum.Enums.PlayerColour.Blue);
        }


        [TestMethod]
        public void CreateReturnsIslandWithListOfIslandTiles_FoolsLandingHelicopterSite_IsValid()
        {
            //Arrange 
            var islandFactory = new IslandFactory();

            //Act 
            var island = islandFactory.Create();

            //Assert
            var islandTile = island.IslandBoard.SingleOrDefault(x => x.Name == "Fools' Landing");
            Assert.AreEqual(islandTile.HelicopterSite, true);
        }

        [TestMethod]
        public void CreateReturnsIslandWithListOfIslandTiles_GoldGateStartingPostionsForYellow_IsValid()
        {
            //Arrange 
            var islandFactory = new IslandFactory();

            //Act 
            var island = islandFactory.Create();

            //Assert
            var islandTile = island.IslandBoard.SingleOrDefault(x => x.Name == "Gold Gate");
            Assert.AreEqual(islandTile.StartingTileForPlayer, Enum.Enums.PlayerColour.Yellow);
        }

        [TestMethod]
        public void CreateReturnsIslandWithListOfIslandTiles_IronGateStartingPostionsForBlack_IsValid()
        {
            //Arrange 
            var islandFactory = new IslandFactory();

            //Act 
            var island = islandFactory.Create();

            //Assert
            var islandTile = island.IslandBoard.SingleOrDefault(x => x.Name == "Iron Gate");
            Assert.AreEqual(islandTile.StartingTileForPlayer, Enum.Enums.PlayerColour.Black);
        }

        [TestMethod]
        public void CreateReturnsIslandWithListOfIslandTiles_BronzeGateStartingPostionsForRed_IsValid()
        {
            //Arrange 
            var islandFactory = new IslandFactory();

            //Act 
            var island = islandFactory.Create();

            //Assert
            var islandTile = island.IslandBoard.SingleOrDefault(x => x.Name == "Bronze Gate");
            Assert.AreEqual(islandTile.StartingTileForPlayer, Enum.Enums.PlayerColour.Red);
        }

        [TestMethod]
        public void CreateReturnsIslandWithListOfIslandTiles_CopperGateStartingPostionsForGreen_IsValid()
        {
            //Arrange 
            var islandFactory = new IslandFactory();

            //Act 
            var island = islandFactory.Create();

            //Assert
            var islandTile = island.IslandBoard.SingleOrDefault(x => x.Name == "Copper Gate");
            Assert.AreEqual(islandTile.StartingTileForPlayer, Enum.Enums.PlayerColour.Green);
        }

        [TestMethod]
        public void CreateReturnsIslandWithListOfIslandTiles_TilesCountTwentyFour_IsValid()
        {
            //Arrange 
            var islandFactory = new IslandFactory();

            //Act 
            var island = islandFactory.Create();

            //Assert
            var islandTileCount = island.IslandBoard.Count();
            Assert.AreEqual(islandTileCount, 24);
        }

        [TestMethod]
        public void CreateReturnsIslandWithListOfIslandTiles_StartingPlayerCountSix_IsValid()
        {
            //Arrange 
            var islandFactory = new IslandFactory();

            //Act 
            var island = islandFactory.Create();

            //Assert
            var islandTileCount = island.IslandBoard.Where(x => x.StartingTileForPlayer != Enum.Enums.PlayerColour.None).Count();
            Assert.AreEqual(islandTileCount, 6);
        }


        [TestMethod]
        public void CreateReturnsIslandWithListOfIslandTiles_IdHasValue_IsValid()
        {
            //Arrange 
            var islandFactory = new IslandFactory();

            //Act 
            var island = islandFactory.Create();

            //Assert
            //var islandTileCount = island.IslandBoard.Where(x => x.StartingTileForPlayer != Enum.Enums.PlayerColour.None).Count();
            //Assert.AreEqual(islandTileCount, 6);
            foreach (var islandTile in island.IslandBoard)
            {
                Assert.AreNotEqual(islandTile.Id, Guid.Empty);
            }
        }
    }
}
