using ApiProdutos.Infra.Data.Contexts;
using ApiProdutosDomain.Entities;
using ApiProdutosDomain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProdutos.Infra.Data.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        public void Create(Produto entity)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Produtos.Add(entity);
                dataContext.SaveChanges();
            }
        }

        public void Update(Produto entity)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Attach(entity);
                dataContext.Entry(entity).State = EntityState.Modified;
                dataContext.SaveChanges();
            }
        }

        public void Delete(Produto entity)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Produtos.Remove(entity);
                dataContext.SaveChanges();
            }
        }

        public List<Produto> GetAll()
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Produtos
                    .Include(p => p.Categoria)
                    .OrderBy(p => p.Nome)
                    .ToList();
            }
        }

        public Produto GetById(Guid id)
        {
            using (var dataContext = new DataContext())
            {
                var produto = dataContext.Produtos
                    .Include(p => p.Categoria)
                    .Where(p => p.IdProduto == id)
                    .FirstOrDefault();

                return produto;
            }
        }
    }
}
