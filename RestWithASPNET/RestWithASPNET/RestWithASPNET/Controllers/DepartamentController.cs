using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithASPNET.Dto;
using RestWithASPNET.Interfaces;
using RestWithASPNET.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestWithASPNET.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class DepartamentController : ControllerBase
    {
        private readonly ILogger<DepartamentController> _logger;

        public IDepartamentRepository _departamentRepository { get; }

        public DepartamentController(ILogger<DepartamentController> logger, IDepartamentRepository departamentRepository)
        {
            _logger = logger;
            _departamentRepository = departamentRepository;
        }
        // GET: api/<DepartamentController>
        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            return Ok(await _departamentRepository.GetAllDepartament());
        }

        // GET api/<DepartamentController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Departament depar = await _departamentRepository.FindByIdDepartament(id);
            if (depar != null)
            {
                return Ok(depar);
            }
            return NotFound("User not found");
        }

        // POST api/<DepartamentController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DepartamentDto model)
        {
            if (ModelState.IsValid)
            {
                Departament dep = await _departamentRepository.FindByName(model.NameDepartament);

                if (dep == null)
                {
                    dep = new Departament
                    {
                        NameDepartament = model.NameDepartament,
                        DesDepartament = model.DesDepartament,
                        DtInclused = DateTime.Now
                    };

                    var result = await _departamentRepository.CreateDepartament(dep);

                    if (result != null)
                    {
                        return Ok("User created");
                    }
                    else{
                        return BadRequest("Have a probleman in request to created");
                    }
                }
            }
            return BadRequest("Parameters incompleted");

        }

        // PUT api/<DepartamentController>/5
        [HttpPut()]
        public async Task<IActionResult> Put([FromBody]DepartamentDto model)
        {
            if (ModelState.IsValid)
            {
                Departament dep = await _departamentRepository.FindByIdDepartament(model.id.Value);
                if (dep != null)
                {

                    dep.NameDepartament = model.NameDepartament;
                    dep.DesDepartament = model.DesDepartament;

                    var result = await _departamentRepository.UpdateDepartament(dep);

                    if (result != null)
                    {
                        return Ok("User created with successed");
                    }
                    else
                    {
                        return BadRequest("Have a probleman with method created");
                    }

                }
                else{
                    return NotFound("User not found");
                }
            }
            return BadRequest("Parameters incompleted");
        }

        // DELETE api/<DepartamentController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Departament dep = await _departamentRepository.FindByIdDepartament(id);
            if (dep != null)
            {
                var result = await _departamentRepository.DeleteDepartament(id);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Have a probleman with user to deleted");
                }
            }
            return NotFound("User not found");
            
        }
    }
}
