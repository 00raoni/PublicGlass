using AutoGlass.Domain.Argumentos.Produto;
using AutoGlass.Domain.Entidades.Produto;
using AutoMapper;

namespace AutoGlass.Infra.Persistencia.AutoMapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Produto, ProdutoResponse>();
        }
    }
}
