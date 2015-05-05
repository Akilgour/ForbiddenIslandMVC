//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class GamePlaySetting
    {
        public System.Guid Id { get; set; }
        public Nullable<System.Guid> FirstMovePlayerId { get; set; }
        public Nullable<System.Guid> SecondMovePlayerId { get; set; }
        public Nullable<System.Guid> ThirdMovePlayerId { get; set; }
        public Nullable<System.Guid> FourthMovePlayerId { get; set; }
        public Nullable<int> MoveNumber { get; set; }
        public Nullable<int> WaterLevelMarker { get; set; }
        public Nullable<System.Guid> DrawDeckId { get; set; }
        public Nullable<System.Guid> DiscardDeckId { get; set; }
    
        public virtual Player Player { get; set; }
        public virtual Player Player1 { get; set; }
        public virtual Player Player2 { get; set; }
        public virtual Player Player3 { get; set; }
    }
}
