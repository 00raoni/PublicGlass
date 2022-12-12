using AutoGlass.Domain.Entidades.Produto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace AutoGlass.Infra.Persistencia
{
    public class Contexto : Microsoft.EntityFrameworkCore.DbContext
    {
        public Contexto() : base() { }
        public Contexto(Microsoft.EntityFrameworkCore.DbContextOptions<Contexto> options) : base(options) { }      

        public Microsoft.EntityFrameworkCore.DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Ignore<prmToolkit.NotificationPattern.Notification>();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Contexto).Assembly);            

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            SetData();
            return base.SaveChanges();
        }

        private void SetData()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.State == Microsoft.EntityFrameworkCore.EntityState.Added) entry.Property("DataInclusao").CurrentValue = DateTime.Now;
                if (entry.State == Microsoft.EntityFrameworkCore.EntityState.Modified) entry.Property("DataAlteracao").CurrentValue = DateTime.Now;
            }
        }
    }
}
