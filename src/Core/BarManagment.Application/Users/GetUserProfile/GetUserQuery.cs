using BarManagment.Domain.DomainEntities;
using MediatR;

namespace BarManagment.Application.Users.GetUserProfile
{
    public sealed class GetUserQuery : IRequest<User>
    {
        public GetUserQuery(Guid userId)
        {
            UserId = userId;
        }
        public Guid UserId { get; }
    }
}
