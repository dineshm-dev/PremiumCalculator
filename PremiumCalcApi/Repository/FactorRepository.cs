using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PremiumCalcApi.Models;

namespace PremiumCalcApi.Repository
{
    public class FactorRepository : IRepository<Factor>
    {
        private readonly InsurancePremiumContext context = null;

        public FactorRepository(InsurancePremiumContext context)
        {
            this.context = context;
        }

        public Factor Get(Func<Factor, bool> predicate)
        {
            var data = this.context.Factors;

            return data.FirstOrDefault(predicate);
        }

        public IEnumerable<Factor> GetAll(Func<Factor, bool> predicate = null)
        {
            var data = this.context.Factors;

            if (predicate != null)
            {
                return data.Where(predicate);
            }

            return data;
        }

        public bool GetCount(int id)
        {
            return this.context.Factors.Where(s => s.Id == id).Count() > 0;
        }

        public IQueryable<Factor> GetQueryableResult(params Expression<Func<Factor, object>>[] includes)
        {
            var query = this.context.Factors.AsQueryable();
            return query;
        }

        public IQueryable<Factor> GetQueryableResultWithTracking(params Expression<Func<Factor, object>>[] includes)
        {
            var query = this.context.Factors.AsQueryable();
            return query;
        }
    }
}
