using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Rates.Commands
{
    public class CreateRateCommand:IRequest
    {
        public int RecipeId { get; set; }
        public int UserId { get; set; }
        public int Score { get; set; }
    }
}
