using BarManagment.Domain.Abstractions.Repository.Base;
using BarManagment.Domain.DomainEntities;
using MediatR;

namespace BarManagment.Application.Commoditys.Commands.SaveCommodity
{
    internal class SaveCommodityCommandHandler : IRequestHandler<SaveCommodityCommand, Commodity>
    {
        private readonly IRepository<Commodity> _commodityRepository;
        private readonly IRepository<DefaultMeasure> _measureRepository;

        public SaveCommodityCommandHandler(
            IRepository<Commodity> commodityRepository,
            IRepository<DefaultMeasure> measureRepository)
        {
            _commodityRepository = commodityRepository;
            _measureRepository = measureRepository;
        }
        public async Task<Commodity> Handle(SaveCommodityCommand request, CancellationToken cancellationToken)
        {
            //var commodity = await _commodityRepository.GetFirstOrDefaultAsync(c => c.Id == request.Id);

            var defaultMeasure = await _measureRepository.GetFirstOrDefaultAsync(measure => measure.Id == request.DefaultMeasureId);

            //if (commodity is null)
            //{
                var commodity = Commodity.Create(request.Title, request.Price, defaultMeasure, request.Description);
                await _commodityRepository.AddAsync(commodity);
            //}
            //else
            //{
            //    Commodity.Update(commodity, request.Title, request.Price, defaultMeasure, request.Description);
            //    _commodityRepository.Update(commodity);
            //}

            await _commodityRepository.SaveChangesAsync();

            return commodity;
        }
    }
}
