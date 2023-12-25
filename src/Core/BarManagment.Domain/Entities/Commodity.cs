namespace BarManagment.Domain.Entities
{
    public sealed class Commodity
    {
        public int CommodityId { get; set; }
        public string CommodityName { get; set; }
        public double Price { get; set; }

        //foreign
        public int CommodityTypeId { get; set;}
    }
}
