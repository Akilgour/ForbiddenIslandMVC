using MvcForbiddenIsland.Models;
using MvcForbiddenIsland.Validation.CanLose.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcForbiddenIsland.Tests.Managers.Lose.Mocks
{
   public class CanLose_NotValid : ICanLose
    {
       /// <summary>
       /// This will always return a not valid
       /// </summary>
       /// <param name="IslandBoard"></param>
       /// <param name="WaterLevel"></param>
       /// <returns></returns>
        public Models.ValidationResults IsValid(List<IslandTile> IslandBoard, int WaterLevel)
        {
            return new ValidationResults() { IsValid = false, ErrorMessage = LoseManagerTestConstants.CAN_LOSE_ERROR };
        }
    }
}
