using ID3.CQRS.Business.CQRS.Commands.ServicesCommands;
using ID3.CQRS.Core.Entities;
using MediatR;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3.CQRS.Business.CQRS.Handlers.ServicesHandlers
{
    public class DeleteServiceCommandHandler : IRequestHandler<DeleteServiceCommand>
    {
        private readonly IMongoCollection<Services> _serviceCollection;

        public DeleteServiceCommandHandler(IMongoCollection<Services> serviceCollection)
        {
            _serviceCollection = serviceCollection;
        }

        public async Task<Unit> Handle(DeleteServiceCommand request, CancellationToken cancellationToken)
        {
            await _serviceCollection.DeleteOneAsync(x => x.Id == request.Id);

            return Unit.Value;
        }
    }
}
