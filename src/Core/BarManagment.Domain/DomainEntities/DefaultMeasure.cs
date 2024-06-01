using BarManagment.Domain.DomainEntities.Base;

namespace BarManagment.Domain.DomainEntities
{
    //ml, bottle
    public sealed class DefaultMeasure : BaseEntity
    {
        private DefaultMeasure(
            Guid id, 
            string measure,
            string companyCode) 
            : base(id)
        {
            Measure = measure;
            CompanyCode = companyCode;
        }
        private DefaultMeasure() { }
        public string Measure {  get; private set; }

        public string CompanyCode { get; private set; }
    }
}
