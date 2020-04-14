using Microservico.Transferencia.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Microservico.Transferencia.Repository.Mappings
{
    public class ContaCorrenteMapping : IEntityTypeConfiguration<ContaCorrente>
    {
        /// <summary>
        /// Responsavel por fazer o mapeamento da classe para a tabela ContaCorrentes
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<ContaCorrente> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Saldo)
                 .IsRequired();

            builder.ToTable("ContaCorrentes");
        }
    }
}