using ApiProdutos.Application.Models.Categorias;
using ApiProdutos.Application.Models.Produtos;
using ApiProdutosDomain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProdutos.Application.Mappings
{
    public class EntityToModelMap: Profile
    {
        public EntityToModelMap()
        {
            CreateMap<Categoria, CategoriasGetModel>();
            CreateMap<Produto, ProdutosGetModel>();


        }
    }
}
