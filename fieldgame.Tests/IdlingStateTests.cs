using Microsoft.VisualStudio.TestTools.UnitTesting;
using fieldgame.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fieldgame.Tests
{
    [TestClass]
    public class IdlingStateTests
    {
        [TestMethod]
        public void OnMouseDownShouldChangeStateToProducingState()
        {
            var stateMachine = new ProducerStateMachine();
            var idlingState = new IdlingState(stateMachine);            
            stateMachine.Register(idlingState);
            stateMachine.Register(new ProducingState(stateMachine, null));

            idlingState.OnMouseDown();

            Assert.IsTrue(stateMachine.CurrentState is ProducingState);
        }
    }
}