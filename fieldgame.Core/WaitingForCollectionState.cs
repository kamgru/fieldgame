using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using fieldgame.Contracts;

namespace fieldgame.Core
{
    public class WaitingForCollectionState : IProducerState
    {
        private readonly IProducerStateMachine owner;
        private readonly IPlayerInventory playerInventory;
        private readonly Producer producer;

        public WaitingForCollectionState(IProducerStateMachine owner, IPlayerInventory playerInventory, Producer producer)
        {
            this.owner = owner;
            this.playerInventory = playerInventory;
            this.producer = producer;
        }

        public void OnMouseDown()
        {
            playerInventory.EarnGold(producer.ProductionValue);
            producer.CurrentProgress = 0;
            owner.ChangeState<IdlingState>();
        }

        public void OnTick() { }
    }
}
