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
    internal partial class ConfigArea_Map : EntityTypeConfiguration<ConfigArea>
    {
        public ConfigArea_Map()
        {					
    		this.HasKey(t => t.Id);		
    		this.ToTable("ConfigArea");
    		this.Property(t => t.Id).HasColumnName("Id");
    		this.Property(t => t.Name).HasColumnName("Name").IsRequired().HasMaxLength(50);
    		this.Property(t => t.ProvinceId).HasColumnName("ProvinceId");
    		this.Property(t => t.CityId).HasColumnName("CityId");
    		this.Property(t => t.ZipCode).HasColumnName("ZipCode").HasMaxLength(50);
    		this.Property(t => t.AreaCode).HasColumnName("AreaCode").HasMaxLength(50);
    		this.Property(t => t.IsCashOnDelivery).HasColumnName("IsCashOnDelivery");
    		this.Property(t => t.IsEnable).HasColumnName("IsEnable");
    		this.Property(t => t.DisplayOrder).HasColumnName("DisplayOrder");
    		this.Property(t => t.CreateTime).HasColumnName("CreateTime");
    		this.Property(t => t.LastUpdateTime).HasColumnName("LastUpdateTime");
    	}
    }
}

