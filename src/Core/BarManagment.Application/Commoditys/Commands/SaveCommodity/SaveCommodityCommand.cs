﻿using BarManagment.Domain.DomainEntities;
using MediatR;

namespace BarManagment.Application.Commoditys.Commands.SaveCommodity
{
    public sealed class SaveCommodityCommand : IRequest<Commodity>
    {
        public SaveCommodityCommand(
            string title,
            decimal price,
            Guid defaultMeasureId,
            string? description = null)
        {
            Title = title;
            Price = price;
            DefaultMeasureId = defaultMeasureId;
            Description = description;
        }
        public string Title { get; }
        public decimal Price { get; }
        public string? Description { get; }
        public Guid DefaultMeasureId { get; }
    }
}
