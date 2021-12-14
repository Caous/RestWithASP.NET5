using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RestWithASPNET.Dto;
using RestWithASPNET.Interfaces;
using RestWithASPNET.Model;
using System;
using System.Threading.Tasks;

namespace RestWithASPNET.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {


        private readonly ILogger<PersonController> _logger;
        private IPersonRepository _personRepository;
        private readonly UserManager<Person> _userManager;
        public SignInManager<Person> _signInManager;

        public PersonController(ILogger<PersonController> logger, IPersonRepository personRepository, UserManager<Person> userManager, SignInManager<Person> signInManager)
        {
            _logger = logger;
            _personRepository = personRepository;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            
            return Ok(await _personRepository.GetAllPeople());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(id.ToString());
                if (user != null)
                {
                    return Ok(user);
                }
                else
                {
                    return NotFound("User not found");
                }

            }
            return BadRequest("Id not found");

        }

        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] PersonDto person)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(person.Email);
                if (user == null)
                {
                    user = new Person()
                    {
                        UserName = person.UserName,
                        Email = person.Email,
                        PasswordHash = person.Password,
                        FirstName = person.FirstName,
                        LastName = person.LastName,
                        Departament = person.Departament
                    };

                    var result = await _userManager.CreateAsync(user,person.Password);

                    if (result.Succeeded)
                    {
                        user = await _userManager.Users.FirstOrDefaultAsync(u => u.Email == person.Email);
                        return Ok(user);
                    }
                }
                return BadRequest("User exists");
            }
            return BadRequest("Parameter not found");

        }

        [HttpPut()]
        public async Task<IActionResult> Put([FromBody] PersonDto person)
        {

            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(person.Email);

                if (user != null)
                {
                    var resultLogin = await _signInManager.CheckPasswordSignInAsync(user, person.Password, false);
                    if (resultLogin.Succeeded)
                    {
                        user.UserName = person.UserName;
                        user.Email = person.Email;
                        user.FirstName = person.FirstName;
                        user.LastName = person.LastName;
                        user.Departament = person.Departament;


                        var result = await _userManager.UpdateAsync(user);

                        if (result.Succeeded)
                        {
                            user = await _userManager.Users.FirstOrDefaultAsync(u => u.Email == person.Email);
                            return Ok(user);
                        }
                    }
                    else { NotFound("Password not checked"); }

                }
                return BadRequest("User exists or E-mail Incorreted");
            }
            return BadRequest("Ouve um erro na API");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(id.ToString());
                if (user != null)
                {
                    var result = await _userManager.DeleteAsync(user);

                    if (result.Succeeded)
                        return Ok("Deleted with successed");

                }
                return NotFound("User not found");
            }
            return BadRequest("Ouve um erro na API");
        }


        private bool IsNumber(string input)
        {


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
