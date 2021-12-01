using RestWithASPNET.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RestWithASPNET.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private int count;
        public PersonModel Create(PersonModel person)
        {
            return person;
        }

        public void Delete(int id)
        {
        }

        public List<PersonModel> FindAll()
        {
            List<PersonModel> peapleo = new List<PersonModel>();

            for (int i = 0; i < 5; i++)
            {
                PersonModel person = new PersonModel { Departament = "Teste", Email = "Teste@Teste.com", Id = '0', FirstName = "Teste", LastName = "Teste" };
                peapleo.Add(person);
            }

            return peapleo;
        }

        public PersonModel FindById(int id)
        {
             
            return new PersonModel
            {

                Id = id,
                FirstName = "Gustavo",
                LastName = "Nascimento",
                Departament = "Developer",
                Email = "caous.g@gmail.com"
            }; 
                
        }

        public PersonModel Update(PersonModel person)
        {
            return person;
        }


        private PersonModel MockPerson(int i)
        {

            return new PersonModel
            {
                Id = IncrementAndGet(),
                FirstName = "Gustavo",
                LastName = "Nascimento",
                Email = "caous.g@gmail",
                Departament = "Dev"
            };
        }

        private int IncrementAndGet()
        {

            return Interlocked.Increment(ref count);
        }
    }
}
