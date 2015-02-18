using MvcForbiddenIsland.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcForbiddenIsland.Models
{
    public class Island : IIsland
    {
        public List<IslandTile> IslandBoard{get; set;}

        public Guid MoveOne { get; set; }
        public Guid MoveTwo { get; set; }
        public Guid MoveThree { get; set; }

    }
}