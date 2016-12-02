using System;
using System.Linq;
using fieldgame.Contracts;
using fieldgame.Core;
using fieldgame.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace fieldgame.Tests
{
    [TestClass]
    public class ProducerStateMachineTests
    {
        [TestMethod]
        public void RegisteredStateShouldBeAvailableToGet()
        {
            var state = new StateDummy();
            var fsm = new ProducerStateMachine();
            fsm.Register(state);

            Assert.IsTrue(fsm.GetStates().Contains(state));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShouldThrowExceptionWhenAttemptingToRegisterNullState()
        {
            var fsm = new ProducerStateMachine();
            fsm.Register<StateDummy>(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ShouldThrowExceptionWhenAttemptingToChangeToNonRegisteredState()
        {
            var fsm = new ProducerStateMachine();
            fsm.ChangeState<StateDummy>();
        }

        [TestMethod]
        public void ShouldChangeCurrentStateWhenChangeStateCalled()
        {
            var state = new StateDummy();
            var fsm = new ProducerStateMachine();
            fsm.Register(state);

            fsm.ChangeState<StateDummy>();
            Assert.IsTrue(fsm.CurrentState == state);
        }

        [TestMethod]
        public void ShouldRaiseStateChangedEvent()
        {
            var state = new StateDummy();
            var fsm = new ProducerStateMachine();
            bool wasRaised = false;
            fsm.StateChanged += (sender, args) => { wasRaised = true; };
            fsm.Register(state);

            fsm.ChangeState<StateDummy>();

            Assert.IsTrue(wasRaised);
        }

        [TestMethod]
        public void EventArgsShouldHoldNewStateName()
        {
            var state = new StateDummy();
            var fsm = new ProducerStateMachine();
            string stateName = string.Empty;

            fsm.Register(state);
            fsm.StateChanged += (sender, args) => { stateName = args.CurrentStateName; };
            fsm.ChangeState<StateDummy>();

            Assert.IsTrue(stateName == state.Name);
        }
    }
}
