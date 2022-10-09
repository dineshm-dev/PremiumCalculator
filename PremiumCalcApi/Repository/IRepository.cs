using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PremiumCalcApi.Repository
{
    public interface IRepository<T>
        where T : class
    {
        IEnumerable<T> GetAll(Func<T, bool> predicate = null);
        IQueryable<T> GetQueryableResult(params Expression<Func<T, object>>[] includes);
        T Get(Func<T, bool> predicate);
        IQueryable<T> GetQueryableResultWithTracking(params Expression<Func<T, object>>[] includes);
    }
}
