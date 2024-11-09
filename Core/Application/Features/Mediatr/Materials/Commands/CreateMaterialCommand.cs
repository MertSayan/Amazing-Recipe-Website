using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Materials.Commands
{
    public class CreateMaterialCommand:IRequest
    {
        public string MaterialName { get; set; }
    }
}
