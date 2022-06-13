using AutoMapper;
using Manager.Domain.Entities;
using Manager.Services.DTO;

namespace Manager.Tests.Configration
{
    public static class AutoMapperConfiguration
    {
        public static IMapper GetConfiguration()
        {
            var autoMapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDTO>()
                  .ReverseMap();
            });

            return autoMapperConfiguration.CreateMapper();
        }
    }
}