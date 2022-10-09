using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PremiumCalcApi.ViewModels
{
    public class PremiumCalculator
    {
        public string Name { get; set; }

        public int OccupationId { get; set; }

        public int Age { get; set; }

        public DateTime DateOfBirth { get; set; }

        public decimal DeathSumInsured { get; set; }
    }
}
