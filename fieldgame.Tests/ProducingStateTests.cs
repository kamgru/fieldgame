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
    public class ProducingStateTests
    {
        [TestMethod]
        public void OnTickShouldIncrementProducerProgressByTickValue()
        {
            var producer = new Producer { TickValue = 0.5f, CurrentProgress = 0.0f };
            var state = new ProducingState(new ProducerStateMachineStub(), producer);

            state.OnTick();

            Assert.IsTrue(producer.CurrentProgress == 0.5f);
        }

        [TestMethod]
        public void WhenProgressIsGreaterThanOrEqualToOneShouldChangeStateToWaitingForCollection()
        {
            var producer = new Producer { CurrentProgress = 1f };
            var fsm = new ProducerStateMachineStub();
            var producingState = new ProducingState(fsm, producer);
            var waitingState = new WaitingForCollectionState(fsm, new PlayerInventoryDummy(), producer);
            fsm.Register(waitingState);

            producingState.OnTick();

            Assert.IsTrue(fsm.CurrentState is WaitingForCollectionState);
        }

        [TestMethod]
        public void ShouldClampProgressValue()
        {
            var producer = new Producer { CurrentProgress = 1f, TickValue = 0.2f };
            var fsm = new ProducerStateMachineStub();
            var producingState = new ProducingState(fsm, producer);
            var waitingState = new WaitingForCollectionState(fsm, new PlayerInventoryDummy(), producer);
            fsm.Register(waitingState);

            producingState.OnTick();

            Assert.IsTrue(producer.CurrentProgress == 1f);
        }

    }
}
