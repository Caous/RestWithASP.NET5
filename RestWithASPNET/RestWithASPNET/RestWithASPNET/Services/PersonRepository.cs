using Microsoft.EntityFrameworkCore;
using RestWithASPNET.Interfaces;
using RestWithASPNET.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET.Services
{
    public class PersonRepository : IPersonRepository
    {
        private readonly DbContext _context;

        public PersonRepository(DbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Person>> GetAllPeople()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
