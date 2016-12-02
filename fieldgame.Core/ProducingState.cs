using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using fieldgame.Contracts;

namespace fieldgame.Core
{
    public class ProducingState : IProducerState
    {
        private readonly IProducerStateMachine owner;
        private readonly Producer producer;

        public ProducingState(IProducerStateMachine owner, Producer producer)
        {
            this.owner = owner;
            this.producer = producer;
            this.Name = "Producing";
        }

        public string Name { get; private set; }

        public void OnMouseDown() { }

        public void OnTick()
        {
            producer.CurrentProgress += producer.TickValue;

            if (producer.CurrentProgress >= 1.0f)
            {
                producer.CurrentProgress = 1.0f;
                owner.ChangeState<WaitingForCollectionState>();
            }
        }
    }
}
