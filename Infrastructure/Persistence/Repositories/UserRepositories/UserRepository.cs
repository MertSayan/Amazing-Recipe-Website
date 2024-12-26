using Application.Interfaces.UserInterface;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System.Linq.Expressions;

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

        public async Task<User> GetByUserWithOutPassword(int id)
        {

            var value = await _context.Users
                .Where(x => x.DeletedDate == null)
                .Include(x => x.Role)
                .FirstOrDefaultAsync(x => x.UserId == id);

            return value;
        }

        public async Task<List<User>> GetPagedUserAsync(int pageNumber, int pageSize)
        {
            return await _context.Users
                .Where(x => x.DeletedDate == null)
                .OrderBy(x => x.Name)
                .Skip((pageNumber - 1) * pageSize)// İlgili sayfa için kayıtları atla
                .Take(pageSize)// Sayfa başına veriyi al
                .ToListAsync();
        }

        public async Task<List<User>> GetRecentRegisters()
        {
            var values = await _context.Users
                .Where(x => x.DeletedDate == null)
                .Include(x=>x.Role)
                .OrderByDescending(x => x.CreatedDate)
                .Take(5)
                .ToListAsync();
            return values;
        }
    }
}
