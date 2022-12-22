using AutoMapper;
using Double.Api.Response;
using Double.Core.DTOs;
using Double.Core.Entities;
using Double.Core.Interfaces;
using Double.Infrastructure.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Double.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TypeIdentiController : ControllerBase
    {
        private readonly ITypeIdentiRepository _TypeIdenti;
        private readonly IMapper _maper;
        public TypeIdentiController(ITypeIdentiRepository TypeIdenti, IMapper mapper)
        {
            _TypeIdenti = TypeIdenti;
            _maper = mapper;
        }

        // GET: api/<TypeIdentiController>
        [HttpGet]
        public async Task<IActionResult> GetTypeIdentis()
        {
            var tpi = await _TypeIdenti.GetTypeIdentis();
            var tpidto = _maper.Map<IEnumerable<TypeIdenti>>(tpi);
            return Ok(tpidto);
        }

        // GET api/<TypeIdentiController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTypeIdenti(int id)
        {
            var tyoei = await _TypeIdenti.GetTypeIdenti(id);
            var tyoeidto = _maper.Map<TypeIdenti>(tyoei);
            return Ok(tyoeidto);
        }

        // POST api/<TypeIdentiController>
        [HttpPost]
        public async Task<IActionResult> PostTypeIdenti(TypeIdentiDTOs Typeidentdrtos)
        {
            var type = _maper.Map<TypeIdenti>(Typeidentdrtos);
            await _TypeIdenti.InsertTypeIdenti(type);
            var updatedto = new ApiResponse<TypeIdentiDTOs>(Typeidentdrtos);
            return Ok(updatedto);
        }

        // PUT api/<TypeIdentiController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTypeIdenti(int id, TypeIdentiDTOs Typeidentdrtos)
        {
            var type = _maper.Map<TypeIdenti>(Typeidentdrtos);
            type.IdTypeIdenti= id;
            var Update = await _TypeIdenti.UpdateTypeIdenti(type);
            var updatedto = new ApiResponse<bool>(Update);
            return Ok(updatedto);
        }

        // DELETE api/<TypeIdentiController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTypeIdenti(int id)
        {
            var result = await _TypeIdenti.DeleteTypeIdenti(id);
            var delete = new ApiResponse<bool>(result);
            return Ok(delete);
        }
    }
}
