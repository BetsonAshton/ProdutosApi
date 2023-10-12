using ApiProdutos.Application.Models.Categorias;
using ApiProdutosDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProdutos.Application.Interfaces
{
    public interface ICategoriaAppService
    {
        CategoriasGetModel Create(CategoriasPostModel model);
        CategoriasGetModel Update(CategoriasPutModel model);
        CategoriasGetModel Delete(Guid id);
        List<CategoriasGetModel> GetAll();
        CategoriasGetModel GetById(Guid id);
    }
}
