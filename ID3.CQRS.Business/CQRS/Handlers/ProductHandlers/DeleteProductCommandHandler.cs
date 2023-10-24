using Amazon.Runtime.Internal;
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
    internal class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Products> _productCollection;

        public DeleteProductCommandHandler(IMapper mapper, IMongoCollection<Products> productCollection)
        {
            _mapper = mapper;
            _productCollection = productCollection;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var result = await _productCollection.DeleteOneAsync(x => x.Id == request.Id);

            return Unit.Value;
        }
    }
}
