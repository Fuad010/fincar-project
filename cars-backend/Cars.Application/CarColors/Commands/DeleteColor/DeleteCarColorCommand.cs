﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Application.CarColors.Commands.DeleteColor 
{
    public class DeleteCarColorCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
