using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace WebApi.Modules.Common
{
    public static class ExpressionExtensions
    {
        public static Expression<Func<T, bool>> AddCondicaoAnd<T>(this Expression<Func<T, bool>> condicaoFinal, Expression<Func<T, bool>> condicaoSequencia)
        {
            var param = Expression.Parameter(typeof(T), "x");
            var body = Expression.AndAlso(Expression.Invoke(condicaoFinal, param), Expression.Invoke(condicaoSequencia, param));
            return Expression.Lambda<Func<T, bool>>(body, param);
        }

        public static Expression<Func<T, bool>> AddCondicaoOr<T>(this Expression<Func<T, bool>> condicaoFinal, Expression<Func<T, bool>> condicaoSequencia)
        {
            var param = Expression.Parameter(typeof(T), "x");
            var body = Expression.Or(Expression.Invoke(condicaoFinal, param), Expression.Invoke(condicaoSequencia, param));
            return Expression.Lambda<Func<T, bool>>(body, param);
        }

        public static Expression<Func<T, bool>> AddCondicaoContains<T, TList>(this Expression<Func<T, bool>> condicaoFinal, Expression<Func<T, TList>> expressaoItem, List<TList> list)
        {
            Expression<Func<T, bool>> expressaoContains = ExisteItemNaLista(expressaoItem, list, 0);
            for (int i = 1; i < list.Count; i++)
            {
                expressaoContains = expressaoContains.AddCondicaoOr(ExisteItemNaLista(expressaoItem, list, i));
            }
            condicaoFinal = condicaoFinal.AddCondicaoAnd(expressaoContains);
            return condicaoFinal;
        }

        private static Expression<Func<T, bool>> ExisteItemNaLista<T, TList>(Expression<Func<T, TList>> condicaoSequencia, List<TList> list, int i)
        {
            Expression exp = Expression.Equal(condicaoSequencia.Body, Expression.Constant(list[i], typeof(TList)));

            var final = Expression.Lambda<Func<T, bool>>(exp, condicaoSequencia.Parameters[0]);
            return final;
        }
    }
}