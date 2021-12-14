using RestWithASPNET.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET.Interfaces
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> GetAllPeople();
    }
}
