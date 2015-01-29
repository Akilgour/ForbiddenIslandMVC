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
            islandBoard.Add(CreateIslandTile("Bronze Gate",Enum.Enums.PlayerColour.Red));

            //C 6
           islandBoard.Add(CreateIslandTile("Cave of Embers"));
            islandBoard.Add(CreateIslandTile("Cave of Shadows"));
           islandBoard.Add(CreateIslandTile("Cliffs of Abandon"));
            islandBoard.Add(CreateIslandTile("Copper Gate",Enum.Enums.PlayerColour.Green));
           islandBoard.Add(CreateIslandTile("Coral Palace"));
            islandBoard.Add(CreateIslandTile("Crimson Forest"));
            //D 1
            islandBoard.Add(CreateIslandTile("Dunes of Deception"));
            //E

            //F 1
            islandBoard.Add(CreateIslandTile("Fools' Landing", Enum.Enums.PlayerColour.Blue,true));
            //G 1
             islandBoard.Add(CreateIslandTile("Gold Gate", Enum.Enums.PlayerColour.Yellow));

            //H 
             islandBoard.Add(CreateIslandTile("Howling Garden"));

            //I 1
             islandBoard.Add(CreateIslandTile("Iron Gate",Enum.Enums.PlayerColour.Black));

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
            islandBoard.Add(CreateIslandTile("Silver Gate", Enum.Enums.PlayerColour.Grey));
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
            islandTile.Id = Guid.NewGuid();
            islandTile.Name = tileName;
            islandTile.StartingTileForPlayer = startingTileForPlayer;
            islandTile.SubmergedState = Enum.Enums.TileState.Normal;
            islandTile.HelicopterSite = helicopterSite;
            return islandTile;
        }


    }




}