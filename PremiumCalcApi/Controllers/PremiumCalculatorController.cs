using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using Newtonsoft.Json;
using PremiumCalcApi.Services;
using PremiumCalcApi.ViewModels;

namespace PremiumCalcApi.Controllers
{
    [Route("api/premiumCalc")]
    [ApiController]
    public class PremiumCalculatorController : ControllerBase
    {
        private readonly IValidator<PremiumCalculator> _validator;
        private readonly IPremiumCalcuatorService _premiumCalcuatorService;

        public PremiumCalculatorController(IValidator<PremiumCalculator> validator, IPremiumCalcuatorService premiumCalcuatorService)
        {
            _validator = validator;
            _premiumCalcuatorService = premiumCalcuatorService;
        }

        [HttpPost]
        [Route("CalculatePremium")]
        public async Task<ActionResult> CalculatePremium(PremiumCalculator objPremiumCalculator)
        {
            try
            {
                ValidationResult result = await _validator.ValidateAsync(objPremiumCalculator);
                if (!result.IsValid)
                {
                    return Problem(JsonConvert.SerializeObject(result.Errors.Select(f => f.ErrorMessage)));
                }


                return Ok(_premiumCalcuatorService.CalcualtePremium(objPremiumCalculator));
            }
            catch
            {
                return  Problem("Exception occurred calculating premium");
            }
        }
    }
}
