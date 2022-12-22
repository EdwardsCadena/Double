using Double.Core.Entities;
using Double.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Double.Core.Service
{
    public class UserService
    {

        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetLoginByCredentials(UserLogin userLogin)
        {
            return await _userRepository.GetLoginByCredentials(userLogin);
        }

        
    }
}
