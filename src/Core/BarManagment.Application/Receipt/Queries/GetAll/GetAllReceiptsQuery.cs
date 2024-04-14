using MediatR;

namespace BarManagment.Application.Receipt.Queries.GetAll
{
    public sealed class GetAllReceiptsQuery : IRequest<IEnumerable<Domain.DomainEntities.Receipt>>
    {

    }
}
