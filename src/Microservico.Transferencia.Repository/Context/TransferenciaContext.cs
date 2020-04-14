using Microservico.Transferencia.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Microservico.Transferencia.Repository.Context
{
    public class TransferenciaContext : DbContext
    {
        public TransferenciaContext(DbContextOptions<TransferenciaContext> options) : base(options) { }

        public DbSet<ContaCorrente> ContaCorrentes { get; set; }
        public DbSet<Lancamento> Lancamentos { get; set; }
    }
}