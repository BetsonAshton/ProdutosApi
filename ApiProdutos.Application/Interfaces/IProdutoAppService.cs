using ApiProdutos.Application.Models.Produtos;
using ApiProdutosDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProdutos.Application.Interfaces
{
    public interface IProdutoAppService
    {
        ProdutosGetModel Create(ProdutosPostModel model);
        ProdutosGetModel Update(ProdutosPutModel model);
        ProdutosGetModel Delete(Guid id);
        List<ProdutosGetModel> GetAll();
        ProdutosGetModel GetById(Guid id);
    }
}
