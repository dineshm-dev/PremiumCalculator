using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using PremiumCalcApi.Models;
using PremiumCalcApi.Repository;

namespace PremiumCalcApi.Services
{
    public class OccupationService : IOccupationService
    {
        private readonly IUnitOfWork _uow;
        private readonly ILogger<OccupationService> _logger;

        public OccupationService(IUnitOfWork uow, ILogger<OccupationService> logger)
        {
            _uow = uow;
            _logger = logger;
        }

        public IEnumerable<Occupation> GetOccupationDetails()
        {
            List<Occupation> lstOccupation = new List<Occupation>();
            try
            {
                lstOccupation = this._uow.OccupationRepository.GetQueryableResult().ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return lstOccupation;
        }
    }
}
