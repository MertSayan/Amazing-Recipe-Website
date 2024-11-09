using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Materials.Commands
{
    public class RemoveMaterialCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveMaterialCommand(int ıd)
        {
            Id = ıd;
        }
    }
}
