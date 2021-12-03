using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET.Model
{
    public class PersonModel : IdentityUser
    {
       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Departament { get; set; }
    }
}
