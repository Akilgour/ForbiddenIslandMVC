using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcForbiddenIsland.Models
{
    public class GamePlaySettings    
    {
        public Guid Id { get; set; }
        public Guid FistMovePlayerId { get; set; }
        public Guid SecondMovePlayerId { get; set; }
        public Guid ThirdMovePlayerId { get; set; }
        public Guid FourthMovePlayerId { get; set; }
        public int MoveNumber { get; set; }
        public int WaterLevelMarker { get; set; }
    }
}