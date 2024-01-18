namespace BarManagment.Application.DTO.Coctail
{
    public sealed class SaveCoctailIngredientDTO
    {
        public Guid CommodityId { get; set; }
        public int AmountInDefaultMeasure { get; set; }
    }
}
