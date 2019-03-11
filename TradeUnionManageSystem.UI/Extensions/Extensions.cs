using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using TradeUnionManageSystem.UI.Extensions.DataProvider;

namespace TradeUnionManageSystem.UI.Extensions
{
    public static class Extensions
    {
        /// <summary>
        /// 分页扩展方法
        /// </summary>
        /// <param name="list">数据源</param>
        /// <param name="order">排序表达式</param>
        /// <param name="page">第几页</param>
        /// <param name="size">每页记录数</param>
        /// <param name="count">记录总数</param>
        /// <returns></returns>
        public static IQueryable<T> Pagination<T, TKey>(this IQueryable<T> list, Expression<Func<T, TKey>> order, int page, int size, out int count)
        {
            count = list.Count();
            return list.Distinct().OrderBy(order).Skip((page - 1) * size).Take(size);
        }
    }
}