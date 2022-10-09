using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PremiumCalcApi.Models;

namespace PremiumCalcApi.Repository
{
    public class OccupationRepository : IRepository<Occupation>
    {
        private readonly InsurancePremiumContext context = null;

        public OccupationRepository(InsurancePremiumContext context)
        {
            this.context = context;
        }

        public Occupation Get(Func<Occupation, bool> predicate)
        {
            var data = this.context.Occupations;

            return data.FirstOrDefault(predicate);
        }

        public IEnumerable<Occupation> GetAll(Func<Occupation, bool> predicate = null)
        {
            var data = this.context.Occupations;

            if (predicate != null)
            {
                return data.Where(predicate);
            }

            return data;
        }

        public bool GetCount(int id)
        {
            return this.context.Occupations.Where(s => s.Id == id).Count() > 0;
        }

        public IQueryable<Occupation> GetQueryableResult(params Expression<Func<Occupation, object>>[] includes)
        {
            var query = this.context.Occupations.AsNoTracking().AsQueryable();
            if (includes.Count() != 0)
            {
                return includes.Aggregate(
                    query,
                    (current, include) => current.Include(include)
                );
            }
            return query;
        }

        public IQueryable<Occupation> GetQueryableResultWithTracking(params Expression<Func<Occupation, object>>[] includes)
        {
            var query = this.context.Occupations.AsQueryable();
            if (includes.Count() != 0)
            {
                return includes.Aggregate(
                    query,
                    (current, include) => current.Include(include)
                );
            }

            return query;
        }
    }
}
