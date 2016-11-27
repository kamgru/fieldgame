using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class NotifyPropertyChangedMonoBehaviour : MonoBehaviour, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void Notify<TProperty>(Expression<Func<TProperty>> property)
        {
            var propertyName = (property.Body as MemberExpression).Member.Name;

            var temp = PropertyChanged;
            if (temp != null)
            {
                temp(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
