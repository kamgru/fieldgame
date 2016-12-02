using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using fieldgame.Contracts;

namespace fieldgame.Tests.Mocks
{
    public class ProducerStateMachineStub : IProducerStateMachine
    {
        private List<IProducerState> states = new List<IProducerState>();

        public IProducerState CurrentState { get; private set; }

        public event EventHandler<ProducerStateEventArgs> StateChanged;

        public void ChangeState<TProducerState>() where TProducerState : IProducerState
        {
            CurrentState = states.FirstOrDefault(state => state.GetType() == typeof(TProducerState));
        }

        public IEnumerable<IProducerState> GetStates()
        {
            throw new NotImplementedException();
        }

        public void Register<TProducerState>(TProducerState state) where TProducerState : IProducerState
        {
            states.Add(state);
        }
    }
}
