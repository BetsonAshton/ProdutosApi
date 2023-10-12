using ApiProdutos.Application.Interfaces;
using ApiProdutos.Application.Models.Categorias;
using ApiProdutos.Application.Models.Produtos;
using ApiProdutosDomain.Entities;
using ApiProdutosDomain.Interfaces.Services;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProdutos.Application.Services
{
    public class ProdutoAppService: IProdutoAppService
    {
        private readonly IProdutoDomainService _produtoDomainService;
        private readonly ICategoriaDomainService? _categoriaDomainService;
        private readonly IMapper? _mapper;

        public ProdutoAppService(IProdutoDomainService produtoDomainService, ICategoriaDomainService? categoriaDomainService, IMapper? mapper)
        {
            _produtoDomainService = produtoDomainService;
            _categoriaDomainService = categoriaDomainService;
            _mapper = mapper;
        }

        public ProdutosGetModel Create(ProdutosPostModel model)
        {
            var produto = _mapper.Map<Produto>(model);
            _produtoDomainService.Create(produto);

            produto.Categoria = _categoriaDomainService.GetById(produto.IdCategoria.Value);
            return _mapper.Map<ProdutosGetModel>(produto);
        }

        public ProdutosGetModel Update(ProdutosPutModel model)
        {

            var produto = _produtoDomainService.GetById(model.IdProduto.Value);
            

            var updatedProduto = _mapper.Map(model, produto);
            updatedProduto.DataHoraCadastro = DateTime.Now;
            _produtoDomainService.Update(updatedProduto);

            updatedProduto.Categoria = _categoriaDomainService.GetById(updatedProduto.IdCategoria.Value);
            
            return _mapper.Map<ProdutosGetModel>(updatedProduto);
        }

        public ProdutosGetModel Delete(Guid id)
        {
            var produto = _produtoDomainService.GetById(id);

            //if (produto.IdCategoria.HasValue)
            //{
                produto.Categoria = _categoriaDomainService.GetById(produto.IdCategoria.Value);
            //}

            _produtoDomainService.Delete(id);

            return _mapper.Map<ProdutosGetModel>(produto);
        }

        
        public List<ProdutosGetModel> GetAll()
        {
            var produtos = _produtoDomainService.GetAll();
            var produtosGetModel = produtos.Select(p => new ProdutosGetModel
            {
                IdProduto = p.IdProduto,
                Nome = p.Nome,
                Descricao = p.Descricao,
                Preco = p.Preco,
                Quantidade = p.Quantidade,
                DataHoraCadastro = p.DataHoraCadastro,
                Categoria = new CategoriasGetModel
                {
                    IdCategoria = p.Categoria.IdCategoria,
                    Nome = p.Categoria.Nome,
                    Descricao = p.Categoria.Descricao
                    // Preencha outras propriedades da categoria conforme necessário
                }
            }).ToList();

            return produtosGetModel;
        }



        public ProdutosGetModel GetById(Guid id)
        {
            var produto = _produtoDomainService.GetById(id);
            return _mapper.Map<ProdutosGetModel>(produto);
        }

      
    }
}
