using BarManagment.Domain.DomainEntities.Base;

namespace BarManagment.Domain.DomainEntities
{
    public sealed class Receipt : BaseEntity
    {
        private Receipt(
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

        private Receipt() { }

        public DateTime? PaidTime { get; private set; }

        public bool IsPaid { get; private set; }

        public IEnumerable<Drink> Drinks { get; private set; }

        public IEnumerable<Coctail> Coctails { get; private set; }

        public Guid BarmenId { get; private set; }

        public void Pay()
        {
            IsPaid = true;
            PaidTime = DateTime.Now;
        }

        public static Receipt Create(DateTime? paidTime, User barmen, bool isPaid, List<Drink> drinks, List<Coctail> coctails)
        {
            var receipt = new Receipt(Guid.NewGuid(), barmen, paidTime, isPaid);
            receipt.Drinks.ToList().AddRange(drinks);
            receipt.Coctails.ToList().AddRange(coctails);
            return receipt;
        }
    }
}
