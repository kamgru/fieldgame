using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using fieldgame.Contracts;

namespace fieldgame.Core
{
    public class ProducerStateMachine : IProducerStateMachine
    {
        private Dictionary<Type, IProducerState> states;

        public ProducerStateMachine()
        {
            states = new Dictionary<Type, IProducerState>();
        }

        public IProducerState CurrentState { get; private set; }

        public event EventHandler<ProducerStateEventArgs> StateChanged;

        public void ChangeState<TProducerState>() where TProducerState : IProducerState
        {
            if (!states.ContainsKey(typeof(TProducerState)))
            {
                throw new ArgumentOutOfRangeException("No such state");
            }

            CurrentState = states[typeof(TProducerState)];
            RaiseStateChanged();
        }

        public IEnumerable<IProducerState> GetStates()
        {
            return states.Values;
        }

        public void Register<TProducerState>(TProducerState state) where TProducerState : IProducerState
        {
            if (state == null)
            {
                throw new ArgumentNullException("State");
            }
            states.Add(typeof(TProducerState), state);
        }

        private void RaiseStateChanged()
        {
            var temp = StateChanged;
            if (temp != null)
            {
                temp(this, new ProducerStateEventArgs(CurrentState.Name));
            }
        }
    }
}
