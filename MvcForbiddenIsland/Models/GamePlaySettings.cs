using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcForbiddenIsland.Models
{
    public class GamePlaySettings    
    {
        public Guid Id { get; set; }
        public Guid fistMovePlayerId { get; set; }
        public Guid secondMovePlayerId { get; set; }
        public Guid thirdMovePlayerId { get; set; }
        public Guid fourthMovePlayerId { get; set; }
        public int moveNumber { get; set; }
    }
}