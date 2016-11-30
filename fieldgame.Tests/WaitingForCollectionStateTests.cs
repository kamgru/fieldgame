using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using fieldgame.Core;
using fieldgame.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace fieldgame.Tests
{
    [TestClass]
    public class WaitingForCollectionStateTests
    {
        [TestMethod]
        public void WhenMouseDownCalledItShouldAddProductionValueToPlayerInventory()
        {
            var producer = new Producer { ProductionValue = 100f };
            var inventory = new PlayerInventory();
            var state = new WaitingForCollectionState(new ProducerStateMachineStub(), inventory, producer);

            state.OnMouseDown();

            Assert.IsTrue(inventory.Gold == 100f);
        }

        [TestMethod]
        public void ShouldChangeStateToIdlingWhenMouseDownCalled()
        {
            var fsm = new ProducerStateMachineStub();
            var inventory = new PlayerInventory();
            var state = new WaitingForCollectionState(fsm, inventory, new Producer());
            fsm.Register(new IdlingState(fsm));

            state.OnMouseDown();

            Assert.IsTrue(fsm.CurrentState is IdlingState);
        }

        [TestMethod]
        public void WhenProgressIsGreaterThanOrEqualToOneShouldSetProgressToZero()
        {
            var producer = new Producer { CurrentProgress = 1f };
            var state = new WaitingForCollectionState(new ProducerStateMachineStub(), new PlayerInventoryDummy(), producer);
            state.OnMouseDown();

            Assert.IsTrue(producer.CurrentProgress == 0.0f);
        }

    }
}
