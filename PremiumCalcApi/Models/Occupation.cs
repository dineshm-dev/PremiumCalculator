using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace PremiumCalcApi.Models
{
    
    public partial class Occupation
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public int RatingId { get; set; }

        [ForeignKey("RatingId")]
        public virtual Factor Rating { get; set; }

    }
}
