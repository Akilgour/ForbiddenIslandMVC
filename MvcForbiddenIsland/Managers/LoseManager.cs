using MvcForbiddenIsland.Constants;
using MvcForbiddenIsland.Models;
using MvcForbiddenIsland.Validation.CanLose.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcForbiddenIsland.Managers
{
    public class LoseManager
    {

        public List<ValidationResults> HaveTheyLost(List<IslandTile> IslandBoard, int WaterLevel, List<ICanLose> CanMoveValidation)
        {
            if (IslandBoard == null)
            {
                throw new NullReferenceException(CanLoseConstants.ISLANDBOARD_CANNONT_BE_NULL);
            }

            if (CanMoveValidation == null)
            {
                throw new NullReferenceException(CanLoseConstants.CANLOSEVALIDATION_CANNONT_BE_NULL);
            }
            List<ValidationResults> validationResultsList = new List<ValidationResults>();

            ValidationResults validationResult;
            foreach (var validation in CanMoveValidation)
            {
                validationResult = validation.IsValid(IslandBoard, WaterLevel);
                if (!validationResult.IsValid)
                {
                    validationResultsList.Add(validationResult);
                }
            }

            return validationResultsList;

        }

    }
}