using AutoMapper;
using Integration.BLL.Models;
using Integration.DAL.Models;
using System;

namespace Integration.BLL.Mappings
{
    public class AgreementsMapping : Profile
    {
        public AgreementsMapping()
        {
            CreateMap<Agreement, AgreementEntity>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.Id.ToString()))
                .ForMember(d => d.AGRNO, opt => opt.MapFrom(src => src.AGRNO))
                .ForMember(d => d.CUSTOMERCODE, opt => opt.MapFrom(src => src.CUSTOMERCODE))
                .ForMember(d => d.CUSTOMERNAME, opt => opt.MapFrom(src => src.CUSTOMERNAME))
                .ForMember(d => d.AGRCLASS, opt => opt.MapFrom(src => src.AGRCLASS))
                .ForMember(d => d.SIGNDATE, opt => opt.MapFrom(src => src.SIGNDATE))
                .ForMember(d => d.STARTDATE, opt => opt.MapFrom(src => src.STARTDATE))
                .ForMember(d => d.ENDDATE, opt => opt.MapFrom(src => src.ENDDATE));

            CreateMap<AgreementEntity, Agreement>()
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
