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
    public class CreateCategoriesCommandHandler : IRequestHandler<CreateCategoryCommand>
    {
        private readonly IMongoCollection<Categories> _categoryCollection;

        public CreateCategoriesCommandHandler(IMongoCollection<Categories> categoryCollection)
        {
            _categoryCollection = categoryCollection;
        }

        public async Task<Unit> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            await _categoryCollection.InsertOneAsync(new Categories
            {
                Name = request.Name
            });

            return Unit.Value;
        }
    }
}
