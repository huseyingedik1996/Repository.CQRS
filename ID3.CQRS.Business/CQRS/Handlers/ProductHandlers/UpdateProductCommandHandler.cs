using AutoMapper;
using ID3.CQRS.Business.CQRS.Commands.ProductsCommands;
using ID3.CQRS.Entities.Entities;
using MediatR;
using MongoDB.Driver;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3.CQRS.Business.CQRS.Handlers.ProductHandlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IMongoCollection<Products> _productCollection;
        private readonly IMapper _mapper;
        public UpdateProductCommandHandler(IMongoCollection<Products> productCollection, IMapper mapper)
        {
            _productCollection = productCollection;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var result = _mapper.Map<Products>(request);

            await _productCollection.FindOneAndReplaceAsync(x => x.Id == request.Id, result);

            return Unit.Value;

        }
    }
}
