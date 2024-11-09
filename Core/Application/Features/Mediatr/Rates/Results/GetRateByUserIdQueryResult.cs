using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Rates.Results
{
    public class GetRateByUserIdQueryResult
    {
        public int RateId { get; set; }
        public string RecipeName { get; set; }
        public int Score { get; set; }
    }
}
