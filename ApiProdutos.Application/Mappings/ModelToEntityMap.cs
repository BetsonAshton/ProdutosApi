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
    public class ModelToEntityMap: Profile
    {
        public ModelToEntityMap() 
        {
            CreateMap<CategoriasPostModel, Categoria>()
               .AfterMap((src, dest) =>
               {
                   dest.IdCategoria = Guid.NewGuid();
               });

            CreateMap<CategoriasPutModel, Categoria>();

            CreateMap<ProdutosPostModel, Produto>()
                .AfterMap((src, dest) =>
                {
                    dest.IdProduto = Guid.NewGuid();
                    dest.DataHoraCadastro = DateTime.Now;
                });

            CreateMap<ProdutosPutModel, Produto>();


        }
    }
}
