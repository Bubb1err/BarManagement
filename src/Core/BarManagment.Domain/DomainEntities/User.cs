using BarManagment.Domain.DomainEntities.Base;
using Microsoft.AspNetCore.Identity;

namespace BarManagment.Domain.DomainEntities
{
    public sealed class User : BaseEntity
    {
        public User(
            Guid id) : base(id) 
        {
            
        }

    }
}
