using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using fieldgame.Core;
using kmgr.fieldgame.Producers;
using kmgr.fieldgame.UI;
using UnityEngine;

namespace kmgr.fieldgame
{
    public class ProducerGuiView : MonoBehaviour
    {
        [SerializeField] ProgressBar progressBar;
        [SerializeField] ProducerBase producerBase;

        private string statePropertyName;

        private void Start()
        {
            producerBase.PropertyChanged += ProducerBase_PropertyChanged;
            statePropertyName = ReflectionHelper.GetPropertyName((ProducerBase x) => x.CurrentStateName);
        }

        private void ProducerBase_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == statePropertyName)
            {
                progressBar.gameObject.SetActive(producerBase.CurrentStateName == "Producing");
            }
        }
    }
}
