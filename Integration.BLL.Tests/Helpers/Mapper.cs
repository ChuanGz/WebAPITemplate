using AutoMapper;
using Integration.BLL.Mappings;

namespace Integration.BLL.Tests.Helpers
{
    public static class Mapper
    {
        public static IMapper GetAutoMapper()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AgreementsMapping());

            });
            var mapper = mockMapper.CreateMapper();
            return mapper;
        }
    }
}
