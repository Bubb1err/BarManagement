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
        private DefaultMeasure() { }
        public string Measure {  get; private set; }
    }
}
