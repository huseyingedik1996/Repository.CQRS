﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3.CQRS.Business.CQRS.Commands.ServicesCommands
{
    public class UpdateServiceCommand : IRequest
    {
        public int Id { get; set; }

        public string ServiceName { get; set; }

        public decimal ServicePrice { get; set; }

        public string ServiceDescription { get; set; }
    }
}
