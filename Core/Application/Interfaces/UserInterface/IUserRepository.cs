using Domain;
using System.Linq.Expressions;

namespace Application.Interfaces.UserInterface
{
    public interface IUserRepository
    {
        Task<User> GetByFilterAsync(Expression<Func<User, bool>> filter);
        Task<List<User>> GetRecentRegisters();

        Task<User> GetByUserWithOutPassword(int id);
    }
}
