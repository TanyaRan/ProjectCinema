using AutoMapper;

namespace TRan.CinemaUniverse.Web.Infrastructure
{
    public interface IHaveCustomMappings
    {
        void CreateMappings(IMapperConfigurationExpression configuration);
    }
}