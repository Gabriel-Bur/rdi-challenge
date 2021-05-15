using Microsoft.EntityFrameworkCore;
using RDI.Api.Entities;

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
    }
}
