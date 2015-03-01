using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcForbiddenIsland.Validation.CanWin;
using MvcForbiddenIsland.Models;
using System.Collections.Generic;
using MvcForbiddenIsland.Constants;

namespace MvcForbiddenIsland.Tests.Validation.CanWin
{
    [TestClass]
    public class CanWin_AtFoolsLandingTest
    {
        [TestMethod]
        public void ReturnsValidationResults()
        {
            //Arrange 
            var canWin = new CanWin_AtFoolsLanding();
            var islandTile = new IslandTile();
  
            //Act 
            var result = canWin.CanWin(islandTile);

            //Assert
            Assert.IsInstanceOfType(result, typeof(ValidationResults));
        }

        [TestMethod]
        public void TileIsHelicopterSite()
        {
            //Arrange 
            var canWin = new CanWin_AtFoolsLanding();
            var islandTile = new IslandTile();
            islandTile.HelicopterSite = true;

            //Act 
            var result = canWin.CanWin(islandTile);

            //Assert
            Assert.AreEqual(result.IsValid, true);
        }

        [TestMethod]
        public void TileIsNotHelicopterSite()
        {
            //Arrange 
            var canWin = new CanWin_AtFoolsLanding();
            var islandTile = new IslandTile();
            islandTile.HelicopterSite = false;

            //Act 
            var result = canWin.CanWin(islandTile);

            //Assert
            Assert.AreEqual(result.IsValid, false);
            Assert.AreEqual(result.ErrorMessage, CanWinConstants.NOT_FOOLS_LANDING);
        }
    }
}
