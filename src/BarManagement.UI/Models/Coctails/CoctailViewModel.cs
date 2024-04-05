using BarManagement.UI.Models.CoctailIngredients;

namespace BarManagement.UI.Models.Coctails
{
    public class CoctailViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public IEnumerable<CoctailIngredientViewModel> Ingredients { get; set; }
    }
}
