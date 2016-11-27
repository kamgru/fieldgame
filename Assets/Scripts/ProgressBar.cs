using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts
{
    [ExecuteInEditMode]
    public class ProgressBar : UIBehaviour
    {
        [SerializeField] float progressValue;
        [SerializeField] RectTransform fillRect;
        [SerializeField] Transform followTransform;
        [SerializeField] MonoBehaviour dataContext;
        [SerializeField] string propertyName;

        public virtual float ProgressValue
        {
            get { return progressValue; }
            set { SetProgressValue(progressValue); }
        }

        protected override void Start()
        {
            base.Start();

            var source = dataContext as INotifyPropertyChanged;
            if (source != null)
            {
                source.PropertyChanged += dataContextPropertyChanged;
            }
        }

        private void dataContextPropertyChanged(object sender, PropertyChangedEventArgs e)
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
            progressValue = Mathf.Clamp(progressValue, 0f, 1f);
            fillRect.anchorMax = new Vector2(progressValue, 1);
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
