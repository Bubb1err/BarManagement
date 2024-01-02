using BarManagment.Domain.DomainEntities.Base;

namespace BarManagment.Domain.DomainEntities
{
    //ml, bottle
    public sealed class DefaultMeasure : BaseEntity
    {
        public DefaultMeasure(
            Guid id, 
            string measure) 
            : base(id)
        {
            Measure = measure;
        }
        public string Measure {  get; private set; }
    }
}
