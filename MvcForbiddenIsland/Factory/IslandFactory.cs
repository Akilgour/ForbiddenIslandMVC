using MvcForbiddenIsland.Enum;
using MvcForbiddenIsland.Models;
using MvcForbiddenIsland.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcForbiddenIsland.Factory
{
    public class IslandFactory
    {
        public Island Create()
        {
            var island = new Island();

            // island.IslandBoard = new List<IslandTile>();
            List<IslandTile> islandBoard = new List<IslandTile>();

            //AK so i know this should be passed in by a list, that is loaded from a external file, but this is first pass

            //A

            //B 2
            islandBoard.Add(CreateIslandTile("Breakers Bridge"));
            islandBoard.Add(CreateIslandTile("Bronze Gate", PlayerColour.Red));

            //C 6
            islandBoard.Add(CreateIslandTile("Cave of Embers"));
            islandBoard.Add(CreateIslandTile("Cave of Shadows"));
            islandBoard.Add(CreateIslandTile("Cliffs of Abandon"));
            islandBoard.Add(CreateIslandTile("Copper Gate", PlayerColour.Green));
            islandBoard.Add(CreateIslandTile("Coral Palace"));
            islandBoard.Add(CreateIslandTile("Crimson Forest"));
            //D 1
            islandBoard.Add(CreateIslandTile("Dunes of Deception"));
            //E

            //F 1
            islandBoard.Add(CreateIslandTile("Fools' Landing", PlayerColour.Blue, true));
            //G 1
            islandBoard.Add(CreateIslandTile("Gold Gate", PlayerColour.Yellow));

            //H 
            islandBoard.Add(CreateIslandTile("Howling Garden"));

            //I 1
            islandBoard.Add(CreateIslandTile("Iron Gate", PlayerColour.Black));

            //J

            //K

            //L 1 
            islandBoard.Add(CreateIslandTile("Lost Lagoon"));

            //M 1
            islandBoard.Add(CreateIslandTile("Misty March"));

            //N

            //O 1
            islandBoard.Add(CreateIslandTile("Observatory"));


            //P 1
            islandBoard.Add(CreateIslandTile("Phantom Rock"));

            //Q

            //R

            //S 1
            islandBoard.Add(CreateIslandTile("Silver Gate", PlayerColour.Grey));
            //T 4
            islandBoard.Add(CreateIslandTile("Temple of the Moon"));
            islandBoard.Add(CreateIslandTile("Temple of the Sun"));
            islandBoard.Add(CreateIslandTile("Tidal Palace"));
            islandBoard.Add(CreateIslandTile("Twilight Hollow"));
            //U

            //V

            //W 2
            islandBoard.Add(CreateIslandTile("Watchtower"));
            islandBoard.Add(CreateIslandTile("Whispering Garden"));
            //X

            //Y

            //Z       

            island.IslandBoard = islandBoard.OrderBy(x => Guid.NewGuid()).ToList();


            SetRowAnColumnNumber(island.IslandBoard[0], 1, 3);
            SetRowAnColumnNumber(island.IslandBoard[1], 1, 4);

            SetRowAnColumnNumber(island.IslandBoard[2], 2, 2);
            SetRowAnColumnNumber(island.IslandBoard[3], 2, 3);
            SetRowAnColumnNumber(island.IslandBoard[4], 2, 4);
            SetRowAnColumnNumber(island.IslandBoard[5], 2, 5);

            SetRowAnColumnNumber(island.IslandBoard[6], 3, 1);
            SetRowAnColumnNumber(island.IslandBoard[7], 3, 2);
            SetRowAnColumnNumber(island.IslandBoard[8], 3, 3);
            SetRowAnColumnNumber(island.IslandBoard[9], 3, 4);
            SetRowAnColumnNumber(island.IslandBoard[10], 3, 5);
            SetRowAnColumnNumber(island.IslandBoard[11], 3, 6);

            SetRowAnColumnNumber(island.IslandBoard[12], 4, 1);
            SetRowAnColumnNumber(island.IslandBoard[13], 4, 2);
            SetRowAnColumnNumber(island.IslandBoard[14], 4, 3);
            SetRowAnColumnNumber(island.IslandBoard[15], 4, 4);
            SetRowAnColumnNumber(island.IslandBoard[16], 4, 5);
            SetRowAnColumnNumber(island.IslandBoard[17], 4, 6);

            SetRowAnColumnNumber(island.IslandBoard[18], 5, 2);
            SetRowAnColumnNumber(island.IslandBoard[19], 5, 3);
            SetRowAnColumnNumber(island.IslandBoard[20], 5, 4);
            SetRowAnColumnNumber(island.IslandBoard[21], 5, 5);

            SetRowAnColumnNumber(island.IslandBoard[22], 6, 3);
            SetRowAnColumnNumber(island.IslandBoard[23], 6, 4);

            island.IslandBoard.Add(CreateSeaTile(1, 1));
            island.IslandBoard.Add(CreateSeaTile(1, 2));
            island.IslandBoard.Add(CreateSeaTile(1, 5));
            island.IslandBoard.Add(CreateSeaTile(1, 6));

            island.IslandBoard.Add(CreateSeaTile(2, 1));
            island.IslandBoard.Add(CreateSeaTile(2, 6));

            island.IslandBoard.Add(CreateSeaTile(5, 1));
            island.IslandBoard.Add(CreateSeaTile(5, 6));

            island.IslandBoard.Add(CreateSeaTile(6, 1));
            island.IslandBoard.Add(CreateSeaTile(6, 2));
            island.IslandBoard.Add(CreateSeaTile(6, 5));
            island.IslandBoard.Add(CreateSeaTile(6, 6));

            var playerListFactory = new PlayerListFactory();
            var playerList = playerListFactory.Create();
            for (int i = 0; i <= 3; i++)
            {
                island.IslandBoard.Single(x => x.StartingTileForPlayer == playerList[i].Colour).PlayersOnTile.Add(playerList[i]);
            }
            return island;
        }

        internal Island Create(List<IslandTile> islandTileList)
        {
            var island = new Island();
            island.IslandBoard = islandTileList;

 

            island.CurrentPlayerId = new Guid("427a22bd-b13e-4f8b-ae89-13c51bb67f2c");// Temp place holder will make current player always be Engingeer

            return island;
        }


        private static void SetRowAnColumnNumber(IslandTile islandTile, int rowNumber, int columnNumber)
        {
            islandTile.columnNumber = columnNumber;
            islandTile.rowNumber = rowNumber;
        }

        private IslandTile CreateIslandTile(string tileName)
        {
            return CreateIslandTile(tileName, PlayerColour.None, false);
        }

        private IslandTile CreateIslandTile(string tileName, PlayerColour startingTileForPlayer)
        {
            return CreateIslandTile(tileName, startingTileForPlayer, false);
        }

        private IslandTile CreateIslandTile(string tileName, PlayerColour startingTileForPlayer, bool helicopterSite)
        {
            var islandTile = new IslandTile();
            islandTile.Id = Guid.NewGuid();
            islandTile.Name = tileName;
            islandTile.StartingTileForPlayer = startingTileForPlayer;
            islandTile.SubmergedState = TileState.Normal;
            islandTile.HelicopterSite = helicopterSite;
            islandTile.PlayersOnTile = new List<Player>();
            return islandTile;
        }

        private IslandTile CreateSeaTile(int rowNumber, int columnNumber)
        {
            var islandTile = new IslandTile();
            islandTile.Id = Guid.NewGuid();
            islandTile.Name = "Sea";
            islandTile.StartingTileForPlayer = PlayerColour.None;
            islandTile.SubmergedState = TileState.Gone;
            islandTile.HelicopterSite = false;
            islandTile.rowNumber = rowNumber;
            islandTile.columnNumber = columnNumber;
            islandTile.PlayersOnTile = new List<Player>();
            return islandTile;
        }

      
    }




}