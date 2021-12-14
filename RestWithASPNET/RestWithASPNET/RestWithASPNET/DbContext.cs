using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RestWithASPNET.Model;

namespace RestWithASPNET
{
    public class DbContext : IdentityDbContext<Person,Role,int,
                                IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public DbContext(DbContextOptions<DbContext> options) : base(options)
        {
        }
        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Person>(p => {
                
                //Configuration table name why Table Exists
                p.ToTable("tb_user");
                //Config Primary Key and Named
                p.HasKey(u => u.Id).HasName("PK_Persons");
                //Config columns
                p.Property(u => u.FirstName).HasColumnType("nvarchar(100)").IsRequired();
                p.Property(u => u.LastName).HasColumnType("nvarchar(100)").IsRequired();
                p.Property(u => u.Departament).HasColumnType("nvarchar(200)").IsRequired();

            });

            
        }
    }
}
