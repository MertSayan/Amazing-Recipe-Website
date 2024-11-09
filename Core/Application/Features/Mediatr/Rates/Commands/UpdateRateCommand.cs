using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Rates.Commands
{
    public class UpdateRateCommand:IRequest
    {
        public int RateId { get; set; }
        public int Score { get; set; }
    }
}
