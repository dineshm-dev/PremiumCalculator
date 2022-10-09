using AutoMapper;
using PremiumCalcApi.Models;
using PremiumCalcApi.ViewModels;

namespace PremiumCalcApi.ModelMapper
{
   
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Occupation, OccupationVm>().ForMember(x => x.Id, 
                y => y.MapFrom(x => x.Id))
                .ForMember(x => x.Name,
                    y => y.MapFrom(x => x.Name));
        }
    }

}
