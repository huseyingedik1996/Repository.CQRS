using AutoMapper;
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
    public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand>
    {
        private readonly IMongoCollection<Services> _serviceCollection;
        private readonly IMapper _mapper;

        public UpdateServiceCommandHandler(IMongoCollection<Services> serviceCollection, IMapper mapper)
        {
            _serviceCollection = serviceCollection;
            _mapper = mapper;
        }

        async Task<Unit> IRequestHandler<UpdateServiceCommand, Unit>.Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            var result = _mapper.Map<Services>(request);
            await _serviceCollection.FindOneAndReplaceAsync(x=> x.Id == request.Id, result);

            return Unit.Value;
        }
    }
}
