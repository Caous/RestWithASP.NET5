using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RestWithASPNET.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET
{
    public class DbContext : IdentityDbContext<PersonModel>
    {
        public DbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
