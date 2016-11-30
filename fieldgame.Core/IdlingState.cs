using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using fieldgame.Contracts;

namespace fieldgame.Core
{
    public class IdlingState : IProducerState
    {
        private readonly IProducerStateMachine owner;

        public IdlingState(IProducerStateMachine owner)
        {
            this.owner = owner;
        }

        public void OnMouseDown()
        {
            owner.ChangeState<ProducingState>();
        }

        public void OnTick() { }
    }
}
