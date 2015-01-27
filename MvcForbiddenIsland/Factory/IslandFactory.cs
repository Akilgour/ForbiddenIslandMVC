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

            island.IslandBoard = new List<IslandTile>();

            //AK so i know this should be passed in by a list, that is loaded from a external file, but this is first pass

            //A

            //B 2
            island.IslandBoard.Add(CreateIslandTile("Breakers Bridge"));
            island.IslandBoard.Add(CreateIslandTile("Bronze Gate",Enum.Enums.PlayerColour.Red));

            //C 6
            island.IslandBoard.Add(CreateIslandTile("Cave of Embers"));
            island.IslandBoard.Add(CreateIslandTile("Cave of Shadows"));
            island.IslandBoard.Add(CreateIslandTile("Cliffs of Abandon"));
            island.IslandBoard.Add(CreateIslandTile("Copper Gate",Enum.Enums.PlayerColour.Green));
            island.IslandBoard.Add(CreateIslandTile("Coral Palace"));
            island.IslandBoard.Add(CreateIslandTile("Crimson Forest"));
            //D 1
            island.IslandBoard.Add(CreateIslandTile("Dunes of Deception"));
            //E

            //F 1
            island.IslandBoard.Add(CreateIslandTile("Fools' Landing", Enum.Enums.PlayerColour.Blue,true));
            //G 1
             island.IslandBoard.Add(CreateIslandTile("Gold Gate", Enum.Enums.PlayerColour.Yellow));

            //H 
             island.IslandBoard.Add(CreateIslandTile("Howling Garden"));

            //I 1
             island.IslandBoard.Add(CreateIslandTile("Iron Gate",Enum.Enums.PlayerColour.Black));

            //J

            //K

            //L 1 
             island.IslandBoard.Add(CreateIslandTile("Lost Lagoon"));

            //M 1
             island.IslandBoard.Add(CreateIslandTile("Misty March"));

            //N

            //O 1
            island.IslandBoard.Add(CreateIslandTile("Observatory"));
             

            //P 1
             island.IslandBoard.Add(CreateIslandTile("Phantom Rock"));

            //Q

            //R

            //S 1
            island.IslandBoard.Add(CreateIslandTile("Silver Gate", Enum.Enums.PlayerColour.Grey));
            //T 4
            island.IslandBoard.Add(CreateIslandTile("Temple of the Moon"));
            island.IslandBoard.Add(CreateIslandTile("Temple of the Sun"));
            island.IslandBoard.Add(CreateIslandTile("Tidal Palace"));
            island.IslandBoard.Add(CreateIslandTile("Twilight Hollow"));
            //U

            //V

            //W 2
            island.IslandBoard.Add(CreateIslandTile("Watchtower"));
            island.IslandBoard.Add(CreateIslandTile("Whispering Garden"));
            //X

            //Y

            //Z       

            return island;
        }

        private IslandTile CreateIslandTile(string tileName)
        {
            return CreateIslandTile(tileName, Enum.Enums.PlayerColour.None, false);
        }

        private IslandTile CreateIslandTile(string tileName, Enum.Enums.PlayerColour startingTileForPlayer)
        {
            return CreateIslandTile(tileName, startingTileForPlayer, false);
        }

        private IslandTile CreateIslandTile(string tileName, Enum.Enums.PlayerColour startingTileForPlayer, bool helicopterSite)
        {
            var islandTile = new IslandTile();
            islandTile.Id = new Guid();
            islandTile.Name = tileName;
            islandTile.StartingTileForPlayer = startingTileForPlayer;
            islandTile.SubmergedState = Enum.Enums.TileState.Normal;
            islandTile.HelicopterSite = helicopterSite;
            return islandTile;
        }


    }




}