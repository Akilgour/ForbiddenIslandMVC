using Model;
using MvcForbiddenIsland.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcForbiddenIsland.Validation.CanLose.Interface
{
    public interface ICanLose
    {
        ValidationResults IsValid( List<IslandTile> IslandBoard, int WaterLevel );
     

    }
}
