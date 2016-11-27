using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using kmgr.fieldgame.Core;
using UnityEngine;

namespace kmgr.fieldgame.Producers
{
    public class ProducerBase : NotifyPropertyChangedMonoBehaviour, IProducer
    {
        public float Progress
        {
            get { return progress; }
            set
            {
                if (value != progress)
                {
                    progress = Mathf.Clamp(value, 0f, 1f);
                    Notify(() => Progress);
                }
            }
        }

        public ProducerState ProducerState
        {
            get { return producerState; }
            set
            {
                if (value != producerState)
                {
                    producerState = value;
                    Notify(() => ProducerState);
                }
            }
        }

        public float ProductionSpeed
        {
            get { return productionSpeed; }
            set
            {
                if (value != productionSpeed)
                {
                    productionSpeed = value;
                    Notify(() => ProductionSpeed);
                }
            }
        }

        [SerializeField] private float progress;
        [SerializeField] private ProducerState producerState;
        [SerializeField] private float productionSpeed = 0.2f;

        private float lastProductionTick;

        protected virtual void OnProductionTick()
        {
            Progress += ProductionSpeed;

            if (Progress >= 1)
            {
                ProducerState = ProducerState.WaitingForCollection;
            }
        }

        protected virtual void Update()
        {
            if (ProducerState == ProducerState.Producing)
            {
                if (lastProductionTick + Constants.STEP_INTERVAL <= Time.time)
                {
                    lastProductionTick = Time.time;
                    OnProductionTick();
                }
            }
        }
    }
}
