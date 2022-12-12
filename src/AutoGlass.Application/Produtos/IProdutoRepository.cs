using AutoGlass.Domain.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGlass.Application
{
    public interface IProdutoRepository : IRepository<AutoGlass.Domain.Produtos.Produto>
    {
    }
}
