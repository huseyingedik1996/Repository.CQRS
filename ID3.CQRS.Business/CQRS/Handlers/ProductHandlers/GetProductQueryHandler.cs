using Amazon.Runtime.Internal;
using AutoMapper;
using ID3.CQRS.Business.CQRS.Queries.ProductQueries;
using ID3.CQRS.Business.Dtos;
using ID3.CQRS.Entities.Entities;
using MediatR;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3.CQRS.Business.CQRS.Handlers.ProductHandlers
{
    public class GetProductQueryHandler : IRequestHandler<GetAllProdcutsQuery, List<ProductListDto>>
    {
        private readonly IMongoCollection<Products> _productsCollection;
        private readonly IMapper _mapper;

        public GetProductQueryHandler(IMongoCollection<Products> productsCollection, IMapper mapper)
        {
            _productsCollection = productsCollection;
            _mapper = mapper;
        }

        public async Task<List<ProductListDto>> Handle(GetAllProdcutsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productsCollection.Find(x => true).ToListAsync();

            return _mapper.Map<List<ProductListDto>>(products);
        }
    }
}
