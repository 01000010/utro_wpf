using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace utro_wpf
{
    /// <summary>
    /// A helper for expressions
    /// </summary>
    public static class ExpressionsHelpers
    {
        /// <summary>
        /// Compiles the expression and gets the function return value
        /// </summary>
        /// <typeparam name="T">The type of return value</typeparam>
        /// <param name="lambda">The expression to be compiled</param>
        /// <returns></returns>
        public static T GetPropertyValue<T>(this Expression<Func<T>> lambda)
        {
            return lambda.Compile().Invoke();
        }

        /// <summary>
        /// Sets the property to the given value
        /// </summary>
        /// <typeparam name="T">The type of value to set</typeparam>
        /// <param name="lambda">The expression</param>
        /// <param name="value">The value to set the property to</param>
        public static void SetPropertyValue<T>(this Expression<Func<T>> lambda, T value)
        {
            // Converts a lambda () => some.Property as some.Property
            MemberExpression expression = (lambda as LambdaExpression).Body as MemberExpression;
            // Get the property info
            PropertyInfo propertyInfo = (PropertyInfo)expression.Member;
            object target = Expression.Lambda(expression.Expression).Compile().DynamicInvoke();
            propertyInfo.SetValue(target, value);
        }
    }
}
