namespace AutoGlass.Application
{
    public class Produto
    {
        private readonly IProdutoRepository _produtoRepository;        

        public Produto(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;            
        }  
        public void Add(ProdutoDto dto)
        {
            Produto p
            
             _produtoRepository.Add(new Domain.Produtos.Produto());
        }
    }
}