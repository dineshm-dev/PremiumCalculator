using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PremiumCalcApi.Models;

namespace PremiumCalcApi.Repository
{
    public interface IUnitOfWork
    {
        public IRepository<Occupation> OccupationRepository { get; }

        public IRepository<Factor> FactorRepository { get;  }
    }
}
