using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcForbiddenIsland.Factory;
using System.Collections.Generic;
using MvcForbiddenIsland.Models;
using System.Linq;
using MvcForbiddenIsland.Constants;

namespace MvcForbiddenIsland.Tests.Factory
{
    [TestClass]
    public class TreasureDeckFactoryTest
    {
        [TestMethod]
        public void CreateTreasureDeck_IsValid()
        {
            //Arrange 
            var factory = new TreasureDeckFactory();

            //Act 
            var deckList = factory.Create();

            //Assert
            Assert.IsInstanceOfType(deckList, typeof(List<TreasureCard>));
        }

        [TestMethod]
        public void HasSandbag_IsValid()
        {
            //Arrange 
            var factory = new TreasureDeckFactory();

            //Act 
            var deckList = factory.Create();
            var hasCard = deckList.Any(x => x.TreasureCardType == Enum.Enums.TreasureCardType.SandBags);

            //Assert
            Assert.IsTrue(hasCard);
        }

        [TestMethod]
        public void SandbagValues_IsValid()
        {
            //Arrange 
            var factory = new TreasureDeckFactory();

            //Act 
            var deckList = factory.Create();
            var card = deckList.FirstOrDefault(x => x.TreasureCardType == Enum.Enums.TreasureCardType.SandBags);

            //Assert
            Assert.AreNotEqual(card.Id, Guid.Empty);
            Assert.AreEqual(card.Name, CardConstants.SANDBAG_NAME);
            Assert.AreEqual(card.Description, CardConstants.SANDBAG_DESCRIPTION);
            Assert.AreEqual(card.Action, CardConstants.SANDBAG_ACTION);
            Assert.AreEqual(card.TreasureCardType, Enum.Enums.TreasureCardType.SandBags);
        }

        [TestMethod]
        public void SandbagCountIsTwo_IsValid()
        {
            //Arrange 
            var factory = new TreasureDeckFactory();

            //Act 
            var deckList = factory.Create();
            var cardCount = deckList.Count(x => x.TreasureCardType == Enum.Enums.TreasureCardType.SandBags);

            //Assert
            Assert.AreEqual(cardCount, 2);
        }

        [TestMethod]
        public void HasHelicopterList_IsValid()
        {
            //Arrange 
            var factory = new TreasureDeckFactory();

            //Act 
            var deckList = factory.Create();
            var hasCard = deckList.Any(x => x.TreasureCardType == Enum.Enums.TreasureCardType.HelicopterLift);

            //Assert
            Assert.IsTrue(hasCard);
        }

        [TestMethod]
        public void HelicopterListValues_IsValid()
        {
            //Arrange 
            var factory = new TreasureDeckFactory();

            //Act 
            var deckList = factory.Create();
            var card = deckList.FirstOrDefault(x => x.TreasureCardType == Enum.Enums.TreasureCardType.HelicopterLift);

            //Assert
            Assert.AreNotEqual(card.Id, Guid.Empty);
            Assert.AreEqual(card.Name, CardConstants.HELICOPTERLIFT_NAME);
            Assert.AreEqual(card.Description, CardConstants.HELICOPTERLIFT_DESCRIPTION);
            Assert.AreEqual(card.Action, CardConstants.HELICOPTERLIFT_ACTION);
            Assert.AreEqual(card.TreasureCardType, Enum.Enums.TreasureCardType.HelicopterLift);
        }

        [TestMethod]
        public void HelicopterListCountIsThree_IsValid()
        {
            //Arrange 
            var factory = new TreasureDeckFactory();

            //Act 
            var deckList = factory.Create();
            var cardCount = deckList.Count(x => x.TreasureCardType == Enum.Enums.TreasureCardType.HelicopterLift);

            //Assert
            Assert.AreEqual(cardCount, 3);
        }

        [TestMethod]
        public void HasWaterRises_IsValid()
        {
            //Arrange 
            var factory = new TreasureDeckFactory();

            //Act 
            var deckList = factory.Create();
            var hasCard = deckList.Any(x => x.TreasureCardType == Enum.Enums.TreasureCardType.WaterRises);

            //Assert
            Assert.IsTrue(hasCard);
        }

        [TestMethod]
        public void WaterRisesValues_IsValid()
        {
            //Arrange 
            var factory = new TreasureDeckFactory();

            //Act 
            var deckList = factory.Create();
            var card = deckList.FirstOrDefault(x => x.TreasureCardType == Enum.Enums.TreasureCardType.WaterRises);

            //Assert
            Assert.AreNotEqual(card.Id, Guid.Empty);
            Assert.AreEqual(card.Name, CardConstants.WATERRISE_NAME);
            Assert.AreEqual(card.Description, CardConstants.WATERRISE_DESCRIPTION);
            Assert.AreEqual(card.Action, CardConstants.WATERRISE_ACTION);
            Assert.AreEqual(card.TreasureCardType, Enum.Enums.TreasureCardType.WaterRises);
        }

        [TestMethod]
        public void WaterRisesCountIsThree_IsValid()
        {
            //Arrange 
            var factory = new TreasureDeckFactory();

            //Act 
            var deckList = factory.Create();
            var cardCount = deckList.Count(x => x.TreasureCardType == Enum.Enums.TreasureCardType.WaterRises);

            //Assert
            Assert.AreEqual(cardCount, 3);
        }

        [TestMethod]
        public void HasOceansChalice_IsValid()
        {
            //Arrange 
            var factory = new TreasureDeckFactory();

            //Act 
            var deckList = factory.Create();
            var hasCard = deckList.Any(x => x.TreasureCardType == Enum.Enums.TreasureCardType.OceansChalice);

            //Assert
            Assert.IsTrue(hasCard);
        }

        [TestMethod]
        public void OceansChaliceValues_IsValid()
        {
            //Arrange 
            var factory = new TreasureDeckFactory();

            //Act 
            var deckList = factory.Create();
            var card = deckList.FirstOrDefault(x => x.TreasureCardType == Enum.Enums.TreasureCardType.OceansChalice);

            //Assert
            Assert.AreNotEqual(card.Id, Guid.Empty);
            Assert.AreEqual(card.Name, CardConstants.OCEANS_CHALICE_NAME);
            Assert.AreEqual(card.Description, "");
            Assert.AreEqual(card.Action, "");
            Assert.AreEqual(card.TreasureCardType, Enum.Enums.TreasureCardType.OceansChalice);
        }

        [TestMethod]
        public void OceansChaliceCountIsFive_IsValid()
        {
            //Arrange 
            var factory = new TreasureDeckFactory();

            //Act 
            var deckList = factory.Create();
            var cardCount = deckList.Count(x => x.TreasureCardType == Enum.Enums.TreasureCardType.OceansChalice);

            //Assert
            Assert.AreEqual(cardCount, 5);
        }

        [TestMethod]
        public void HasCrystalOfFire_IsValid()
        {
            //Arrange 
            var factory = new TreasureDeckFactory();

            //Act 
            var deckList = factory.Create();
            var hasCard = deckList.Any(x => x.TreasureCardType == Enum.Enums.TreasureCardType.CrystalOfFire);

            //Assert
            Assert.IsTrue(hasCard);
        }

        [TestMethod]
        public void CrystalOfFireValues_IsValid()
        {
            //Arrange 
            var factory = new TreasureDeckFactory();

            //Act 
            var deckList = factory.Create();
            var card = deckList.FirstOrDefault(x => x.TreasureCardType == Enum.Enums.TreasureCardType.CrystalOfFire);

            //Assert
            Assert.AreNotEqual(card.Id, Guid.Empty);
            Assert.AreEqual(card.Name, CardConstants.CRYSTAL_OF_FIRE_NAME);
            Assert.AreEqual(card.Description, "");
            Assert.AreEqual(card.Action, "");
            Assert.AreEqual(card.TreasureCardType, Enum.Enums.TreasureCardType.CrystalOfFire);
        }

        [TestMethod]
        public void CrystalOfFireCountIsFive_IsValid()
        {
            //Arrange 
            var factory = new TreasureDeckFactory();

            //Act 
            var deckList = factory.Create();
            var cardCount = deckList.Count(x => x.TreasureCardType == Enum.Enums.TreasureCardType.CrystalOfFire);

            //Assert
            Assert.AreEqual(cardCount, 5);
        }

        [TestMethod]
        public void HasStatueOfTheWind_IsValid()
        {
            //Arrange 
            var factory = new TreasureDeckFactory();

            //Act 
            var deckList = factory.Create();
            var hasCard = deckList.Any(x => x.TreasureCardType == Enum.Enums.TreasureCardType.StatueOfTheWind);

            //Assert
            Assert.IsTrue(hasCard);
        }

        [TestMethod]
        public void StatueOfTheWindValues_IsValid()
        {
            //Arrange 
            var factory = new TreasureDeckFactory();

            //Act 
            var deckList = factory.Create();
            var card = deckList.FirstOrDefault(x => x.TreasureCardType == Enum.Enums.TreasureCardType.StatueOfTheWind);

            //Assert
            Assert.AreNotEqual(card.Id, Guid.Empty);
            Assert.AreEqual(card.Name, CardConstants.STATUE_OF_THE_WIND_NAME);
            Assert.AreEqual(card.Description, "");
            Assert.AreEqual(card.Action, "");
            Assert.AreEqual(card.TreasureCardType, Enum.Enums.TreasureCardType.StatueOfTheWind);
        }

        [TestMethod]
        public void StatueOfTheWindCountIsFive_IsValid()
        {
            //Arrange 
            var factory = new TreasureDeckFactory();

            //Act 
            var deckList = factory.Create();
            var cardCount = deckList.Count(x => x.TreasureCardType == Enum.Enums.TreasureCardType.StatueOfTheWind);

            //Assert
            Assert.AreEqual(cardCount, 5);
        }


        [TestMethod]
        public void HasEarthStone_IsValid()
        {
            //Arrange 
            var factory = new TreasureDeckFactory();

            //Act 
            var deckList = factory.Create();
            var hasCard = deckList.Any(x => x.TreasureCardType == Enum.Enums.TreasureCardType.EarthStone);

            //Assert
            Assert.IsTrue(hasCard);
        }

        [TestMethod]
        public void EarthStoneValues_IsValid()
        {
            //Arrange 
            var factory = new TreasureDeckFactory();

            //Act 
            var deckList = factory.Create();
            var card = deckList.FirstOrDefault(x => x.TreasureCardType == Enum.Enums.TreasureCardType.EarthStone);

            //Assert
            Assert.AreNotEqual(card.Id, Guid.Empty);
            Assert.AreEqual(card.Name, CardConstants.EARTH_STONE_NAME);
            Assert.AreEqual(card.Description, "");
            Assert.AreEqual(card.Action, "");
            Assert.AreEqual(card.TreasureCardType, Enum.Enums.TreasureCardType.EarthStone);
        }

        [TestMethod]
        public void EarthStoneCountIsFive_IsValid()
        {
            //Arrange 
            var factory = new TreasureDeckFactory();

            //Act 
            var deckList = factory.Create();
            var cardCount = deckList.Count(x => x.TreasureCardType == Enum.Enums.TreasureCardType.EarthStone);

            //Assert
            Assert.AreEqual(cardCount, 5);
        }


        [TestMethod]
        public void Are28TreasureCards_IsValid()
        {
            //Arrange 
            var factory = new TreasureDeckFactory();

            //Act 
            var deckList = factory.Create();


            //Assert
            Assert.AreEqual(28, deckList.Count);
        }

        /// <summary>
        /// Okay this test know the last 5 created are EarthStone cards, but since of the randomse they should not be
        /// </summary>
        [TestMethod]
        public void Last5NotEarthStoneTreasureCards_IsValid()
        {
            //Arrange 
            var factory = new TreasureDeckFactory();

            //Act 
            var deckList = factory.Create();


            //Assert
            var cardOne = deckList.ElementAt(27).Name ==  CardConstants.EARTH_STONE_NAME;
            var cardTwo = deckList.ElementAt(26).Name == CardConstants.EARTH_STONE_NAME;
            var cardThree = deckList.ElementAt(25).Name == CardConstants.EARTH_STONE_NAME;
            var cardFour = deckList.ElementAt(24).Name == CardConstants.EARTH_STONE_NAME;
            var cardFive = deckList.ElementAt(23).Name == CardConstants.EARTH_STONE_NAME;

            var asdf = (cardOne && cardTwo && cardThree && cardFour && cardFive);
            Assert.IsFalse(asdf);

        }
    }
}
