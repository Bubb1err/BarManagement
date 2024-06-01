using BarManagment.Domain.Abstractions.Repository.Base;
using BarManagment.Domain.DomainEntities;
using MediatR;

namespace BarManagment.Application.Commoditys.Commands.SaveCommodity
{
    internal class SaveCommodityCommandHandler : IRequestHandler<SaveCommodityCommand, Commodity>
    {
        private readonly IRepository<Commodity> _commodityRepository;
        private readonly IRepository<DefaultMeasure> _measureRepository;
        private readonly IRepository<User> _usersRepository;

        public SaveCommodityCommandHandler(
            IRepository<Commodity> commodityRepository,
            IRepository<DefaultMeasure> measureRepository,
            IRepository<User> usersRepository)
        {
            _commodityRepository = commodityRepository;
            _measureRepository = measureRepository;
            _usersRepository = usersRepository;
        }
        public async Task<Commodity> Handle(SaveCommodityCommand request, CancellationToken cancellationToken)
        {
            var defaultMeasure = await _measureRepository.GetFirstOrDefaultAsync(measure => measure.Id == request.DefaultMeasureId);

            var user = await _usersRepository.GetFirstOrDefaultAsync(u => u.Id == request.UserId);

            var commodity = Commodity.Create(request.Title, request.Price, defaultMeasure, request.Description, user.CompanyCode);
            await _commodityRepository.AddAsync(commodity);

            await _commodityRepository.SaveChangesAsync();

            return commodity;
        }
    }
}
