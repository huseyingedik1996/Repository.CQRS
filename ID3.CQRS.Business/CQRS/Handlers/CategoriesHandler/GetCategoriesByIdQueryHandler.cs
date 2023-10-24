using AutoMapper;
using ID3.CQRS.Business.CQRS.Queries.CategoriesQueries;
using ID3.CQRS.Business.Dtos;
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
    public class GetCategoriesByIdQueryHandler : IRequestHandler<GetCategoriesByIdQuery,ListCategoriesDto>
    {
        private readonly IMongoCollection<Categories> _categoriesCollection;
        private readonly IMapper _mapper;

        public GetCategoriesByIdQueryHandler(IMongoCollection<Categories> categoriesCollection, Mapper mapper)
        {
            _categoriesCollection = categoriesCollection;
            _mapper = mapper;
        }

        public async Task<ListCategoriesDto> Handle(GetCategoriesByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _categoriesCollection.Find(x => x.Id == request.Id).FirstOrDefaultAsync();

            return _mapper.Map<ListCategoriesDto>(result);
        }
    }
}
