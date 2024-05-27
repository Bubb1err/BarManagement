using BarManagement.UI.Models.Coctails;
using BarManagement.UI.Models.Drinks;

namespace BarManagement.UI.Models.Receipt
{
    public class ReceiptViewModel
    {
        public Guid Id { get; set; }

        public DateTime? PaidTime { get; set; }

        public DateTime Created { get; set; }

        public bool IsPaid { get; set; }

        public IEnumerable<GetDrinksViewModel> Drinks { get; set; }

        public IEnumerable<CoctailViewModel> Coctails { get; set; }

        public Guid BarmenId { get; set; }

        public decimal TotalPrice { get; set; } = 0; 

        public IEnumerable<Tuple<GetDrinksViewModel, int>> DrinksVM { get; set; }

        public IEnumerable<Tuple<CoctailViewModel, int>> CoctailsVM { get; set; }
    }
}
