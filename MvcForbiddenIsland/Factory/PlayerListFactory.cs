using MvcForbiddenIsland.Constants;
using MvcForbiddenIsland.Enum;
using MvcForbiddenIsland.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcForbiddenIsland.Factory
{
    public class PlayerListFactory
    {
        public List<Player> Create()
        {
            List<Player> playerList = new List<Player>();
            playerList.Add(new Player() { Id = Guid.NewGuid(), Name = PlayerConstants.MESSENGER_NAME, Colour = PlayerColour.Grey, Action = PlayerConstants.MESSENGER_ACTION });
            playerList.Add(new Player() { Id = Guid.NewGuid(), Name = PlayerConstants.EXPLORER_NAME, Colour = PlayerColour.Green, Action = PlayerConstants.EXPLORER_ACTION });
            playerList.Add(new Player() { Id = Guid.NewGuid(), Name = PlayerConstants.DIVER_NAME, Colour = PlayerColour.Black, Action = PlayerConstants.DIVER_ACTION });
            playerList.Add(new Player() { Id = Guid.NewGuid(), Name = PlayerConstants.PILOT_NAME, Colour = PlayerColour.Blue, Action = PlayerConstants.PILOT_ACTION });
            playerList.Add(new Player() { Id = Guid.NewGuid(), Name = PlayerConstants.NAVIGATOR_NAME, Colour = PlayerColour.Yellow, Action = PlayerConstants.NAVIGATOR_ACTION });
            playerList.Add(new Player() { Id = Guid.NewGuid(), Name = PlayerConstants.ENGINEER_NAME, Colour = PlayerColour.Red, Action = PlayerConstants.ENGINEER_ACTION });
            return playerList.OrderBy(x => Guid.NewGuid()).ToList();
        }
    }
}