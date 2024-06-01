using BarManagment.Domain.DomainEntities.Base;

namespace BarManagment.Domain.DomainEntities
{
    public sealed class Receipt : BaseEntity
    {
        private Receipt(
            Guid id,
            User barmen,
            DateTime created,
            string companyCode,
            DateTime? paidTime = null,
            bool isPaid = false)
            : base(id)
        {
            PaidTime = paidTime;
            IsPaid = isPaid;
            Drinks = new List<Drink>();
            Coctails = new List<Coctail>();
            BarmenId = barmen.Id;
            Created = created;
            CompanyCode = companyCode;
        }

        private Receipt() { }

        public DateTime? PaidTime { get; private set; }

        public DateTime Created { get; private set; }

        public bool IsPaid { get; private set; }

        public List<Drink> Drinks { get; private set; }

        public List<Coctail> Coctails { get; private set; }

        public Guid BarmenId { get; private set; }

        public string CompanyCode { get; private set; }

        public void Pay()
        {
            IsPaid = true;
            PaidTime = DateTime.Now;
        }

        public static Receipt Create(DateTime? paidTime, User barmen, bool isPaid, List<Drink> drinks, List<Coctail> coctails, string companyCode)
        {
            var receipt = new Receipt(Guid.NewGuid(), barmen, DateTime.Now, companyCode, paidTime, isPaid);
            receipt.Drinks.AddRange(drinks);
            receipt.Coctails.AddRange(coctails);
            return receipt;
        }
    }
}
