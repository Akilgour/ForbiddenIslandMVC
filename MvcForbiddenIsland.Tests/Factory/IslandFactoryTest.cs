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
        public void IslandTilesThatAreMottSea_TilesCountTwentyFour_IsValid()
        {
            //Arrange 
            var islandFactory = new IslandFactory();

            //Act 
            var island = islandFactory.Create();

            //Assert
            var islandTileCount = island.IslandBoard.Where(x => x.Name != "Sea").Count();
            Assert.AreEqual(islandTileCount, 24);
        }

        [TestMethod]
        public void CreateReturnsIslandWithListOfIslandTiles_TilesCountThirtySix_IsValid()
        {
            //Arrange 
            var islandFactory = new IslandFactory();

            //Act 
            var island = islandFactory.Create();

            //Assert
            var islandTileCount = island.IslandBoard.Count();
            Assert.AreEqual(islandTileCount, 36);
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
            foreach (var islandTile in island.IslandBoard)
            {
                Assert.AreNotEqual(islandTile.Id, Guid.Empty);
            }
        }


        [TestMethod]
        public void NotInAlphabeticalOrder_IsValid()
        {
            //Arrange 
            var islandFactory = new IslandFactory();

            //Act 
            var island = islandFactory.Create();

            var zero = (island.IslandBoard[0].Name == "Breakers Bridge");
            var one = (island.IslandBoard[1].Name == "Bronze Gate");
            var two = (island.IslandBoard[2].Name == "Cave of Embers");

            //Assert
            Assert.IsFalse((zero && one && two));
        }

        [TestMethod]
        public void TileIsAtOneThree_IsValid()
        {
            //Arrange 
            var islandFactory = new IslandFactory();

            //Act 
            var island = islandFactory.Create();

            //Assert
            Assert.AreEqual(island.IslandBoard[0].rowNumber, 1);
            Assert.AreEqual(island.IslandBoard[0].columnNumber, 3);
        }

        [TestMethod]
        public void TileIsAtOneFour_IsValid()
        {
            //Arrange 
            var islandFactory = new IslandFactory();

            //Act 
            var island = islandFactory.Create();

            //Assert
            Assert.AreEqual(island.IslandBoard[1].rowNumber, 1);
            Assert.AreEqual(island.IslandBoard[1].columnNumber, 4);
        }

        [TestMethod]
        public void TileIsAtTwoTwo_IsValid()
        {
            //Arrange 
            var islandFactory = new IslandFactory();

            //Act 
            var island = islandFactory.Create();

            //Assert
            Assert.AreEqual(island.IslandBoard[2].rowNumber, 2);
            Assert.AreEqual(island.IslandBoard[2].columnNumber, 2);
        }

        [TestMethod]
        public void TileIsAtTwoThree_IsValid()
        {
            //Arrange 
            var islandFactory = new IslandFactory();

            //Act 
            var island = islandFactory.Create();

            //Assert
            Assert.AreEqual(island.IslandBoard[3].rowNumber, 2);
            Assert.AreEqual(island.IslandBoard[3].columnNumber, 3);
        }

        [TestMethod]
        public void TileIsAtTwoFour_IsValid()
        {
            //Arrange 
            var islandFactory = new IslandFactory();

            //Act 
            var island = islandFactory.Create();

            //Assert
            Assert.AreEqual(island.IslandBoard[4].rowNumber, 2);
            Assert.AreEqual(island.IslandBoard[4].columnNumber, 4);
        }

        [TestMethod]
        public void TileIsAtTwoFive_IsValid()
        {
            //Arrange 
            var islandFactory = new IslandFactory();

            //Act 
            var island = islandFactory.Create();

            //Assert
            Assert.AreEqual(island.IslandBoard[5].rowNumber, 2);
            Assert.AreEqual(island.IslandBoard[5].columnNumber, 5);
        }

        [TestMethod]
        public void TileIsAtThreeOne_IsValid()
        {
            //Arrange 
            var islandFactory = new IslandFactory();

            //Act 
            var island = islandFactory.Create();

            //Assert
            Assert.AreEqual(island.IslandBoard[6].rowNumber, 3);
            Assert.AreEqual(island.IslandBoard[6].columnNumber, 1);
        }

        [TestMethod]
        public void TileIsAtThreeTwo_IsValid()
        {
            //Arrange 
            var islandFactory = new IslandFactory();

            //Act 
            var island = islandFactory.Create();

            //Assert
            Assert.AreEqual(island.IslandBoard[7].rowNumber, 3);
            Assert.AreEqual(island.IslandBoard[7].columnNumber, 2);
        }

        [TestMethod]
        public void TileIsAtThreeThree_IsValid()
        {
            //Arrange 
            var islandFactory = new IslandFactory();

            //Act 
            var island = islandFactory.Create();

            //Assert
            Assert.AreEqual(island.IslandBoard[8].rowNumber, 3);
            Assert.AreEqual(island.IslandBoard[8].columnNumber, 3);
        }

        [TestMethod]
        public void TileIsAtThreeFour_IsValid()
        {
            //Arrange 
            var islandFactory = new IslandFactory();

            //Act 
            var island = islandFactory.Create();

            //Assert
            Assert.AreEqual(island.IslandBoard[9].rowNumber, 3);
            Assert.AreEqual(island.IslandBoard[9].columnNumber, 4);
        }

        [TestMethod]
        public void TileIsAtThreeFive_IsValid()
        {
            //Arrange 
            var islandFactory = new IslandFactory();

            //Act 
            var island = islandFactory.Create();

            //Assert
            Assert.AreEqual(island.IslandBoard[10].rowNumber, 3);
            Assert.AreEqual(island.IslandBoard[10].columnNumber, 5);
        }

        [TestMethod]
        public void TileIsAtThreeSix_IsValid()
        {
            //Arrange 
            var islandFactory = new IslandFactory();

            //Act 
            var island = islandFactory.Create();

            //Assert
            Assert.AreEqual(island.IslandBoard[11].rowNumber, 3);
            Assert.AreEqual(island.IslandBoard[11].columnNumber, 6);
        }
        [TestMethod]
        public void TileIsAtFourOne_IsValid()
        {
            //Arrange 
            var islandFactory = new IslandFactory();

            //Act 
            var island = islandFactory.Create();

            //Assert
            Assert.AreEqual(island.IslandBoard[12].rowNumber, 4);
            Assert.AreEqual(island.IslandBoard[12].columnNumber, 1);
        }

        [TestMethod]
        public void TileIsAtFourTwo_IsValid()
        {
            //Arrange 
            var islandFactory = new IslandFactory();

            //Act 
            var island = islandFactory.Create();

            //Assert
            Assert.AreEqual(island.IslandBoard[13].rowNumber, 4);
            Assert.AreEqual(island.IslandBoard[13].columnNumber, 2);
        }

        [TestMethod]
        public void TileIsAtFourThree_IsValid()
        {
            //Arrange 
            var islandFactory = new IslandFactory();

            //Act 
            var island = islandFactory.Create();

            //Assert
            Assert.AreEqual(island.IslandBoard[14].rowNumber, 4);
            Assert.AreEqual(island.IslandBoard[14].columnNumber, 3);
        }

        [TestMethod]
        public void TileIsAtFourFour_IsValid()
        {
            //Arrange 
            var islandFactory = new IslandFactory();

            //Act 
            var island = islandFactory.Create();

            //Assert
            Assert.AreEqual(island.IslandBoard[15].rowNumber, 4);
            Assert.AreEqual(island.IslandBoard[15].columnNumber, 4);
        }

        [TestMethod]
        public void TileIsAtFourFive_IsValid()
        {
            //Arrange 
            var islandFactory = new IslandFactory();

            //Act 
            var island = islandFactory.Create();

            //Assert
            Assert.AreEqual(island.IslandBoard[16].rowNumber, 4);
            Assert.AreEqual(island.IslandBoard[16].columnNumber, 5);
        }

        [TestMethod]
        public void TileIsAtFourSix_IsValid()
        {
            //Arrange 
            var islandFactory = new IslandFactory();

            //Act 
            var island = islandFactory.Create();

            //Assert
            Assert.AreEqual(island.IslandBoard[17].rowNumber, 4);
            Assert.AreEqual(island.IslandBoard[17].columnNumber, 6);
        }

        [TestMethod]
        public void TileIsAtFiveTwo_IsValid()
        {
            //Arrange 
            var islandFactory = new IslandFactory();

            //Act 
            var island = islandFactory.Create();

            //Assert
            Assert.AreEqual(island.IslandBoard[18].rowNumber, 5);
            Assert.AreEqual(island.IslandBoard[18].columnNumber, 2);
        }

        [TestMethod]
        public void TileIsAtFiveThree_IsValid()
        {
            //Arrange 
            var islandFactory = new IslandFactory();

            //Act 
            var island = islandFactory.Create();

            //Assert
            Assert.AreEqual(island.IslandBoard[19].rowNumber, 5);
            Assert.AreEqual(island.IslandBoard[19].columnNumber, 3);
        }

        [TestMethod]
        public void TileIsAtFiveFour_IsValid()
        {
            //Arrange 
            var islandFactory = new IslandFactory();

            //Act 
            var island = islandFactory.Create();

            //Assert
            Assert.AreEqual(island.IslandBoard[20].rowNumber, 5);
            Assert.AreEqual(island.IslandBoard[20].columnNumber, 4);
        }

        [TestMethod]
        public void TileIsAtFiveFive_IsValid()
        {
            //Arrange 
            var islandFactory = new IslandFactory();

            //Act 
            var island = islandFactory.Create();

            //Assert
            Assert.AreEqual(island.IslandBoard[21].rowNumber, 5);
            Assert.AreEqual(island.IslandBoard[21].columnNumber, 5);
        }

        [TestMethod]
        public void TileIsAtSixThree_IsValid()
        {
            //Arrange 
            var islandFactory = new IslandFactory();

            //Act 
            var island = islandFactory.Create();

            //Assert
            Assert.AreEqual(island.IslandBoard[22].rowNumber, 6);
            Assert.AreEqual(island.IslandBoard[22].columnNumber, 3);
        }

        [TestMethod]
        public void TileIsAtSixFour_IsValid()
        {
            //Arrange 
            var islandFactory = new IslandFactory();

            //Act 
            var island = islandFactory.Create();

            //Assert
            Assert.AreEqual(island.IslandBoard[23].rowNumber, 6);
            Assert.AreEqual(island.IslandBoard[23].columnNumber, 4);
        }

        [TestMethod]
        public void PlayersOnTileNotNull_IsValid()
        {
            //Arrange 
            var islandFactory = new IslandFactory();

            //Act 
            var island = islandFactory.Create();

            //Assert
            foreach (var asdf in island.IslandBoard)
            {
                Assert.AreNotEqual(asdf.PlayersOnTile, null);

            }
        }



        [TestMethod]
        public void PlayerCountIsFour_IsValid()
        {
            //Arrange 
            var islandFactory = new IslandFactory();

            //Act 
            var island = islandFactory.Create();
            var playersTiles = island.IslandBoard.Where(x => x.PlayersOnTile.Count != 0).Count();

            //Assert
            Assert.AreEqual(playersTiles, 4);
        }

        [TestMethod]
        public void PlayerCountIsSix_IsValid()
        {
            //Arrange 
            var islandFactory = new IslandFactory();

            //Act 
            var island = islandFactory.Create();
            var playersTiles = island.IslandBoard.Where(x => x.PlayersOnTile.Count != 0).Count();

            //Assert
            Assert.AreNotEqual(playersTiles, 6);
        }

        [TestMethod]
        public void PlayerOnStartingTile_IsValid()
        {
            //Arrange 
            var islandFactory = new IslandFactory();

            //Act 
            var island = islandFactory.Create();
            var playersTiles = island.IslandBoard.Where(x => x.PlayersOnTile.Count != 0);

            //Assert
            foreach (var item in playersTiles)
            {
                Assert.AreEqual(item.StartingTileForPlayer, item.PlayersOnTile[0].Colour);
            }
        }

        [TestMethod]
        public void TileHasOnePlayer_IsValid()
        {
            //Arrange 
            var islandFactory = new IslandFactory();

            //Act 
            var island = islandFactory.Create();
            var playersTiles = island.IslandBoard.Where(x => x.PlayersOnTile.Count != 0);

            //Assert
            foreach (var item in playersTiles)
            {
                Assert.AreEqual(item.PlayersOnTile.Count, 1);
            }
        }

    }
}
