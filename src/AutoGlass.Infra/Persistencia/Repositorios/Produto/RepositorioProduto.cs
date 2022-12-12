
using AutoGlass.Domain.Argumentos.Produto;
using AutoGlass.Domain.Repositorio.Produto;
using AutoGlass.Infra.Persistencia.Repositorios.Base;
using AutoMapper;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;

namespace AutoGlass.Infra.Persistencia.Repositorios.Produto
{
    public class RepositorioProduto : RepositorioBase<AutoGlass.Domain.Entidades.Produto.Produto, int>, IRepositorioProduto
    {
        protected readonly Contexto _context;
        private readonly IMapper _mapper;
        public RepositorioProduto(Contexto context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<ProdutoResponse> FiltroParametro(string descricao, int page, int limit)
        {
            if (page == 0)
                page = 1;

            if (limit == 0)
                limit = int.MaxValue;
            
            var skip = (page - 1) * limit;

            var list = _context.Produtos.Where(x => x.DescricaoProduto.Contains(descricao)).ToList();
            var list2 = list.Skip(skip).Take(limit).ToList();

            return _mapper.Map<IEnumerable<ProdutoResponse>>(list2);
        }

        /*public DbSqlQuery<AutoGlass.Domain.Entidades.Produto.Produto> Exemplo(AutoGlass.Domain.Entidades.Produto.Produto request) =>
            _context.Set<AutoGlass.Domain.Entidades.Produto.Produto>().SqlQuery("Select * from Produto where ProdutoId = @id", new SqlParameter("@id", 1));

        public DbSqlQuery<AutoGlass.Domain.Entidades.Produto.Produto> Exemplo2(AutoGlass.Domain.Entidades.Produto.Produto request)
        {
            return _context.Set<AutoGlass.Domain.Entidades.Produto.Produto>().SqlQuery("Select * from Produto where nome = teste");
        }*/
    }
}
