using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PremiumCalcApi.Models;
using PremiumCalcApi.ViewModels;

namespace PremiumCalcApi.Services
{
    public interface IOccupationService
    {
         IEnumerable<Occupation> GetOccupationDetails();

    }
}
