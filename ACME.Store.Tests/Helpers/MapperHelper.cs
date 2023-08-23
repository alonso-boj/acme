using AutoMapper;

namespace ACME.Store.Tests.Helpers;

public static class MapperHelper
{
    public static IMapper ConfigureAutoMapper(params Profile[] profile)
    {
        var mapperConfig = new MapperConfiguration(cfg =>
        {
            for (int i = 0; i < profile.Length; i++)
            {
                cfg.AddProfile(profile[i]);
            }
        });

        mapperConfig.AssertConfigurationIsValid();

        IMapper mapper = mapperConfig.CreateMapper();

        return mapper;
    }
}