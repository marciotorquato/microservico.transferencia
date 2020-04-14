using Microservico.Transferencia.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Microservico.Transferencia.Repository.Mappings
{
    public class LancamentoMapping : IEntityTypeConfiguration<Lancamento>
    {
        /// <summary>
        /// Responsavel por fazer o mapeamento da classe com a tabela Lançamentos
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Lancamento> builder)
        {
            builder.HasKey(l => l.Id);

            builder.Property(l => l.ContaOrigem)
                .IsRequired();

            builder.Property(l => l.ContaDestino)
                .IsRequired();

            builder.Property(l => l.DataLancamento)
                .IsRequired();

            builder.ToTable("Lancamentos");
        }
    }
}