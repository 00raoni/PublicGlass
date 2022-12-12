using AutoGlass.Domain.Produtos;
using System;

namespace AutoGlass.Application
{
    public class ProdutoDto
    {
        public string DescricaoProduto { get; set; }
        public EnumSituacaoProduto SituacaoProduto { get; set; }
        public DateTime? DataFabricacao { get; set; }
        public DateTime? DataValidade { get; set; }
        public int? CodigoFornecedor { get; set; }
        public string? NomeFornecedor { get; set; }
        public string? CNPJFornecedor { get; set; }
    }
}