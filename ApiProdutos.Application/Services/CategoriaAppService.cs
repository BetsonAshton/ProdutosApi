using ApiProdutos.Application.Interfaces;
using ApiProdutos.Application.Models.Categorias;
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
    public class CategoriaAppService: ICategoriaAppService
    {
        private readonly ICategoriaDomainService _categoriaDomainService;
        private readonly IMapper _mapper;

        public CategoriaAppService(ICategoriaDomainService categoriaDomainService, IMapper mapper)
        {
            _categoriaDomainService = categoriaDomainService;
            _mapper = mapper;
        }

        public CategoriasGetModel Create(CategoriasPostModel model)
        {
            var categoria = _mapper.Map<Categoria>(model);
            _categoriaDomainService.Create(categoria);

            return _mapper.Map<CategoriasGetModel>(categoria);
        }

        public CategoriasGetModel Update(CategoriasPutModel model)
        {
            var categoria = _mapper.Map<Categoria>(model);
            _categoriaDomainService.Update(categoria);

            return _mapper.Map<CategoriasGetModel>(categoria);
        }

        public CategoriasGetModel Delete(Guid id)
        {
            var categoria = _categoriaDomainService.GetById(id);


            _categoriaDomainService.Delete(id);

            return _mapper.Map<CategoriasGetModel>(categoria);
        }

        public List<CategoriasGetModel> GetAll()
        {
            var categorias = _categoriaDomainService.GetAll();
            return _mapper.Map<List<CategoriasGetModel>>(categorias);
        }

        public CategoriasGetModel GetById(Guid id)
        {
            var categoria = _categoriaDomainService.GetById(id);
            return _mapper.Map<CategoriasGetModel>(categoria);
        }
    }
}
