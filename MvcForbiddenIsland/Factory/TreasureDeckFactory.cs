using MvcForbiddenIsland.Constants;
using MvcForbiddenIsland.Enum;
using MvcForbiddenIsland.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcForbiddenIsland.Factory
{
    public class TreasureDeckFactory
    {
        public List<TreasureCard> Create()
        {
            List<TreasureCard> treasureCardList = new List<TreasureCard>();

            treasureCardList.Add(CreateSandBagCard());
            treasureCardList.Add(CreateSandBagCard());

            treasureCardList.Add(CreateHelicopterLiftCard());
            treasureCardList.Add(CreateHelicopterLiftCard());
            treasureCardList.Add(CreateHelicopterLiftCard());

            treasureCardList.Add(CreateWaterRiseCard());
            treasureCardList.Add(CreateWaterRiseCard());
            treasureCardList.Add(CreateWaterRiseCard());

            treasureCardList.Add(CreateOceansChaliceCard());
            treasureCardList.Add(CreateOceansChaliceCard());
            treasureCardList.Add(CreateOceansChaliceCard());
            treasureCardList.Add(CreateOceansChaliceCard());
            treasureCardList.Add(CreateOceansChaliceCard());

            treasureCardList.Add(CreateCrystalOfFireCard());
            treasureCardList.Add(CreateCrystalOfFireCard());
            treasureCardList.Add(CreateCrystalOfFireCard());
            treasureCardList.Add(CreateCrystalOfFireCard());
            treasureCardList.Add(CreateCrystalOfFireCard());

            treasureCardList.Add(CreateStatueOfTheWindCard());
            treasureCardList.Add(CreateStatueOfTheWindCard());
            treasureCardList.Add(CreateStatueOfTheWindCard());
            treasureCardList.Add(CreateStatueOfTheWindCard());
            treasureCardList.Add(CreateStatueOfTheWindCard());

            treasureCardList.Add(CreateEarthStoneCard());
            treasureCardList.Add(CreateEarthStoneCard());
            treasureCardList.Add(CreateEarthStoneCard());
            treasureCardList.Add(CreateEarthStoneCard());
            treasureCardList.Add(CreateEarthStoneCard());

            return treasureCardList.OrderBy(x => Guid.NewGuid()).ToList();

        }

        private TreasureCard CreateSandBagCard()
        {
            return new TreasureCard() { Id = Guid.NewGuid(), Name = CardConstants.SANDBAG_NAME, Description = CardConstants.SANDBAG_DESCRIPTION, Action = CardConstants.SANDBAG_ACTION, TreasureCardType = TreasureCardType.SandBags };
        }

        private TreasureCard CreateHelicopterLiftCard()
        {
            return new TreasureCard() { Id = Guid.NewGuid(), Name = CardConstants.HELICOPTERLIFT_NAME, Description = CardConstants.HELICOPTERLIFT_DESCRIPTION, Action = CardConstants.HELICOPTERLIFT_ACTION, TreasureCardType = TreasureCardType.HelicopterLift };
        }

        private TreasureCard CreateWaterRiseCard()
        {
            return new TreasureCard() { Id = Guid.NewGuid(), Name = CardConstants.WATERRISE_NAME, Description = CardConstants.WATERRISE_DESCRIPTION, Action = CardConstants.WATERRISE_ACTION, TreasureCardType = TreasureCardType.WaterRises };
        }

        private TreasureCard CreateOceansChaliceCard()
        {
            return new TreasureCard() { Id = Guid.NewGuid(), Name = CardConstants.OCEANS_CHALICE_NAME, Description = "", Action = "", TreasureCardType = TreasureCardType.OceansChalice };
        }

        private TreasureCard CreateCrystalOfFireCard()
        {
            return new TreasureCard() { Id = Guid.NewGuid(), Name = CardConstants.CRYSTAL_OF_FIRE_NAME, Description = "", Action = "", TreasureCardType = TreasureCardType.CrystalOfFire };
        }

        private TreasureCard CreateStatueOfTheWindCard()
        {
            return new TreasureCard() { Id = Guid.NewGuid(), Name = CardConstants.STATUE_OF_THE_WIND_NAME, Description = "", Action = "", TreasureCardType = TreasureCardType.StatueOfTheWind };
        }

        private TreasureCard CreateEarthStoneCard()
        {
            return new TreasureCard() { Id = Guid.NewGuid(), Name = CardConstants.EARTH_STONE_NAME, Description = "", Action = "", TreasureCardType = TreasureCardType.EarthStone };
        }
    }
}