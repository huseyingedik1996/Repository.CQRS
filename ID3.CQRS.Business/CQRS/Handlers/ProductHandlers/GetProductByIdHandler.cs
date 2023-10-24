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
    public class GetProductByIdHandler : IRequestHandler<GetProductsByIdQuery, ProductListDto>
    {
        private readonly IMongoCollection<Products> _productColletion;
        private readonly IMapper _mapper;

        public GetProductByIdHandler(IMongoCollection<Products> productColletion, IMapper mapper)
        {
            _productColletion = productColletion;
            _mapper = mapper;
        }

        public async Task<ProductListDto> Handle(GetProductsByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _productColletion.Find(x => x.Id == request.Id).FirstOrDefaultAsync();

            return _mapper.Map<ProductListDto>(result);
        }
    }
}
