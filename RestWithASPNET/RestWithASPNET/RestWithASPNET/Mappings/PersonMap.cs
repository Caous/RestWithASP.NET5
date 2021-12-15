using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestWithASPNET.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET.Mappings
{
    public class PersonMap : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {

            builder.ToTable("tb_user");
            builder.HasKey(u => u.Id).HasName("PK_Persons");
            builder.Property(u => u.FirstName).HasColumnType("nvarchar(100)").IsRequired();
            builder.Property(u => u.LastName).HasColumnType("nvarchar(100)").IsRequired();
            builder.Property(u => u.DtInclused).IsRequired();
            builder.Property(u => u.DtExclused).IsRequired(false);
            builder.Property(u => u.DepartamentId).HasColumnName("DepartamentId");
            builder.HasOne(d => d.Departament)
             .WithMany()
             .HasForeignKey(d => d.DepartamentId).IsRequired(false);
        }
    }
}
