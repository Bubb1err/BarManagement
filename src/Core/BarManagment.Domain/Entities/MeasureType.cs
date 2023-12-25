

namespace BarManagment.Domain.Entities
{
    public sealed class MeasureType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double DefaultAmount { get; set; }
    }
}
