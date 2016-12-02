using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace fieldgame.Core
{
    public class ReflectionHelper
    {
        public static string GetPropertyName<T, TProperty>(Expression<Func<T, TProperty>> propertyExpression)
        {
            var property = (propertyExpression.Body as MemberExpression);
            return property.Member.Name;
        }
    }
}
