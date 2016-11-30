using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using fieldgame.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace fieldgame.Tests
{
    [TestClass]
    public class PlayerInventoryTests
    {
        [TestMethod]
        public void ShouldIncreaseGoldAmountWhenEarning()
        {
            var inventory = new PlayerInventory();
            inventory.EarnGold(100);
            Assert.IsTrue(inventory.Gold == 100);
        }

        [TestMethod]
        public void ShouldDecreaseGoldAmountWhenSpending()
        {
            var inventory = new PlayerInventory(startingGold: 100f);
            inventory.SpendGold(50f);
            Assert.IsTrue(inventory.Gold== 50f);
        }


        [TestMethod]
        public void ShouldNotDecreaseGoldAmountWhenAttemptingToSpendMoreMoneyThanAvailable()
        {
            var inventory = new PlayerInventory(startingGold: 100f);
            inventory.SpendGold(200f);
            Assert.IsTrue(inventory.Gold == 100f);
        }

        [TestMethod]
        public void SpendGoldShouldReturnTrueWhenGoldSpent()
        {
            var inventory = new PlayerInventory(startingGold: 100f);
            var result = inventory.SpendGold(50f);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void SpendGoldShouldReturnFalseWhenAttemptToSpendMoreGoldThanAvailable()
        {
            var inventory = new PlayerInventory(startingGold: 10f);
            var result = inventory.SpendGold(50f);
            Assert.IsFalse(result);
        }
    }
}
