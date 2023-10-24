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
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, List<ListCategoriesDto>>
    {
        private readonly IMongoCollection<Categories> _categoryCollection;
        private readonly IMapper _mapper;

        public GetAllCategoriesQueryHandler(IMapper mapper, IMongoCollection<Categories> categoryCollection)
        {
            _mapper = mapper;
            _categoryCollection = categoryCollection;
        }

        public async Task<List<ListCategoriesDto>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var result = await _categoryCollection.Find(x => true).ToListAsync();

            return _mapper.Map<List<ListCategoriesDto>>(result);
        }
    }
}
