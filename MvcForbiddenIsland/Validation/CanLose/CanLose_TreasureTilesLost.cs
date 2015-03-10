using MvcForbiddenIsland.Constants;
using MvcForbiddenIsland.Enum;
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

        /// <summary>
        /// There is two treasure tile for each treasure
        /// If both are gone the game is over.
        /// </summary>
        /// <param name="IslandBoard">All the tiles in te board</param>
        /// <param name="WaterLevel"></param>
        /// <returns></returns>
        public ValidationResults IsValid(List<IslandTile> IslandBoard, int WaterLevel)
        {
            AreBothTreasuresGone(IslandBoard, CardConstants.OCEANS_CHALICE_NAME, TreasureStatue.OceansChalice);
            AreBothTreasuresGone(IslandBoard, CardConstants.CRYSTAL_OF_FIRE_NAME, TreasureStatue.CrystalOfFire);
            AreBothTreasuresGone(IslandBoard, CardConstants.STATUE_OF_THE_WIND_NAME, TreasureStatue.StatueOfTheWind);
            AreBothTreasuresGone(IslandBoard, CardConstants.EARTH_STONE_NAME, TreasureStatue.EarthStone);

            if (goneTileNames.Any())
            {
                return new ValidationResults() { IsValid = false, ErrorMessage = String.Format(CanLoseConstants.TREASURE_GONE, ListStringToCSVString.ListToString(goneTileNames)) };
            }

            return new ValidationResults() { IsValid = true };
        }

        private void AreBothTreasuresGone(List<IslandTile> IslandBoard, string TreasureName, TreasureStatue TreasureStatue)
        {
            var tileThatHaveTheStatues = IslandBoard.Where(x => x.CanHaveStatue == TreasureStatue).ToList();
            if (TileGone(tileThatHaveTheStatues.First()) && TileGone(tileThatHaveTheStatues.Last()))
            {
                goneTileNames.Add(TreasureName);
            }
        }

    }
}