using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RDI.Api.Entities;
using System;

namespace RDI.Api.Context.ModelBuilder
{
    public class CustomerModelBuilder : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder
                .HasKey(p => p.CustomerId);

            builder
                .HasMany(p => p.Cards)
                .WithOne(p => p.CustomerCardOwner);
        }
    }
}
