using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RDI.Api.Entities;
using System;

namespace RDI.Api.Context.ModelBuilder
{
    public class CardModelBuilder : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder
                .HasKey(p => p.CardId);

            builder
                .HasAlternateKey(p => new { p.CardNumber, p.CustomerId});
        }
    }
}
