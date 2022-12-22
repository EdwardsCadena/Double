using Double.Core.Entities;
using Double.Core.Interfaces;
using Double.Infrastructure.Data;
using Double.Infrastructure.Interfaces;
using Double.Infrastructure.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Double.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DoublepContext _context;
        protected readonly DbSet<User> _entities;
        private readonly IPasswordService _passwordService;

        public UserRepository(DoublepContext context, IPasswordService passwordService)
        {
            _context = context;
            _entities = context.Set<User>();
            _passwordService = passwordService;
        }

        public async Task<User> GetLoginByCredentials(UserLogin login)
        {
            return await _entities.FirstOrDefaultAsync(x => x.UserName == login.Username);
        }
        public async Task RegisterUser(User user)
        {
            DateTime currentDate = DateTime.Now;
            User registro = new User
            {
                UserName = user.UserName,
                Password = user.Password,
                DateCreation = currentDate,
            };
            _context.Users.Add(registro);
            await _context.SaveChangesAsync();
        }
    }
}
