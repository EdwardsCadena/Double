using AutoMapper;
using Double.Api.Response;
using Double.Core.DTOs;
using Double.Core.Entities;
using Double.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Double.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {

        private readonly IPersonRepository _personRepository;
        private readonly IMapper _maper;
        public PersonsController(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _maper = mapper;
        }

        // GET: api/<PersonsController>
        [HttpGet]
        public async Task<IActionResult> GetPersons()
        {
            var people = await _personRepository.GetPersons();
            var peoplesdto = _maper.Map<IEnumerable<Person>>(people);
            return Ok(peoplesdto);
        }

        // GET api/<PersonsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPerson(int id)
        {
            var people  = await _personRepository.GetPerson(id);
            var peopledto = _maper.Map<Person>(people);
            return Ok(peopledto);
        }

        // POST api/<PersonsController>
        [HttpPost]
        public async Task<IActionResult> PostPerson(PersonDTOs peopledto)
        {
            var peolpe = _maper.Map<Person>(peopledto);
            await _personRepository.InsertPerson(peolpe);
            var updatedto = new ApiResponse<PersonDTOs>(peopledto);
            return Ok(updatedto);
        }

        // PUT api/<PersonsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerson(int id, PersonDTOs peopledto)
        {
            var serv = _maper.Map<Person>(peopledto);
            serv.Identifier = id;
            var Update = await _personRepository.UpdatePerson(serv);
            var updatedto = new ApiResponse<bool>(Update);
            return Ok(updatedto);
        }

        // DELETE api/<PersonsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            var result = await _personRepository.DeletePerson(id);
            var delete = new ApiResponse<bool>(result);
            return Ok(delete);
        }
    }
}
