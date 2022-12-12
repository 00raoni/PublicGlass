using AutoGlass.Domain.Argumentos.Produto;
using AutoGlass.Domain.Interfaces.Repositorio.Base;
using System.Data.Entity.Infrastructure;

namespace AutoGlass.Domain.Repositorio.Produto
{
    public interface IRepositorioProduto : IRepositorioBase<AutoGlass.Domain.Entidades.Produto.Produto, int>
    {
        public IEnumerable<ProdutoResponse> FiltroParametro(string descricao, int page, int limit);
        
        //DbSqlQuery<AutoGlass.Domain.Entidades.Produto.Produto> Exemplo(AutoGlass.Domain.Entidades.Produto.Produto request);
        //DbSqlQuery<AutoGlass.Domain.Entidades.Produto.Produto> Exemplo2(AutoGlass.Domain.Entidades.Produto.Produto request);
    }
}
