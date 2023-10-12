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
    public class CategoriaRepository : ICategoriaRepository
    {
        public void Create(Categoria entity)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Categorias.Add(entity);
                dataContext.SaveChanges();
            }
        }

        public void Update(Categoria entity)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Entry(entity).State = EntityState.Modified;
                dataContext.SaveChanges();
            }
        }

        public void Delete(Categoria entity)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Categorias.Remove(entity);
                dataContext.SaveChanges();
            }
        }

        public List<Categoria> GetAll()
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Categorias
                    .OrderBy(c => c.Nome)
                    .ToList();
            }
        }

        
        public Categoria GetById(Guid id)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Categorias
                    .Where(c => c.IdCategoria == id)
                    .FirstOrDefault();
            }
        }
    }
}

