using BarManagment.Domain.DomainEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarManagment.Application.Commoditys.Commands.UpdateCommodity
{
  public class UpdateCommodityCommand : IRequest<Commodity>
  {
    public UpdateCommodityCommand(
           Guid id,
           string title,
           decimal price,
           Guid defaultMeasureId,
           string? description = null)
    {
      Id = id;
      Title = title;
      Price = price;
      DefaultMeasureId = defaultMeasureId;
      Description = description;
    }
    public Guid Id { get; }
    public string Title { get; }
    public decimal Price { get; }
    public string? Description { get; }
    public Guid DefaultMeasureId { get; }
  }
}
