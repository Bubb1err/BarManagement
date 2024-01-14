using BarManagment.Domain.DomainEntities.Base;

namespace BarManagment.Domain.DomainEntities
{
    public sealed class Coctail : BaseEntity
    {
        public Coctail(
            Guid id, 
            string name, 
            string description,
            decimal price)
            : base(id)
        {
            Name = name;
            Description = description;
            Price = price;
            Ingredients = new List<CoctailIngredient>();
        }
        private Coctail() { }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public IEnumerable<CoctailIngredient> Ingredients { get; set; }

        public static Coctail Create(string name, string description, decimal price, IEnumerable<CoctailIngredient> ingredients)
        {
            var coctail = new Coctail(Guid.NewGuid(), name, description, price);

            if (ingredients != null)
            {
                coctail.Ingredients.ToList().AddRange(ingredients);
            }

            return coctail;
        }

        public void Update(string name, string description, decimal price, IEnumerable<CoctailIngredient> ingredients)
        {
            Name = name;
            Description = description;
            Price = price;
            if (ingredients != null)
            {
                Ingredients.ToList().AddRange(ingredients);
            }
        }
    }
}
