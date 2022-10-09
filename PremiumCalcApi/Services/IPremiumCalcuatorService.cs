using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PremiumCalcApi.ViewModels;

namespace PremiumCalcApi.Services
{
    public interface IPremiumCalcuatorService
    {
        decimal CalcualtePremium(PremiumCalculator objPremiumCalculator);
    }
}
