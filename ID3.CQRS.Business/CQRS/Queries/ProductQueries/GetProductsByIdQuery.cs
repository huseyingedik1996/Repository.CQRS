using Amazon.Runtime.Internal;
using ID3.CQRS.Business.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3.CQRS.Business.CQRS.Queries.ProductQueries
{
    public class GetProductsByIdQuery : IRequest<ProductListDto>
    {
        public int Id { get; set; }

        public GetProductsByIdQuery(int id)
        {
            Id = id;
        }
    }
}
