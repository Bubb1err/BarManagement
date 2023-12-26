using BarManagment.Domain.Entities.Base;

namespace BarManagment.Domain.Entities
{
    public sealed class Receipt : Entity
    {
        public Receipt(
            Guid id,
            User user)
            : base (id)
        {
            UserId = id;
        }

        //foreign 
        public Guid UserId { get; private set; }
    }
}
