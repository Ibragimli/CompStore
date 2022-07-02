using CompStore.Core.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Data.Configuration
{
    public class ProcessorModelConfiguration : IEntityTypeConfiguration<ProcessorModel>
    {
        public void Configure(EntityTypeBuilder<ProcessorModel> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(50);

        }

    }
}
