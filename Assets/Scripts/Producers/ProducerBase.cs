using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts;
using fieldgame.Contracts;
using fieldgame.Core;
using kmgr.fieldgame.Core;
using UnityEngine;

namespace kmgr.fieldgame.Producers
{
    public class ProducerBase : NotifyPropertyChangedMonoBehaviour
    {
        public float Progress
        {
            get { return producer.CurrentProgress; }
            set
            {
                if (value != progress)
                {
                    progress = Mathf.Clamp(value, 0f, 1f);
                    Notify(() => Progress);
                }
            }
        }

        [SerializeField] private float progress;
        [SerializeField] private float productionSpeed = 0.01f;
        [SerializeField] private float productionValue = 100f;

        private float lastProductionTick;
        private Producer producer;
        private IProducerStateMachine fsm;

        protected void Start()
        {
            producer = new Producer
            {
                CurrentProgress = 0f,
                ProductionValue = productionValue,
                TickValue = productionSpeed
            };

            fsm = new ProducerStateMachine();

            fsm.Register(new IdlingState(fsm));
            fsm.Register(new ProducingState(fsm, producer));
            fsm.Register(new WaitingForCollectionState(fsm, FindObjectOfType<PlayerWallet>(), producer));

            fsm.ChangeState<IdlingState>();
        }
        protected virtual void OnProductionTick()
        {
            fsm.CurrentState.OnTick();
        }

        protected virtual void Update()
        {            
            if (lastProductionTick + Constants.STEP_INTERVAL <= Time.time)
            {
                lastProductionTick = Time.time;
                OnProductionTick();
                Progress = producer.CurrentProgress;
            }            
        }

        private void OnMouseDown()
        {
            fsm.CurrentState.OnMouseDown();
        }
    }
}
