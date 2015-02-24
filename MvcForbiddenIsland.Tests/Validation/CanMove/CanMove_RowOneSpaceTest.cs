using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcForbiddenIsland.Validation.CanMove;
using MvcForbiddenIsland.Models;
using MvcForbiddenIsland.Constants;

namespace MvcForbiddenIsland.Tests.Validation.CanMove
{
    /// <summary>
    /// Summary description for CanMove_RowOneSpaceTest
    /// </summary>
    [TestClass]
    public class CanMove_RowOneSpaceTest
    {
        private IslandTile IslandTileAtRowOneColumnThree()
        {
            return new IslandTile() { rowNumber = 1, columnNumber = 3 };
        }

        private IslandTile IslandTileAtRowTwoColumnThree()
        {
            return new IslandTile() { rowNumber = 2, columnNumber = 3 };
        }

        private IslandTile IslandTileAtRowThreeColumnThree()
        {
            return new IslandTile() { rowNumber = 3, columnNumber = 3 };
        }

        [TestMethod]
        public void MoveOneRowRowOneToRowTwo_IsValid()
        {
            //Arrange 
            var canMove = new CanMove_RowOneSpace();
            var firstTile = IslandTileAtRowOneColumnThree();
            var secondTile = IslandTileAtRowTwoColumnThree();
            var currentPlayer = new Player();

            //Act 
            var validation = canMove.IsValid(firstTile, secondTile, currentPlayer);

            //Assert
            Assert.AreEqual(validation.IsValid, true);
            Assert.AreEqual(validation.ErrorMessage, null);
        }

        [TestMethod]
        public void MoveOneRowRowTwoToRowOne_IsValid()
        {
            //Arrange 
            var canMove = new CanMove_RowOneSpace();
            var firstTile = IslandTileAtRowTwoColumnThree();
            var secondTile = IslandTileAtRowOneColumnThree(); 
            var currentPlayer = new Player();

            //Act 
            var validation = canMove.IsValid(firstTile, secondTile, currentPlayer);

            //Assert
            Assert.AreEqual(validation.IsValid, true);
            Assert.AreEqual(validation.ErrorMessage, null);
        }

        [TestMethod]
        public void MoveTwoRowstRowOneToRowThree_NotValid()
        {
            //Arrange 
            var canMove = new CanMove_RowOneSpace();
            var firstTile = IslandTileAtRowOneColumnThree();
            var secondTile = IslandTileAtRowThreeColumnThree();
            var currentPlayer = new Player();

            //Act 
            var validation = canMove.IsValid(firstTile, secondTile, currentPlayer);

            //Assert
            Assert.AreEqual(validation.IsValid, false);
            Assert.AreEqual(validation.ErrorMessage, CanMoveErrorConstants.ONLY_MOVE_ONE_ROW);
        }

        [TestMethod]
        public void MoveTwoRowstRowThreeToRowOne_NotValid()
        {
            //Arrange 
            var canMove = new CanMove_RowOneSpace();
            var firstTile = IslandTileAtRowThreeColumnThree();
            var secondTile = IslandTileAtRowOneColumnThree(); 
            var currentPlayer = new Player();

            //Act 
            var validation = canMove.IsValid(firstTile, secondTile, currentPlayer);

            //Assert
            Assert.AreEqual(validation.IsValid, false);
            Assert.AreEqual(validation.ErrorMessage, CanMoveErrorConstants.ONLY_MOVE_ONE_ROW);
        }
    }
}
