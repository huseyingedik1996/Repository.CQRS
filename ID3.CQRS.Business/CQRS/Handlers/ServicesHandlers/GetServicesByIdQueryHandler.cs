using AutoMapper;
using ID3.CQRS.Business.CQRS.Queries.ServicesQueries;
using ID3.CQRS.Business.Dtos;
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
    public class GetServicesByIdQueryHandler : IRequestHandler<GetServiceByIdQuery, ListServicesDto>
    {
        private readonly IMongoCollection<Services> _serviceCollection;
        private readonly IMapper _mapper;

        public GetServicesByIdQueryHandler(IMongoCollection<Services> serviceCollection, IMapper mapper)
        {
            _serviceCollection = serviceCollection;
            _mapper = mapper;
        }

        public async Task<ListServicesDto> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _serviceCollection.Find(x=> x.Id == request.Id).FirstOrDefaultAsync();

            return _mapper.Map<ListServicesDto>(result);
        }
    }
}
