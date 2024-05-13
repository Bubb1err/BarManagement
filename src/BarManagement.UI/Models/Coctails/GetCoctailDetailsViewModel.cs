using BarManagement.UI.Models.CoctailIngredients;

namespace BarManagement.UI.Models.Coctails
{
    public sealed class GetCoctailDetailsViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public IEnumerable<CoctailIngredientViewModel> Ingredients { get; set; }

        public int TotalCoctailsCount { get; set; }

        public int CoctailRating { get; set; }
    }
}
