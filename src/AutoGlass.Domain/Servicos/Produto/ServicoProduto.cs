using AutoGlass.Domain.Argumentos.Produto;
using AutoGlass.Domain.Interfaces.Servicos.Produto;
using AutoGlass.Domain.Repositorio.Produto;
using AutoMapper;
using Dominio.Recurso;
using prmToolkit.NotificationPattern;

namespace Dominio.Servicos.Produto
{
    public class ServicoProduto : Notifiable, IServicoProduto
    {
        private readonly IRepositorioProduto _repositorio;
        private readonly IMapper _mapper;

        public ServicoProduto() { }

        public ServicoProduto(IRepositorioProduto repositorio, IMapper mapper)
        {
            _mapper = mapper;
            _repositorio = repositorio;
        }

        public ProdutoResponse Selecionar(int id)
        {
            if (id == 0)
            {
                AddNotification("Request", Mensagens.DADOS_NAO_INFORMADOS);
                return null;
            }

            return _mapper.Map<ProdutoResponse>(_repositorio.ObterPorId(id));
        }

        public ProdutoResponse Adicionar(ProdutoRequest request)
        {
            if (request == null)
            {
                AddNotification("Request", Mensagens.DADOS_NAO_INFORMADOS);
                return null;
            }

            AutoGlass.Domain.Entidades.Produto.Produto entidade = new AutoGlass.Domain.Entidades.Produto.Produto(request);
            //AddNotifications(entidade);

            if (IsInvalid()) return null;
            
            return _mapper.Map<ProdutoResponse>(_repositorio.Adicionar(entidade));
        }

        public ProdutoResponse Alterar(ProdutoRequest request)
        {
            if (request == null)
            {
                AddNotification("Request", Mensagens.DADOS_NAO_INFORMADOS);
                return null;
            }

            var entidade = _repositorio.ObterPorId(request.Id);

            if (entidade == null)
            {
                AddNotification("Validation", Mensagens.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            entidade.Atualizar(request);

            //AddNotifications(entidade);
            //if (IsInvalid()) return null;

            var response = _repositorio.Editar(entidade);
            return _mapper.Map<ProdutoResponse>(entidade); //ou (ProdutoResponse)entidade;
        }

        public IEnumerable<ProdutoResponse> Listar() => _mapper.Map<IEnumerable<ProdutoResponse>>(_repositorio.Listar().ToList());
        public IEnumerable<ProdutoResponse> ListarAtivos() => _mapper.Map<IEnumerable<ProdutoResponse>>(_repositorio.Listar().Where(x => x.Status == true).ToList());

        public IEnumerable<ProdutoResponse> FiltroParametro(string descricao, int page, int limit)
        {
            return _repositorio.FiltroParametro(descricao, page, limit).Where(x => x.Status == true).ToList();
        }
        public ProdutoResponse Deletar(int id)
        {           
            var entidade = _repositorio.ObterPorId(id);

            if (entidade == null)
            {
                AddNotification("Validation", Mensagens.DADOS_NAO_ENCONTRADOS);
                return null;
            }
            entidade.Status = false;            
            var response = _repositorio.Editar(entidade);
            return _mapper.Map<ProdutoResponse>(entidade);
        }
    }
}
