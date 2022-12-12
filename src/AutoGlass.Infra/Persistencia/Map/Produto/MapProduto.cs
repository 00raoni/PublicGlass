using System.Data.Entity.ModelConfiguration;

namespace AutoGlass.Infra.Persistencia.Map.Produto
{
    public class MapProduto : EntityTypeConfiguration<AutoGlass.Domain.Entidades.Produto.Produto>
    {
        public MapProduto()
        {
            ToTable("Produto");

            Property(p => p.Id).HasColumnName("ProdutoId").IsRequired();
            Property(p => p.CNPJFornecedor).HasMaxLength(20);
            Property(p => p.DescricaoProduto).HasMaxLength(500).IsRequired();            
        }
    }
}
