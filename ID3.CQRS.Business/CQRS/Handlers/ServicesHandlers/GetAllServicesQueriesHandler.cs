using AutoMapper;
using ID3.CQRS.Business.CQRS.Queries.ServicesQueries;
using ID3.CQRS.Business.Dtos;
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
    public class GetAllServicesQueriesHandler : IRequestHandler<GetAllServicesQuery, List<ListServicesDto>>
    {
        private readonly IMongoCollection<Services> _servicesCollection;
        private readonly IMapper _mapper;

        public GetAllServicesQueriesHandler(IMongoCollection<Services> servicesCollection, IMapper mapper)
        {
            _servicesCollection = servicesCollection;
            _mapper = mapper;
        }

        public async Task<List<ListServicesDto>> Handle(GetAllServicesQuery request, CancellationToken cancellationToken)
        {
            var result = await _servicesCollection.Find(x => true).ToListAsync();

            return _mapper.Map<List<ListServicesDto>>(result);
        }
    }
}
