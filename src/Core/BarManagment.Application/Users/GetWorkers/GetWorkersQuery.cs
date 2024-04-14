using BarManagment.Domain.DomainEntities;
using MediatR;

namespace BarManagment.Application.Users.GetWorkers
{
    public sealed class GetWorkersQuery : IRequest<IEnumerable<User>>
    {
        public GetWorkersQuery(Guid adminId)
        {
            AdminId = adminId;
        }

        public Guid AdminId { get; }
    }
}
