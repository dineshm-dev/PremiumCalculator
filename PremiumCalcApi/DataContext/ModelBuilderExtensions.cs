using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PremiumCalcApi.Models;

namespace PremiumCalcApi.DataContext
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Factor>().HasData(
                new Factor { Id = 1, Name = "Light Manual", Rating = 1.50M },
                new Factor { Id = 2, Name = "Heavy Manual", Rating = 1.75m },
                new Factor { Id = 3, Name = "White Collar", Rating = 1.25m },
                new Factor { Id = 4, Name = "Professional", Rating = 1 }
            );

            modelBuilder.Entity<Occupation>().HasData(
                new Occupation { Id = 1, Name = "Cleaner", RatingId = 1 },
                new Occupation { Id = 2, Name = "Doctor", RatingId = 4 },
                
                new Occupation { Id = 3, Name = "Author", RatingId = 3 },
                new Occupation { Id = 4, Name = "Farmer", RatingId = 2 },

                new Occupation { Id = 5, Name = "Mechanic", RatingId = 2 },
                new Occupation { Id = 6, Name = "Florist", RatingId = 1 }
                
            );
        }
    }

}
