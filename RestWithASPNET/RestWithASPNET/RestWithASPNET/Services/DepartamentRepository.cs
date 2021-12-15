using Microsoft.EntityFrameworkCore;
using RestWithASPNET.Interfaces;
using RestWithASPNET.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET.Services
{
    public class DepartamentRepository : IDepartamentRepository
    {
        private readonly DbContext _dbContext;

        public DepartamentRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Departament> CreateDepartament(Departament departament)
        {
            if (departament != null)
            {
                await _dbContext.Departament.AddAsync(departament);
                await _dbContext.SaveChangesAsync();
                return departament;
            }
            return null;
        }

        public async Task<String> DeleteDepartament(int id)
        {
            var departament = await _dbContext.Departament.FindAsync(id);
            if (departament != null)
            {
                _dbContext.Departament.Remove(departament);
                await _dbContext.SaveChangesAsync();
                return "Deleted with successed";
            }
            return "Error in deleted";
        }

        public async Task<Departament> FindByIdDepartament(int id)
        {

            var departament = await _dbContext.Departament.FindAsync(id);
            if (departament != null)
            {
                return departament;
            }
            return null;
        }

        public async Task<Departament> FindByName(string name)
        {
            var departament = await _dbContext.Departament.Where(x => x.NameDepartament == name).FirstOrDefaultAsync();
            if (departament != null)
            {
                return departament;
            }
            return null;
        }

        public async Task<IEnumerable<Departament>> GetAllDepartament()
        {
            return await _dbContext.Departament.ToListAsync();
        }

        public async Task<Departament> UpdateDepartament(Departament departament)
        {
           
            if (departament != null)
            {
                _dbContext.Departament.Update(departament);
                await _dbContext.SaveChangesAsync();
                return departament;
            }
            return null;
        }
    }
}
