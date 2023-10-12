using ApiProdutosDomain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProdutos.Infra.Data.Mappings
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            

           
            builder.HasKey(p => p.IdProduto);

            
            builder.Property(p => p.Nome).HasMaxLength(150).IsRequired();
            builder.Property(p => p.Descricao).HasMaxLength(500).IsRequired();
            builder.Property(p => p.Preco).IsRequired();
            builder.Property(p => p.Quantidade).IsRequired();
            builder.Property(p => p.DataHoraCadastro).IsRequired();
            builder.Property(p => p.IdCategoria).IsRequired();

            //mapeamento do relacionamento 1 para muitos
            // e da foreign key(chave estranheira)
            builder.HasOne(p => p.Categoria) // Produto tem 1 categoria
                .WithMany(c => c.Produtos) //Categoria tem muitos Produtos
                .HasForeignKey(p => p.IdCategoria); //Chave estrangeira


        }
    }
}
