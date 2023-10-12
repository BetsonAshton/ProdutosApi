using ApiProdutos.Application.Models.Categorias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProdutos.Application.Models.Produtos
{
    public class ProdutosGetModel
    {
        public Guid? IdProduto { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public decimal? Preco { get; set; }
        public int? Quantidade { get; set; }
        public DateTime? DataHoraCadastro { get; set; }

       
        public CategoriasGetModel Categoria { get; set; }
    }
}
