using Application.Interfaces.RateInterface;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.RateRepositories
{
    public class RateRepository : IRateRepository
    {
        private readonly YemekContext _context;

        public RateRepository(YemekContext context)
        {
            _context = context;
        }

        public async Task<List<Rate>> GetByFilterAsync(Expression<Func<Rate, bool>> filter)
        {
            var values = await _context.Rates
                .Include(x => x.User)
                .Include(x => x.Recipe)
                .Where(filter)
                .ToListAsync();
            return values;
        }
    }
}
