using Microsoft.EntityFrameworkCore;
using Netrin.Domain.Models;

namespace Netrin.Data.Context
{
    public class NetrinDbContext : DbContext
    {
        public NetrinDbContext(DbContextOptions<NetrinDbContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                         .SelectMany(e => e.GetProperties()
                             .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("VARCHAR(100)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(NetrinDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
