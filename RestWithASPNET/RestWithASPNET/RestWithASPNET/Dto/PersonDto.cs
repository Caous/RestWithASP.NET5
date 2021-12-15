﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET.Dto
{
    public class PersonDto
    {
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string ConfirmedPassword { get; set; }
        public string Email { get; set; }
        public string Departament { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DepartamentId { get; set; }

        
    }
}
