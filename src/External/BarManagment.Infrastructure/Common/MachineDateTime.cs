using BarManagment.Application.Core.Abstractions.Common;

namespace BarManagment.Infrastructure.Common
{
    internal sealed class MachineDateTime : IDateTime
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
