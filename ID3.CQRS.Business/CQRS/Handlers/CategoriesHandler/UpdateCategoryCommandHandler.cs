using AutoMapper;
using ID3.CQRS.Business.CQRS.Commands.CategoriesCommands;
using ID3.CQRS.Core.Entities;
using MediatR;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3.CQRS.Business.CQRS.Handlers.CategoriesHandler
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
    {
        private readonly IMongoCollection<Categories> _categoryCollection;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(IMongoCollection<Categories> categoryCollection, IMapper mapper)
        {
            _categoryCollection = categoryCollection;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var result = _mapper.Map<Categories>(request);
            await _categoryCollection.FindOneAndReplaceAsync(x => x.Id == request.Id,result);

            return Unit.Value;
        }
    }
}
