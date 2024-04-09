using BarManagment.Domain.DomainEntities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarManagment.Domain.DomainEntities
{
    public sealed class Role : BaseEntity
    {
        private Role(Guid id, string title) : base(id)
        {
            Title = title;
        }
        private Role() { }

        public string Title { get; private set; }
    }
}
