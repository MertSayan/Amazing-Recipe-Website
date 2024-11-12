using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.UserInterface
{
    public interface IUserRepository
    {
        Task<User> GetByFilterAsync(Expression<Func<User, bool>> filter);

    }
}
