

using BarManagment.Domain.DomainEntities.Base;

namespace BarManagment.Domain.DomainEntities
{
    public sealed class Receipt : BaseEntity
    {
        public Receipt(
            Guid id, 
            User barmen, 
            DateTime? paidTime = null, 
            bool isPaid = false)
            : base(id)
        {
            PaidTime = paidTime;
            IsPaid = isPaid;
            Drinks = new List<Drink>();
            Coctails = new List<Coctail>();
            BarmenId = barmen.Id;
        }
        public DateTime? PaidTime { get; private set; }
        public bool IsPaid { get; private set; }
        public ICollection<Drink> Drinks { get; private set; }
        public ICollection<Coctail> Coctails { get; private set; }
        public Guid BarmenId { get; private set; }
    }
}
