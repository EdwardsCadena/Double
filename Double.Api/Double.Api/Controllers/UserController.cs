using AutoMapper;
using Double.Api.Response;
using Double.Core.DTOs;
using Double.Core.Entities;
using Double.Core.Interfaces;
using Double.Infrastructure.Interfaces;
using Double.Infrastructure.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Double.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _maper;
        private readonly IPasswordService _passwordService;
        public UserController(IUserRepository userRepository, IMapper mapper, IPasswordService passwordService)
        {
            _userRepository = userRepository;
            _maper = mapper;
            _passwordService = passwordService;
        }

        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<IActionResult> Post(UserDTOs userDTOs)
        {
            var user = _maper.Map<User>(userDTOs);
            user.Password = _passwordService.Hash(user.Password);
            await _userRepository.RegisterUser(user);
            var response = new ApiResponse<UserDTOs>(userDTOs);
            return Ok(response);
        }
    }
}
