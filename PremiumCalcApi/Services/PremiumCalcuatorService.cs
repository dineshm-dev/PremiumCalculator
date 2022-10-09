using PremiumCalcApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using PremiumCalcApi.Models;
using PremiumCalcApi.Repository;

namespace PremiumCalcApi.Services
{
    public class PremiumCalcuatorService : IPremiumCalcuatorService
    {
        private readonly IUnitOfWork _uow;
        private readonly ILogger<PremiumCalcuatorService> _logger;

        public PremiumCalcuatorService(IUnitOfWork _uow, ILogger<PremiumCalcuatorService> logger)
        {
            this._uow = _uow;
            _logger = logger;
        }

        public decimal CalcualtePremium(PremiumCalculator objPremiumCalculator)
        {
            decimal premiumAmount = 0;
            try
            {
                Occupation objOccupation = this._uow.OccupationRepository.GetQueryableResult(f => f.Rating)
                    .Where(f => f.Id == objPremiumCalculator.OccupationId).FirstOrDefault();

                if (objOccupation != null)
                {
                    decimal rating = objOccupation.Rating.Rating;
                    decimal amountInsure = Convert.ToDecimal(objPremiumCalculator.DeathSumInsured);

                    // Death Premium = (Death Cover amount *Occupation Rating Factor *Age) / 1000 * 12
                    premiumAmount = Math.Round((amountInsure * rating * objPremiumCalculator.Age) / 1000 * 12, 2,
                        MidpointRounding.AwayFromZero);
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message);
                throw;
            }

            return premiumAmount;
        }
    }
}
