﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Rates.Commands
{
    public class RemoveRateCommand:IRequest
    {
        public int Id { get; set; }

        public RemoveRateCommand(int ıd)
        {
            Id = ıd;
        }
    }
}
