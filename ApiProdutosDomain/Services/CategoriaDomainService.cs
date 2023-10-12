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
    public class CategoriaDomainService: ICategoriaDomainService
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaDomainService(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public void Create(Categoria entity)
        {
            
            
            
            _categoriaRepository.Create(entity);
        }

        public void Update(Categoria entity)
        {
            var categoria = _categoriaRepository.GetById((Guid)entity.IdCategoria);
            
            _categoriaRepository.Update(entity);
        }

        public void Delete(Guid id)
        {

            var categoria = _categoriaRepository.GetById(id);          

            _categoriaRepository.Delete(categoria);
        }

        public List<Categoria> GetAll()
        {
            return _categoriaRepository.GetAll();
        }

        public Categoria GetById(Guid id)
        {
            var categoria = _categoriaRepository.GetById(id);
      
            return categoria;
        }

        
    }
}
