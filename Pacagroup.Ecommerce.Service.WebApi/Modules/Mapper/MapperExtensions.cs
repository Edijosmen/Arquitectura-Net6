using AutoMapper;
using Pacagroup.Ecommerce.Transversal.Mapper;

namespace Pacagroup.Ecommerce.Service.WebApi.Modules.Mapper
{
    public static class MapperExtensions
    {
        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            var mappingConfing = new MapperConfiguration(mp =>
            {
                mp.AddProfile(new MappingProfile());
            });
            IMapper mapper = mappingConfing.CreateMapper();
            services.AddSingleton(mapper);
            return services;
        }
    }
}
