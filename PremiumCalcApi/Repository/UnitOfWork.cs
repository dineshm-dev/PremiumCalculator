using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using PremiumCalcApi.Common;
using PremiumCalcApi.Models;

namespace PremiumCalcApi.Repository
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {

        private readonly InsurancePremiumContext context = null;

        public UnitOfWork(IOptions<AppSettings> settings)
        {
            this.context = new InsurancePremiumContext(settings);
        }
        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private bool disposed = false;

        private IRepository<Occupation> occupationRepository;
        public IRepository<Occupation> OccupationRepository
        {
            get
            {
                if (occupationRepository == null)
                {
                    occupationRepository = new OccupationRepository(this.context);
                }

                return occupationRepository;
            }
        }

        private IRepository<Factor> factorRepository;
        public IRepository<Factor> FactorRepository {
            get
            {
                if (factorRepository == null)
                {
                    this.factorRepository = new FactorRepository(this.context);
                }

                return this.factorRepository;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.context.Dispose();
                }
            }

            this.disposed = true;
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
