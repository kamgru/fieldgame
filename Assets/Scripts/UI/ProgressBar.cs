using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using kmgr.fieldgame.Core;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace kmgr.fieldgame.UI
{
    [ExecuteInEditMode]
    public class ProgressBar : UIBehaviour
    {
        [SerializeField] float progressValue;
        [SerializeField] RectTransform fillRect;
        [SerializeField] Transform followTransform;
        [SerializeField] NotifyPropertyChangedMonoBehaviour dataContext;
        [SerializeField] string propertyName;

        public float ProgressValue
        {
            get { return progressValue; }
            set { SetProgressValue(value); }
        }

        protected override void Start()
        {
            Assert.IsNotNull(dataContext);
            dataContext.PropertyChanged += DataContextPropertyChanged;            
        }

        private void DataContextPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == propertyName)
            {
                var value = sender.GetType().GetProperty(e.PropertyName).GetValue(sender, new object[0]);

                if (value != null)
                {
                    SetProgressValue((float)value);
                }
            }
        }

        private void Update()
        {
            UpdatePosition();   
        }

        private void SetProgressValue(float progressValue)
        {
            if (progressValue > 1 || progressValue < 0)
            {
                throw new ArgumentOutOfRangeException("ProgressValue");
            }

            if (fillRect != null)
            {
                fillRect.anchorMax = new Vector2(progressValue, 1);
            }
        }

        private void UpdatePosition()
        {
            if (followTransform != null)
            {
                transform.position = RectTransformUtility.WorldToScreenPoint(Camera.main, followTransform.position);
            }
        }

#if UNITY_EDITOR
        protected override void OnValidate()
        {
            base.OnValidate();
            if (fillRect != null)
            {
                ProgressValue = progressValue;
            }
            UpdatePosition();
        }
#endif
    }
}
