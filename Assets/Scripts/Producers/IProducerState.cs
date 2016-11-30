//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using fieldgame.Contracts;

//namespace kmgr.fieldgame.Producers
//{
//    public interface IProducerState
//    {
//        void OnTick();
//        void OnMouseDown();
//    }

//    public interface IProducerStateMachine : IProducer
//    {
//        void ChangeState<T>() where T : IProducerState;
//    }

//    public class IdlingState : IProducerState
//    {
//        private readonly IProducerStateMachine owner;

//        public IdlingState(IProducerStateMachine owner)
//        {
//            this.owner = owner;
//        }

//        public void OnMouseDown()
//        {
//            owner.ChangeState<ProducingState>();
//        }

//        public void OnTick()
//        {
            
//        }
//    }

//    public class WaitingForCollectionState : IProducerState
//    {
//        private readonly IProducerStateMachine owner;
//        private readonly PlayerWallet wallet;

//        public WaitingForCollectionState(IProducerStateMachine owner, PlayerWallet wallet)
//        {
//            this.owner = owner;
//            this.wallet = wallet;
//        }

//        public void OnMouseDown()
//        {
//            wallet.AddGold((int)owner.ProductionValue);
//            owner.Progress = 0;
//            owner.ChangeState<IdlingState>();
//        }

//        public void OnTick()
//        {
            
//        }
//    }

//    public class ProducingState : IProducerState
//    {
//        private readonly IProducerStateMachine owner;

//        public ProducingState(IProducerStateMachine owner)
//        {
//            this.owner = owner;
//        }

//        public void OnMouseDown()
//        {
            
//        }

//        public void OnTick()
//        {
//            owner.Progress += owner.ProductionSpeed;
//            if (owner.Progress >= 1)
//            {
//                owner.ChangeState<WaitingForCollectionState>();
//            }
//        }
//    }
//}
