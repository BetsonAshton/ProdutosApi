using ApiProdutosDomain.Entities;
using ApiProdutosDomain.Interfaces;
using ApiProdutosDomain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProdutosDomain.Services
{
    public class ProdutoDomainService: IProdutoDomainService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoDomainService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public void Create(Produto entity)
        {
             
                entity.IdProduto = Guid.NewGuid();
                entity.Nome = entity.Nome;
                entity.Descricao = entity.Descricao;
                entity.Preco = entity.Preco;
                entity.DataHoraCadastro = entity.DataHoraCadastro;
                entity.Quantidade = entity.Quantidade;
                entity.Categoria = entity.Categoria;

            _produtoRepository.Create(entity);
        }

        public void Update(Produto entity)
        {
            var produto = _produtoRepository.GetById((Guid)entity.IdProduto);
            
            _produtoRepository.Update(entity);
        }

        public void Delete(Guid id)
        {
            var produto = _produtoRepository.GetById(id);
          
            _produtoRepository.Delete(produto);
        }

        

        public Produto GetById(Guid id)
        {
            var produto = _produtoRepository.GetById(id);
            if (produto == null)
                throw new ArgumentException($"O Produto não foi encontrado, verifique o ID informado.");
                
            return _produtoRepository.GetById(id);
        }

       

        public List<Produto> GetAll()
        {
            return _produtoRepository.GetAll();
        }


    }
}
