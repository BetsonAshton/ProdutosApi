using ApiProdutos.Application.Interfaces;
using ApiProdutos.Application.Models.Categorias;
using ApiProdutos.Application.Models.Produtos;
using ApiProdutos.Application.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ApiProdutos.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoAppService _produtoAppService;
       

        public ProdutosController(IProdutoAppService produtoAppService)
        {
            _produtoAppService = produtoAppService;
        }

      

        [HttpPost]
        [ProducesResponseType(typeof(ProdutosGetModel), 201)]
        public IActionResult Post(ProdutosPostModel model)
        {
            return StatusCode(201, new
            {
                mensagem = "Produto cadastrado com sucesso.",
                produto = _produtoAppService.Create(model)
            });
        }

        [HttpPut]
        [ProducesResponseType(typeof(ProdutosGetModel), 200)]
        public IActionResult Put(ProdutosPutModel model)
        {
            return StatusCode(200, new
            {
                mensagem = "Produto atualizado com sucesso.",
                produto = _produtoAppService.Update(model)
            });
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(CategoriasGetModel), 200)]
        public IActionResult Delete(Guid id)
        {
            return StatusCode(200, new
            {
                mensagem = "Os seguintes dados do produto foram excluídos como sucesso.",
                produto = _produtoAppService.Delete(id)
            });
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ProdutosGetModel>), 200)]
        public IActionResult GetAll()
        {
            return Ok(_produtoAppService.GetAll());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProdutosGetModel), 200)]
        public IActionResult GetById(Guid id)
        {
            return Ok(_produtoAppService.GetById(id));
        }
    }
}
