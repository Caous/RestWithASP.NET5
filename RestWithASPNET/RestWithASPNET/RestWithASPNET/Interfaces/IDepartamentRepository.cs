using RestWithASPNET.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET.Interfaces
{
    public interface IDepartamentRepository
    {
        Task<IEnumerable<Departament>> GetAllDepartament();
        Task<Departament> CreateDepartament(Departament departament);
        Task<String> DeleteDepartament(int id);
        Task<Departament> UpdateDepartament(Departament departament);
        Task<Departament> FindByIdDepartament(int id);
        Task<Departament> FindByName(string name);
    }
}
