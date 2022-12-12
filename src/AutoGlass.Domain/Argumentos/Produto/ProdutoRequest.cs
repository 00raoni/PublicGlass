using AutoGlass.Domain.Argumentos.Base;

namespace AutoGlass.Domain.Argumentos.Produto
{
    public class ProdutoRequest : ArgumentoBase
    {        
        public String? DescricaoProduto { get; set; }
        public int? SituacaoProduto { get; set; }
        public DateTime? DataFabricacao { get; set; }
        public DateTime? DataValidade { get; set; }
        public int? CodigoFornecedor { get; set; }
        public String? NomeFornecedor { get; set; }
        public String? CNPJFornecedor { get; set; }

    }
}

