using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithASPNET.Model;
using RestWithASPNET.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {


        private readonly ILogger<PersonController> _logger;
        private IPersonService _personService;
        private readonly UserManager<PersonModel> _userManager;

        public PersonController(ILogger<PersonController> logger, IPersonService personService, UserManager<PersonModel> userManager)
        {
            _logger = logger;
            _personService = personService;
            _userManager = userManager;
        }

        [HttpGet()]
        public IActionResult Get()
        {

            return Ok(_personService.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {

            return Ok(_personService.FindById(id));

        }

        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] PersonModel person)
        {

            var user = await _userManager.FindByEmailAsync(person.Email);
            if (user == null)
            {
                user = new PersonModel() {
                    UserName = person.UserName,
                    Email = person.Email,
                    PasswordHash = person.PasswordHash,
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    Departament = person.Departament
                };

                var result = await _userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    return Ok("Criou com sucesso");
                }
            }
            return BadRequest("Ouve um erro na API");

            //return Ok(_personService.Create(person));
        }

        [HttpPut()]
        public IActionResult Put([FromBody] PersonModel person)
        {

            return Ok(_personService.Update(person));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _personService.Delete(id);
            return Ok("Delete Sucess");
        }


        private bool IsNumber(string input) {

            
            try
            {
                int valor = Convert.ToInt32(input);
                return true;
            }
            catch (Exception ex)
            {
                var error = ex.Message;
                return false;
            }
        }
    }
}
