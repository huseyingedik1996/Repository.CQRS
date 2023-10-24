using ID3.CQRS.Business.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3.CQRS.Business.CQRS.Queries.ServicesQueries
{
    public class GetAllServicesQuery : IRequest<List<ListServicesDto>>
    {
    }
}
