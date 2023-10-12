using ApiProdutos.Application.Interfaces;
using ApiProdutos.Application.Models.Categorias;
using ApiProdutos.Application.Services;
using ApiProdutosDomain.Entities;
using ApiProdutosDomain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ApiProdutos.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaAppService _categoriaAppService;

        public CategoriasController(ICategoriaAppService categoriaAppService)
        {
            _categoriaAppService = categoriaAppService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CategoriasGetModel), 201)]
        public IActionResult Post(CategoriasPostModel model)
        {
            return StatusCode(201, new
            {
                mensagem = "Categoria cadastrada com sucesso.",
                categoria = _categoriaAppService.Create(model)
            });

        }

        [HttpPut]
        [ProducesResponseType(typeof(CategoriasGetModel), 200)]
        public IActionResult Put(CategoriasPutModel model)
        {
            return StatusCode(200, new
            {
                mensagem = "Categoria atualizada com sucesso.",
                categoria = _categoriaAppService.Update(model)
            });
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(CategoriasGetModel), 200)]
        public IActionResult Delete(Guid id)
        {
            return StatusCode(200, new
            {
                mensagem = "Os seguintes dados da categoria foram excluídos como sucesso.",
                categoria = _categoriaAppService.Delete(id)
            });
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<CategoriasGetModel>), 200)]
        public IActionResult GetAll()
        {
            return StatusCode(200, _categoriaAppService.GetAll());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CategoriasGetModel), 200)]
        public IActionResult GetById(Guid id)
        {
            return StatusCode(200, _categoriaAppService.GetById(id));
        }




    }
}
