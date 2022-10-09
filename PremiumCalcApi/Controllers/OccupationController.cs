using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PremiumCalcApi.Models;
using PremiumCalcApi.Services;
using PremiumCalcApi.ViewModels;

namespace PremiumCalcApi.Controllers
{
    [Route("api/Occupation")]
    [ApiController]
    public class OccupationController : ControllerBase
    {
        private readonly IOccupationService _occupationService;
        private readonly IMapper _mapper;

        public OccupationController(IOccupationService occupationService, IMapper mapper)
        {
            _occupationService = occupationService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetOccupationDetails")]
        public IEnumerable<OccupationVm> GetOccupationDetails()
        {
            List<Occupation> lstOccupation =  this._occupationService.GetOccupationDetails().ToList();
            return _mapper.Map<List<Occupation>, List<OccupationVm>>(lstOccupation);
        }
    }
}
