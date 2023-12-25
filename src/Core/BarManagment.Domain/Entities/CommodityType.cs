

namespace BarManagment.Domain.Entities
{
    //Alcohol, Berry ...
    public sealed class CommodityType
    {
        public int CommodityTypeId { get; set; }
        public string CommodityName { get; set; }

        //Foreign
        public int MeasureTypeId { get; set; }
    }
}
