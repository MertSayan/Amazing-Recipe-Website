using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Categorys.Commands
{
    public class RemoveCategoryCommand:IRequest
    {
        public int Id { get; set; }

        public RemoveCategoryCommand(int ıd)
        {
            Id = ıd;
        }
    }
}
