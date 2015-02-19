﻿using MvcForbiddenIsland.Constants;
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
            playerList.Add(new Player() { Id = Guid.NewGuid(), Name = "Messenger", Colour = Enum.Enums.PlayerColour.Grey, Action = PlayerConstants.MESSENGER_ACTION });
            playerList.Add(new Player() { Id = Guid.NewGuid(), Name = "Explorer", Colour = Enum.Enums.PlayerColour.Green, Action = PlayerConstants.EXPLORER_ACTION });
            playerList.Add(new Player() { Id = Guid.NewGuid(), Name = "Diver", Colour = Enum.Enums.PlayerColour.Black, Action = PlayerConstants.DIVER_ACTION });
            playerList.Add(new Player() { Id = Guid.NewGuid(), Name = "Pilot", Colour = Enum.Enums.PlayerColour.Blue, Action = PlayerConstants.PILOT_ACTION });
            playerList.Add(new Player() { Id = Guid.NewGuid(), Name = "Navigator", Colour = Enum.Enums.PlayerColour.Yellow, Action = PlayerConstants.NAVIGATOR_ACTION });
            playerList.Add(new Player() { Id = Guid.NewGuid(), Name = "Engineer", Colour = Enum.Enums.PlayerColour.Red, Action = PlayerConstants.ENGINEER_ACTION });
            return playerList.OrderBy(x => Guid.NewGuid()).ToList();
        }
    }
}