using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiProdutosDomain.Entities;

namespace ApiProdutos.Infra.Data.Mappings
{
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
           

            //Definir a chave primária da tabela
            builder.HasKey(c => c.IdCategoria);

            builder.Property(c => c.Nome).HasMaxLength(50).IsRequired();
            builder.Property(c => c.Descricao).IsRequired();


        }
    }
}
