using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Abouts.Commands
{
    public class CreateAboutCommand:IRequest
    {
        public string Description { get; set; }
    }
}
