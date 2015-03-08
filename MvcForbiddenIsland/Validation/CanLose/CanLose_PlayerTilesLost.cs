using MvcForbiddenIsland.Constants;
using MvcForbiddenIsland.Models;
using MvcForbiddenIsland.Validation.CanLose.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcForbiddenIsland.Validation.CanLose
{
    public class CanLose_PlayerTilesLost : CanLoseBase,  ICanLose
    {
        private List<string> DrownedPlayerNames = new List<string>();
        private bool ThisTilelIsValid = false;

        /// <summary>
        /// If the tile a player is one is gone, they have to swim to the nearest tile
        /// If there is no nearby tile, that isnt normal or flooded, they lose
        /// </summary>
        /// <param name="IslandBoard"> The island board</param>
        /// <param name="WaterLevel">Dont care in this canLose</param>
        /// <returns></returns>
        public ValidationResults IsValid(List<IslandTile> IslandBoard, int WaterLevel)
        {
            var tileThatHavePlayers = IslandBoard.Where(x => x.PlayersOnTile.Any());

            int playerTileRowNumber;
            int playerTileColumnNumber;
           

            foreach (var tilePlayerIsOn in tileThatHavePlayers)
            {
                if (TileGone(tilePlayerIsOn))
                {
                    ThisTilelIsValid = false;

                    playerTileRowNumber = tilePlayerIsOn.rowNumber;
                    playerTileColumnNumber = tilePlayerIsOn.columnNumber;

                    WorkOutIfThereIsAnEscape(IslandBoard, (playerTileRowNumber - 1), (playerTileColumnNumber - 1));
                    WorkOutIfThereIsAnEscape(IslandBoard, (playerTileRowNumber - 1), playerTileColumnNumber);
                    WorkOutIfThereIsAnEscape(IslandBoard, (playerTileRowNumber - 1), (playerTileColumnNumber + 1));

                    WorkOutIfThereIsAnEscape(IslandBoard, playerTileRowNumber, (playerTileColumnNumber - 1));
                    WorkOutIfThereIsAnEscape(IslandBoard, playerTileRowNumber, (playerTileColumnNumber + 1));

                    WorkOutIfThereIsAnEscape(IslandBoard, (playerTileRowNumber + 1), (playerTileColumnNumber - 1));
                    WorkOutIfThereIsAnEscape(IslandBoard, (playerTileRowNumber + 1), playerTileColumnNumber);
                    WorkOutIfThereIsAnEscape(IslandBoard, (playerTileRowNumber + 1), (playerTileColumnNumber + 1));

                    if (!ThisTilelIsValid)
                    {
                        foreach (var player in tilePlayerIsOn.PlayersOnTile)
                        {
                            DrownedPlayerNames.Add(player.Name);
                        }
                    }

                }
            }

            if (DrownedPlayerNames.Any())
            {
                string playerOnTile = string.Join(", ", DrownedPlayerNames);
                var commaIndex = playerOnTile.LastIndexOf(",");

                if (commaIndex != -1)
                {
                    playerOnTile = playerOnTile.Remove(commaIndex, 1);
                    playerOnTile = playerOnTile.Insert(commaIndex, " and");
                }


                return new ValidationResults() { IsValid = false, ErrorMessage = String.Format(CanLoseConstants.PLAYER_HAS_GONE, playerOnTile) };

            }

            return new ValidationResults() { IsValid = true };
        }

        private void WorkOutIfThereIsAnEscape(List<IslandTile> IslandBoard, int playerTileRowNumber, int playerTileColumnNumber)
        {
            if (playerTileRowNumber != 0)
            {
                if (playerTileColumnNumber != 0)
                {
                    if (playerTileRowNumber != 7)
                    {
                        if (playerTileColumnNumber != 7)
                        {
                            if (!TileGone(IslandBoard.Single(x => x.rowNumber == playerTileRowNumber && x.columnNumber == playerTileColumnNumber)))
                            {
                                ThisTilelIsValid = true;
                            }
                        }
                    }
                }
            }
        }



    }
}