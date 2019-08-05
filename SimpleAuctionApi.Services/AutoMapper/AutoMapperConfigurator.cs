using AutoMapper;

namespace SimpleAuctionApi.Services.AutoMapper
{
    public class AutoMapperConfigurator
    {
        public static IMapper Configure()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile(new MappingProfile());
            });

            return config.CreateMapper();
        }
    }
}
