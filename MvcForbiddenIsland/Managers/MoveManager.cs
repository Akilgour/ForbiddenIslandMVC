using MvcForbiddenIsland.Constants;
using MvcForbiddenIsland.Enum;
using MvcForbiddenIsland.Models;
using MvcForbiddenIsland.Validation.CanMove;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcForbiddenIsland.Managers
{
    public class MoveManager
    {
        private List<ValidationResults> ValidationResultsList;

        public List<ValidationResults> AreMovesValid(Dictionary<MoveType, IslandTile> PlayerMoves, List<ICanMoveValidation> CanMoveValidation, Player Player)
        {
            AreMovesValid_GettingValidData(PlayerMoves, CanMoveValidation);
            var moveTileOne = PlayerMoves.Single(x => x.Key == MoveType.FirstMyPawnMoveTile).Value;
            var moveTileTwo = PlayerMoves.Single(x => x.Key == MoveType.SecondMyPawnMoveTile).Value;
            var moveTileThree = PlayerMoves.Single(x => x.Key == MoveType.ThirdMyPawnMoveTile).Value;
            var moeTileFour = PlayerMoves.Single(x => x.Key == MoveType.FourthMyPawnMoveTile).Value;
            ValidationResultsList = new List<ValidationResults>();
            IsMoveValid(CanMoveValidation, Player, moveTileOne, moveTileTwo);
            IsMoveValid(CanMoveValidation, Player, moveTileTwo, moveTileThree);
            IsMoveValid(CanMoveValidation, Player, moveTileThree, moeTileFour);
            return ValidationResultsList;
        }

        private static void AreMovesValid_GettingValidData(Dictionary<MoveType, IslandTile> PlayerMoves, List<ICanMoveValidation> CanMoveValidation)
        {
            if (PlayerMoves == null)
            {
                throw new NullReferenceException(CanMoveErrorConstants.PLAYERMOVES_CANNOT_BE_NULL);
            }

            if (!PlayerMoves.Any(x => x.Key == MoveType.FirstMyPawnMoveTile))
            {
                throw new NullReferenceException(CanMoveErrorConstants.NEED_FOUR_MOVE_TILES);
            }

            if (!PlayerMoves.Any(x => x.Key == MoveType.SecondMyPawnMoveTile))
            {
                throw new NullReferenceException(CanMoveErrorConstants.NEED_FOUR_MOVE_TILES);
            }

            if (!PlayerMoves.Any(x => x.Key == MoveType.ThirdMyPawnMoveTile))
            {
                throw new NullReferenceException(CanMoveErrorConstants.NEED_FOUR_MOVE_TILES);
            }

            if (!PlayerMoves.Any(x => x.Key == MoveType.FourthMyPawnMoveTile))
            {
                throw new NullReferenceException(CanMoveErrorConstants.NEED_FOUR_MOVE_TILES);
            }

            if (CanMoveValidation == null)
            {
                throw new NullReferenceException(CanMoveErrorConstants.CANMOVEVALIDATION_CANNOT_BE_NULL);
            }
        }

        private void IsMoveValid(List<ICanMoveValidation> CanMoveValidation, Player Player, IslandTile FromMovetile, IslandTile ToMoveTile)
        {
            ValidationResults validationResult;
            foreach (var validation in CanMoveValidation)
            {
                validationResult = validation.IsValid(FromMovetile, ToMoveTile, Player);
                if (!validationResult.IsValid)
                {
                    ValidationResultsList.Add(validationResult);
                }
            }
        }

        public void Save()
        {
            //TODOD
        }
    }
}