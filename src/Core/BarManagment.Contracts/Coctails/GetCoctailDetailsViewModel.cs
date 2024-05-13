using BarManagment.Domain.DomainEntities;

namespace BarManagment.Contracts.Coctails
{
    public sealed class GetCoctailDetailsViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public IEnumerable<CoctailIngredient> Ingredients { get; set; }

        public int TotalCoctailsCount { get; set; }

        public int CoctailRating { get; set; }
    }
}
