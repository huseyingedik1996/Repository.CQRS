using AutoMapper;
using ID3.CQRS.Business.CQRS.Commands.ProductsCommands;
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
    internal class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
    {
        private readonly IMongoCollection<Products> _productCollection;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IMongoCollection<Products> productCollection, IMapper mapper)
        {
            _productCollection = productCollection;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            await _productCollection.InsertOneAsync(new Products
            {
                Name = request.Name,
                Price = request.Price,
                Description = request.Description,
                ProductCategoryId = request.CategoryId,
            });

            return Unit.Value;

        }
    }
}
