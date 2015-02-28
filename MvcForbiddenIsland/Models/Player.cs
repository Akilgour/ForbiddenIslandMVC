﻿using MvcForbiddenIsland.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcForbiddenIsland.Models
{
    public class Player : IPlayer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Action { get; set; }
        public Enum.Enums.PlayerColour Colour { get; set; }
        public Enum.Enums.TeasureCardDeckId PlayerHandId { get; set; }
    }
}