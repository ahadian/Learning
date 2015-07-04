using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkWithGenerics
{
    public class PenMap : EntityTypeConfiguration<Pen>
    {
        public PenMap()
        {
            HasKey(t => t.ID);
            Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Brand).IsRequired();
            Property(t => t.Weight).IsRequired();
            Property(t => t.Price).IsRequired();
            ToTable("Pens");
        }
    }
}
