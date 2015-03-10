using MvcForbiddenIsland.Constants;
using MvcForbiddenIsland.Helpers;
using MvcForbiddenIsland.Models;
using MvcForbiddenIsland.Validation.CanLose.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcForbiddenIsland.Validation.CanLose
{
    public class CanLose_TreasureTilesLost  : CanLoseBase,  ICanLose
    {

        private List<string> goneTileNames = new List<string>();


        public ValidationResults IsValid(List<IslandTile> IslandBoard, int WaterLevel)
        {
            var oceansChaliceTiles = IslandBoard.Where(x => x.CanHaveStatue == Enum.TreasureStatue.OceansChalice).ToList();
            var crystalOfFireTiles = IslandBoard.Where(x => x.CanHaveStatue == Enum.TreasureStatue.CrystalOfFire).ToList();
            var statueOfTheWindTiles = IslandBoard.Where(x => x.CanHaveStatue == Enum.TreasureStatue.StatueOfTheWind).ToList();
            var earthStoneTiles = IslandBoard.Where(x => x.CanHaveStatue == Enum.TreasureStatue.EarthStone).ToList();

            AreTreasuresGone(oceansChaliceTiles, CardConstants.OCEANS_CHALICE_NAME);
            AreTreasuresGone(crystalOfFireTiles, CardConstants.CRYSTAL_OF_FIRE_NAME);
            AreTreasuresGone(statueOfTheWindTiles, CardConstants.STATUE_OF_THE_WIND_NAME);
            AreTreasuresGone(earthStoneTiles, CardConstants.EARTH_STONE_NAME);


            if (goneTileNames.Any())
            {
                return new ValidationResults() { IsValid = false, ErrorMessage = String.Format(CanLoseConstants.TREASURE_GONE, ListStringToCSVString.ListToString(goneTileNames)) };
            }

            return new ValidationResults() { IsValid = true };
        }

        private void AreTreasuresGone(List<IslandTile> oceansChaliceTiles, string TreasureName)
        {
            if (TileGone(oceansChaliceTiles.First()) && TileGone(oceansChaliceTiles.Last()))
            {
                goneTileNames.Add(TreasureName);

            }
        }



    }
}