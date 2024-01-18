namespace BarManagment.Application.DTO.Coctail
{
    public sealed class UpdateCoctailIngredientDTO
    {
        public Guid? Id { get; set; }
        public Guid CommodityId { get; set; }
        public int AmountInDefaultMeasure { get; set; }
    }
}
