using MediatR;

namespace BarManagment.Application.Receipt.Queries.GetAll
{
    public sealed class GetAllReceiptsQuery : IRequest<IEnumerable<Domain.DomainEntities.Receipt>>
    {
        public GetAllReceiptsQuery(Guid userId)
        {
            UserId = userId;
        }

        public Guid UserId { get; }
    }
}
