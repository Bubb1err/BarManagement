﻿using BarManagment.Application.Core.Abstractions.Data;
using BarManagment.Domain.Abstractions.Repository;
using BarManagment.Domain.DomainEntities;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BarManagment.Persistance.Repositories
{
    public class ReceiptRepository : BaseRepository<Receipt>, IReceiptRepository
    {
        public ReceiptRepository(BarDbContext context) : base(context)
        {
        }

        public List<Guid> GetCoctailsRating()
        {
            var query = from receipt in _dbSet
                        from cocktail in receipt.Coctails
                        group cocktail by cocktail.Id into g
                        orderby g.Count() descending
                        select g.Key;

            var result = query.ToList();
            return result;
        }

        
    }
}