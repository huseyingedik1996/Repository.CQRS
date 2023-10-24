using ID3.CQRS.Business.CQRS.Commands.ServicesCommands;
using ID3.CQRS.Core.Entities;
using MediatR;
using MongoDB.Driver;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3.CQRS.Business.CQRS.Handlers.ServicesHandlers
{
    public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand>
    {
        private readonly IMongoCollection<Services> _serviceCollection;

        public CreateServiceCommandHandler(IMongoCollection<Services> serviceCollection)
        {
            _serviceCollection = serviceCollection;
        }

        public async Task<Unit> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {
            await _serviceCollection.InsertOneAsync(new Services
            {
                ServiceName = request.ServiceName,
                ServicePrice = request.ServicePrice,
                ServiceDescription = request.ServiceDescription
            });
            return Unit.Value;
        }
    }
}
