using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;
using ECS.Domain;

namespace ECS.Data.Mapping
{
    internal partial class ConfigAll_Map : EntityTypeConfiguration<ConfigAll>
    {
        public ConfigAll_Map()
        {					
    		this.HasKey(t => t.Name);		
    		this.ToTable("ConfigAll");
    		this.Property(t => t.Name).HasColumnName("Name").IsRequired().HasMaxLength(100);
    		this.Property(t => t.Value).HasColumnName("Value").IsRequired();
    	}
    }
}
