using AutoGlass.Domain.Argumentos.Produto;
using AutoGlass.Domain.Entidades.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGlass.Domain.Entidades.Produto
{
    public class Produto:EntidadeBase
    {
        public String DescricaoProduto { get; private set; }
        public EnumSituacaoProduto SituacaoProduto { get; private set; }
        public DateTime? DataFabricacao { get; private set; }
        public DateTime? DataValidade { get; private set; }
        public int? CodigoFornecedor { get; private set; }
        public String? NomeFornecedor { get; private set; }
        public String? CNPJFornecedor { get; private set; }

        public Produto(ProdutoRequest request)
        {
            DescricaoProduto = request.DescricaoProduto;
            SituacaoProduto = (EnumSituacaoProduto)request.SituacaoProduto;
            DataFabricacao = request.DataFabricacao;
            DataValidade = request.DataValidade;
            CodigoFornecedor = request.CodigoFornecedor;
            NomeFornecedor = request.NomeFornecedor;
            CNPJFornecedor = request.CNPJFornecedor;
            
            DomainException.LaunchWhen(string.IsNullOrEmpty(request.DescricaoProduto), "Descrição do Produto é de preenchimento obrigatório.");
            DomainException.LaunchWhen(DataFabricacao >= DataValidade, "Data de Fabricação não pode ser maior ou igual a data de validade.");
        }

        public void Atualizar(ProdutoRequest request)
        {
            DescricaoProduto = request.DescricaoProduto;
            SituacaoProduto = (EnumSituacaoProduto)request.SituacaoProduto;
            DataFabricacao = request.DataFabricacao;
            DataValidade = request.DataValidade;
            CodigoFornecedor = request.CodigoFornecedor;
            NomeFornecedor = request.NomeFornecedor;
            CNPJFornecedor = request.CNPJFornecedor;
            if (request.Status.HasValue) Status = request.Status.Value;

            DomainException.LaunchWhen(string.IsNullOrEmpty(request.DescricaoProduto), "Descrição do Produto é de preenchimento obrigatorio.");
            DomainException.LaunchWhen(DataFabricacao >= DataValidade, "Data de Fabricação não pode ser maior ou igual a data de validade.");
        }
        private Produto() { }
    }
}
