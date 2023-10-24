using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3.CQRS.Business.CQRS.Commands.ServicesCommands
{
    public class DeleteServiceCommand : IRequest
    {
        public int Id { get; set; }

        public DeleteServiceCommand(int id)
        {
            Id = id;
        }
    }
}
