using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace PremiumCalcApi.Models
{
    public partial class Factor
    {
        public Factor()
        {
            
        }

        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        
        public decimal Rating { get; set; }

        
    }
}
