using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public interface IProducer : INotifyPropertyChanged
    {
        float Progress { get; set; }
        ProducerState ProducerState { get; set; }
    }

    public enum ProducerState { Idling, Producing, WaitingForCollection }

    public class GoldMine : NotifyPropertyChangedMonoBehaviour, IProducer
    {
        public float Progress
        {
            get { return progress; }
            set
            {
                if (value != progress)
                {
                    progress = value;
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

        private float progress;
        [SerializeField]
        private ProducerState producerState;
        private float lastUpdate;

        private void Update()
        {         
            if (ProducerState == ProducerState.Producing)
            {
                if (lastUpdate + Constants.STEP_INTERVAL <= Time.time)
                {
                    lastUpdate = Time.time;
                    Progress += 0.02f;
                    if (Progress >= 1)
                    {
                        ProducerState = ProducerState.WaitingForCollection;
                    }
                }
            }
        }
    }
}
