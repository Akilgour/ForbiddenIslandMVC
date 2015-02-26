using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcForbiddenIsland.Models;
using MvcForbiddenIsland.Constants;
using MvcForbiddenIsland.Validation.CanMove;

namespace MvcForbiddenIsland.Tests.Validation.CanMove
{
    /// <summary>
    /// Summary description for CanMove_ColumnOneSpaceTesst
    /// </summary>
    [TestClass]
    public class CanMove_ColumnOneSpaceTesst
    {

        private IslandTile IslandTileAtRowThreeColumnOne()
        {
            return new IslandTile() { rowNumber = 3, columnNumber = 1 };
        }

        private IslandTile IslandTileAtRowThreeColumnTwo()
        {
            return new IslandTile() { rowNumber = 3, columnNumber = 2 };
        }

        private IslandTile IslandTileAtRowThreeColumnThree()
        {
            return new IslandTile() { rowNumber = 3, columnNumber = 3 };
        }

        [TestMethod]
        public void MoveOneRowColumnOneToColumnTwo_IsValid()
        {
            //Arrange 
            var canMove = new CanMove_ColumnOneSpace();
            var firstTile = IslandTileAtRowThreeColumnOne();
            var secondTile = IslandTileAtRowThreeColumnTwo();
            var currentPlayer = new Player();

            //Act 
            var validation = canMove.IsValid(firstTile, secondTile, currentPlayer);

            //Assert
            Assert.AreEqual(validation.IsValid, true);
            Assert.AreEqual(validation.ErrorMessage, null);
        }

        [TestMethod]
        public void MoveOneRowColumnTwoToColumnOne_IsValid()
        {
            //Arrange 
            var canMove = new CanMove_ColumnOneSpace();
            var firstTile = IslandTileAtRowThreeColumnTwo();
            var secondTile = IslandTileAtRowThreeColumnOne();
            var currentPlayer = new Player();

            //Act 
            var validation = canMove.IsValid(firstTile, secondTile, currentPlayer);

            //Assert
            Assert.AreEqual(validation.IsValid, true);
            Assert.AreEqual(validation.ErrorMessage, null);
        }

        [TestMethod]
        public void MoveTwoRowstColumnOneToColumnThree_NotValid()
        {
            //Arrange 
            var canMove = new CanMove_ColumnOneSpace();
            var firstTile = IslandTileAtRowThreeColumnOne();
            var secondTile = IslandTileAtRowThreeColumnThree();
            var currentPlayer = new Player();

            //Act 
            var validation = canMove.IsValid(firstTile, secondTile, currentPlayer);

            //Assert
            Assert.AreEqual(validation.IsValid, false);
            Assert.AreEqual(validation.ErrorMessage, CanMoveErrorConstants.ONLY_MOVE_ONE_COLUMN);
        }

        [TestMethod]
        public void MoveTwoRowstColumnThreeToColumnOne_NotValid()
        {
            //Arrange 
            var canMove = new CanMove_ColumnOneSpace();
            var firstTile = IslandTileAtRowThreeColumnThree();
            var secondTile = IslandTileAtRowThreeColumnOne();
            var currentPlayer = new Player();

            //Act 
            var validation = canMove.IsValid(firstTile, secondTile, currentPlayer);

            //Assert
            Assert.AreEqual(validation.IsValid, false);
            Assert.AreEqual(validation.ErrorMessage, CanMoveErrorConstants.ONLY_MOVE_ONE_COLUMN);
        }


    }
}
