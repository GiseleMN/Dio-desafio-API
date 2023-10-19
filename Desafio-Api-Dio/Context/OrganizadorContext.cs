using Desafio_Api_Dio.Models;
using Microsoft.EntityFrameworkCore;

namespace Desafio_Api_Dio.Context
{
    public class OrganizadorContext : DbContext
    {
        public OrganizadorContext(DbContextOptions<OrganizadorContext> options) : base(options)
        {

        }

        public DbSet<Tarefas> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            base.OnModelCreating(mb);

            mb.Entity<Tarefas>().HasKey(k => k.Id);
            mb.Entity<Tarefas>().Property(p => p.Titulo).HasMaxLength(100).IsRequired();
            mb.Entity<Tarefas>().Property(p => p.Descricao).HasMaxLength(200).IsRequired();
            mb.Entity<Tarefas>().Property(p => p.Status).HasConversion<string>().IsRequired();
        }

    }
}