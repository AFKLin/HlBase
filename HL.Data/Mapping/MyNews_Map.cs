using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using HL.Domain;

namespace HL.Data.Mapping
{
    public class MyNews_Map:EntityTypeConfiguration<MyNews>
    {
        public MyNews_Map()
        {
            this.HasKey(c => c.Id).Property(c => c.Id).HasColumnName("Id");
            this.Property(c => c.Name).HasColumnName("Name");
            this.Property(c => c.Aget).HasColumnName("Aget");
        }
    }
}
