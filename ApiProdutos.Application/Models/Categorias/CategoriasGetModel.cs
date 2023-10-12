using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProdutos.Application.Models.Categorias
{
    public class CategoriasGetModel
    {
        public Guid? IdCategoria { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
    }
}
