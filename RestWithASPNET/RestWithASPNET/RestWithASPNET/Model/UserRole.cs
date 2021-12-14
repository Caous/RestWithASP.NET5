using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET.Model
{
    public class UserRole: IdentityUserRole<int>
    {
        public Person Person { get; set; }
        public Role Role { get; set; }
    }
}
