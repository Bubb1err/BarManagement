

using BarManagment.Domain.Entities.Base;

namespace BarManagment.Domain.Entities
{
    //Alcohol, Berry ...
    public sealed class CommodityType : Entity
    {
        public CommodityType(
            Guid id, 
            string commodityName, 
            MeasureType measureType)
            : base(id)
        {
            CommodityName = commodityName;
            MeasureTypeId = measureType.Id;
        }
        public string CommodityName { get; set; }

        //Foreign
        public Guid MeasureTypeId { get; private set; }
    }
}
