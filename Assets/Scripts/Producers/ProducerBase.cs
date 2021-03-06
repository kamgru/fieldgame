﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public string CurrentStateName
        {
            get
            {
                return currentStateName;
            }
        }

        [SerializeField] private float progress;
        [SerializeField] private float productionSpeed = 0.01f;
        [SerializeField] private float productionValue = 100f;

        private float lastProductionTick;
        private Producer producer;
        private IProducerStateMachine stateMachine;
        private string currentStateName;

        protected void Start()
        {
            producer = new Producer
            {
                CurrentProgress = 0f,
                ProductionValue = productionValue,
                TickValue = productionSpeed
            };

            stateMachine = new ProducerStateMachine();

            stateMachine.Register(new IdlingState(stateMachine));
            stateMachine.Register(new ProducingState(stateMachine, producer));
            stateMachine.Register(new WaitingForCollectionState(stateMachine, FindObjectOfType<PlayerWallet>(), producer));
            stateMachine.StateChanged += OnStateChanged;
            stateMachine.ChangeState<IdlingState>();
        }

        private void OnStateChanged(object sender, ProducerStateEventArgs e)
        {
            currentStateName = stateMachine.CurrentState.Name;
            Notify(() => CurrentStateName);
        }

        protected virtual void OnProductionTick()
        {
            stateMachine.CurrentState.OnTick();
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
            stateMachine.CurrentState.OnMouseDown();
        }
    }
}
