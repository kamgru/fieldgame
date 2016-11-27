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

        public ProducerStateEnum ProducerState
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

        public float ProductionValue
        {
            get { return productionValue; }
            set
            {
                if (value != productionValue)
                {
                    productionValue = value;
                    Notify(() => ProductionValue);
                }
            }
        }

        [SerializeField] private float progress;
        [SerializeField] private ProducerStateEnum producerState;
        [SerializeField] private float productionSpeed = 0.2f;
        [SerializeField] private float productionValue = 100f;

        private float lastProductionTick;

        protected virtual void OnProductionTick()
        {
            Progress += ProductionSpeed;

            if (Progress >= 1)
            {
                ProducerState = ProducerStateEnum.WaitingForCollection;
            }
        }

        protected virtual void Update()
        {
            if (ProducerState == ProducerStateEnum.Producing)
            {
                if (lastProductionTick + Constants.STEP_INTERVAL <= Time.time)
                {
                    lastProductionTick = Time.time;
                    OnProductionTick();
                }
            }            
        }

        private void OnMouseDown()
        {
            if (ProducerState == ProducerStateEnum.WaitingForCollection)
            {

            }
        }
    }
}
