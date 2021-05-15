using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using RDI.Api.Context.ModelBuilder;
using RDI.Api.Entities;
using RDI.Api.Entities.Base;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RDI.Api.Context
{
    public class RDIContextDb : DbContext
    {
        public RDIContextDb(DbContextOptions options) 
            : base(options)
        {
        }

        public DbSet<Card> Cards { get; set; }
        public DbSet<Customer> Customers { get; set; }


        protected override void OnModelCreating(Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CardModelBuilder());
            modelBuilder.ApplyConfiguration(new CustomerModelBuilder());
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {

            var collectionOfAddedEntities = ChangeTracker.Entries<Auditable>()
                .Where(x => x.State == EntityState.Added);

            foreach (var entity in collectionOfAddedEntities)
            {
                entity.Property("Created").CurrentValue = DateTime.UtcNow;
            }

            return base.SaveChangesAsync();
        }
    }
}
