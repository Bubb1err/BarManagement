using BarManagment.Domain.Abstractions.Repository.Base;
using BarManagment.Domain.DomainEntities;
using BarManagment.Domain.Exceptions;
using MediatR;


namespace BarManagment.Application.Commoditys.Commands.UpdateCommodity
{
    internal class UpdateCommodityCommandHandler : IRequestHandler<UpdateCommodityCommand, Commodity>
    {
        private readonly IRepository<Commodity> _commodityRepository;
        private readonly IRepository<DefaultMeasure> _measureRepository;

        public UpdateCommodityCommandHandler(
            IRepository<Commodity> commodityRepository,
            IRepository<DefaultMeasure> measureRepository)
        {
            _commodityRepository = commodityRepository;
            _measureRepository = measureRepository;
        }
        public async Task<Commodity> Handle(UpdateCommodityCommand request, CancellationToken cancellationToken)
        {
            var commodity = await _commodityRepository.GetFirstOrDefaultAsync(c => c.Id == request.Id);

            if (commodity == null)
            {
              throw new ExecutingException($"Commodity with id {request.Id} was not found.", System.Net.HttpStatusCode.NotFound);
            }

            var defaultMeasure = await _measureRepository.GetFirstOrDefaultAsync(measure => measure.Id == request.DefaultMeasureId);

            if (defaultMeasure == null)
            {
              throw new ExecutingException($"Measure with id {request.DefaultMeasureId} was not found.", System.Net.HttpStatusCode.NotFound);
            }

            commodity.Update(request.Title, request.Price, defaultMeasure, request.Description);
            _commodityRepository.Update(commodity);

            await _commodityRepository.SaveChangesAsync();
            return commodity;
        }
    }
}
