using AutoGlass.Domain.Argumentos.Produto;
using AutoGlass.Domain.Interfaces.Servicos.Produto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace API
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutoController : Controller
    {
        private readonly IServicoProduto _servicoProduto;
        public ProdutoController(IServicoProduto servicoProduto)
        {
            _servicoProduto = servicoProduto;
        }

        [HttpGet]
        [Route("selecionar/{id}")]
        public IActionResult Selecionar(int id)
        {
            try
            {
                var response = _servicoProduto.Selecionar(id);                
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost, Route("adicionar")]
        public IActionResult Adicionar([FromBody]ProdutoRequest request)
        {
            try
            {
                var response = _servicoProduto.Adicionar(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut, Route("alterar")]
        public IActionResult Alterar([FromBody] ProdutoRequest request)
        {
            try
            {
                var response = _servicoProduto.Alterar(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet, Route("listar")]
        public IActionResult Listar()
        {
            try
            {
                var response = _servicoProduto.Listar();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet, Route("filtroParametro")]
        public IActionResult filtroParametro(string descricao, int page, int limit)
        {
            try
            {
                var response = _servicoProduto.FiltroParametro(descricao, page,limit);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet, Route("listarAtivos")]
        public IActionResult ListarAtivos()
        {
            try
            {
                var response = _servicoProduto.ListarAtivos();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("deletar/{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                var response = _servicoProduto.Deletar(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}