﻿using CompStore.Core.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Data.Configuration
{
    public class SSDTypeConfiguration : IEntityTypeConfiguration<SSDType>
    {
        public void Configure(EntityTypeBuilder<SSDType> builder)
        {
            builder.Property(x => x.Type).HasMaxLength(50).IsRequired();
        }
    }
}
