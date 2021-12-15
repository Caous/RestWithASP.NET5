using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RestWithASPNET.Mappings;
using RestWithASPNET.Model;

namespace RestWithASPNET
{
    public class DbContext : IdentityDbContext<Person, Role, int,
                                IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public DbContext(DbContextOptions<DbContext> options) : base(options)
        {
        }
        public DbSet<Person> People { get; set; }
        public DbSet<Departament> Departament { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new PersonMap());
            builder.ApplyConfiguration(new DepartamentMap());




        }
    }
}
