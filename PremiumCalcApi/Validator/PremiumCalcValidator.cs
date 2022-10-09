﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using FluentValidation;
using PremiumCalcApi.ViewModels;

namespace PremiumCalcApi.Validator
{
    public class PremiumCalcValidator : AbstractValidator<PremiumCalculator>
    {
        public PremiumCalcValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Age is required");
            RuleFor(x => x.DeathSumInsured).NotNull().WithMessage("DeathSumInsured is required");
            RuleFor(x => x.DateOfBirth).NotNull().WithMessage("DateOfBirth is required");
            RuleFor(x => x.DateOfBirth).Must(BeValidAge).WithMessage("Age must be greater than 18 years and less tha 60 years." +
                                                                     "Please enter Date Of Birth accordingly.");
            RuleFor(x => x.Age).NotNull().WithMessage("Age is required");
            RuleFor(x => x.OccupationId).NotNull().WithMessage("OccupationId is required");

        }

        protected bool BeValidAge(DateTime date)
        {
            int currentYear = DateTime.Now.Year;
            int dobYear = date.Year;

            if (dobYear < currentYear)
            {
                int age = currentYear - dobYear;

                if (age > 18 && age < 60)
                {
                    return true;
                }
            }

            return false;
        }

    }

    //public class PersonValidator : AbstractValidator<Person>
    //{
    //    public PersonValidator()
    //    {
    //        RuleFor(x => x.Id).NotNull();
    //        RuleFor(x => x.Name).Length(0, 10);
    //        RuleFor(x => x.Email).EmailAddress();
    //        RuleFor(x => x.Age).InclusiveBetween(18, 60);
    //    }
    //}

}