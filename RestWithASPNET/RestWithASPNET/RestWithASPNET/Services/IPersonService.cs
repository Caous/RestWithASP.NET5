using RestWithASPNET.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET.Services
{
    public interface IPersonService
    {
        PersonModel Create(PersonModel person);

        PersonModel FindById(int id);

        List<PersonModel> FindAll();

        PersonModel Update(PersonModel person);

        void Delete(int id);
    }
}
