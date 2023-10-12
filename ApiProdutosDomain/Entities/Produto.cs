using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApiProdutosDomain.Entities
{
    public class Produto
    {
        private Guid? _idProduto;
        private string? _nome;
        private string? _descricao;
        private decimal? _preco;
        private int? _quantidade;
        private DateTime? _dataHoraCadastro;
        private Guid? _idCategoria;      
        private Categoria? categoria;

        public Guid? IdProduto { get => _idProduto; set => _idProduto = value; }
        public string? Nome { get => _nome; set => _nome = value; }
        public string? Descricao { get => _descricao; set => _descricao = value; }
        public decimal? Preco { get => _preco; set => _preco = value; }
        public int? Quantidade { get => _quantidade; set => _quantidade = value; }
        public DateTime? DataHoraCadastro { get => _dataHoraCadastro; set => _dataHoraCadastro = value; }
        public Guid? IdCategoria { get => _idCategoria; set => _idCategoria = value; }
        public Categoria? Categoria { get => categoria; set => categoria = value; }
    }
}
