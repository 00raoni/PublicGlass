using AutoGlass.Domain.Argumentos.Produto;
using AutoGlass.Domain.Interfaces.Servicos.Base;

namespace AutoGlass.Domain.Interfaces.Servicos.Produto
{
    public interface IServicoProduto : IServicoBase
    {
        ProdutoResponse Adicionar(ProdutoRequest request);
        ProdutoResponse Alterar(ProdutoRequest request);
        IEnumerable<ProdutoResponse> Listar();
        ProdutoResponse Selecionar(int id);
        IEnumerable<ProdutoResponse> ListarAtivos();
        IEnumerable<ProdutoResponse> FiltroParametro(string descricao,int page, int limit);
        ProdutoResponse Deletar(int id);
    }
}
