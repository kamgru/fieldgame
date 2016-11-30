using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fieldgame.Contracts
{
    public interface IProducerStateMachine
    {
        IProducerState CurrentState { get; }
        void ChangeState<TProducerState>() where TProducerState : IProducerState;
        void Register<TProducerState>(TProducerState state) where TProducerState : IProducerState;
        IEnumerable<IProducerState> GetStates();
    }
}
