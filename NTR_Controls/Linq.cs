using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Reflection;

namespace NTR_Controls
{
    public static class Linq
    {
        /// <summary>
        /// Function to order ascending or descending
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="columnName"></param>
        /// <param name="IsAscending"></param>
        /// <returns></returns>
        public static IOrderedEnumerable<T> Order<T>(this IEnumerable<T> source, string columnName, bool IsAscending)
        {
            const string ASCENDING = "OrderBy";
            const string DESCENDING = "OrderByDescending";

            Type enumerable = typeof(Enumerable);
            Type me = typeof(NTR_Controls.Linq);

            //prepare to generate our generic lambda expression
            ParameterExpression list = Expression.Parameter(typeof(T), "list");
            MemberExpression property = Expression.Property(list, columnName);
            MethodInfo expressionMaker = me.GetMethod("MakeExpression", BindingFlags.Static | BindingFlags.NonPublic);
            MethodInfo expressionMethod = expressionMaker.MakeGenericMethod(typeof(T), property.Type);

            //get the generic lamdba
            var lambda = expressionMethod.Invoke(null, new object[] { property, list });

            //compile it 
            var func = (lambda as LambdaExpression).Compile();

            //get the OrderBy or OrderByDescending from Enumerable
            var sortMaker =
                    (from s in enumerable.GetMethods()
                     where
                         (s.Name == ((IsAscending) ? ASCENDING : DESCENDING))
                         && (s.GetParameters().Length == 2) //this is not particularly safe, but give me a break
                     select s).First();

            //prepare the generic sort method
            MethodInfo sorter = sortMaker.MakeGenericMethod(typeof(T), property.Type);

            //execute
            return sorter.Invoke(source, new object[] { source, func }) as IOrderedEnumerable<T>;
        }

        /// <summary>
        /// This will be used in conjuction with Reflection to create a generic expression who's types we don't
        /// know at compile time
        /// </summary>
        /// <typeparam name="P"></typeparam>
        /// <typeparam name="R"></typeparam>
        /// <param name="property"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        private static Expression<Func<P, R>> MakeExpression<P, R>(MemberExpression property, ParameterExpression list)
        {
            return Expression.Lambda<Func<P, R>>(property, new ParameterExpression[] { list });
        }
    }
}
