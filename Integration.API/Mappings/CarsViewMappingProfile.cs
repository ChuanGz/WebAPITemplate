using AutoMapper;

namespace Integration.API.Mappings
{
    public class CarsViewMappings : Profile
    {
        public CarsViewMappings()
        {
            CreateMap<BLL.Models.Agreement, Models.Agreement>()
                 .ForMember(d => d.Id, opt => opt.MapFrom(src => src.Id.ToString()))
                .ForMember(d => d.AGRNO, opt => opt.MapFrom(src => src.AGRNO))
                .ForMember(d => d.CUSTOMERCODE, opt => opt.MapFrom(src => src.CUSTOMERCODE))
                .ForMember(d => d.CUSTOMERNAME, opt => opt.MapFrom(src => src.CUSTOMERNAME))
                .ForMember(d => d.AGRCLASS, opt => opt.MapFrom(src => src.AGRCLASS))
                .ForMember(d => d.SIGNDATE, opt => opt.MapFrom(src => src.SIGNDATE))
                .ForMember(d => d.STARTDATE, opt => opt.MapFrom(src => src.STARTDATE))
                .ForMember(d => d.ENDDATE, opt => opt.MapFrom(src => src.ENDDATE));

            CreateMap<Models.Agreement, BLL.Models.Agreement>()
                 .ForMember(d => d.Id, opt => opt.MapFrom(src => src.Id.ToString()))
                .ForMember(d => d.AGRNO, opt => opt.MapFrom(src => src.AGRNO))
                .ForMember(d => d.CUSTOMERCODE, opt => opt.MapFrom(src => src.CUSTOMERCODE))
                .ForMember(d => d.CUSTOMERNAME, opt => opt.MapFrom(src => src.CUSTOMERNAME))
                .ForMember(d => d.AGRCLASS, opt => opt.MapFrom(src => src.AGRCLASS))
                .ForMember(d => d.SIGNDATE, opt => opt.MapFrom(src => src.SIGNDATE))
                .ForMember(d => d.STARTDATE, opt => opt.MapFrom(src => src.STARTDATE))
                .ForMember(d => d.ENDDATE, opt => opt.MapFrom(src => src.ENDDATE));
        }
    }
}
