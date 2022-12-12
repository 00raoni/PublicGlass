using AutoGlass.Domain.Argumentos.Base;

namespace AutoGlass.Domain.Argumentos.Produto
{
    public class ProdutoResponse : ArgumentoBase
    {
        public String? DescricaoProduto { get; set; }
        public int? SituacaoProduto { get; set; }
        public DateTime? DataFabricacao { get; set; }
        public DateTime? DataValidade { get; set; }
        public int? CodigoFornecedor { get; set; }
        public String? NomeFornecedor { get; set; }
        public String? CNPJFornecedor { get; set; }

        public static explicit operator ProdutoResponse(AutoGlass.Domain.Entidades.Produto.Produto entidade)
        {
            return new ProdutoResponse()
            {
                DescricaoProduto = entidade.DescricaoProduto,
                SituacaoProduto = (int?)entidade.SituacaoProduto,
                DataFabricacao = entidade.DataFabricacao,
                DataValidade = entidade.DataValidade,
                CodigoFornecedor = entidade.CodigoFornecedor,
                NomeFornecedor = entidade.NomeFornecedor,
                CNPJFornecedor = entidade.CNPJFornecedor,
            };
        }
    }
}

