using BarManagment.Domain.DomainEntities;

namespace BarManagment.Application.Core.Abstractions.Authentication
{
    public interface IJwtProvider
    {
        string Create(User user);
    }
}
