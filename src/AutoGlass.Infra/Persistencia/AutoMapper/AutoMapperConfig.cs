using AutoMapper;

namespace AutoGlass.Infra.Persistencia.AutoMapper
{
    public class AutoMapperConfig
    {
        public MapperConfiguration Configure() => new MapperConfiguration(cfg => { cfg.AddProfile<Mapper>(); });
    }
}
