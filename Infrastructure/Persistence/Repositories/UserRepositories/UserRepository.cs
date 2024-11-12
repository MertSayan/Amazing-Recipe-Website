using Application.Interfaces.UserInterface;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.UserRepositories
{
    public class UserRepository : IUserRepository
    {
        public YemekContext _context;

        public UserRepository(YemekContext context)
        {
            _context = context;
        }

        public async Task<User> GetByFilterAsync(Expression<Func<User, bool>> filter)
        {
            var value=await _context.Users.Where(filter)
                .Include(x=>x.Role)
                .FirstOrDefaultAsync();
            return value;
        }
    }
}
