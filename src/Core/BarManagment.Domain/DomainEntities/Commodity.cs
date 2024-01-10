﻿using BarManagment.Domain.DomainEntities.Base;

namespace BarManagment.Domain.DomainEntities
{
    //vodka, konyak, juice...
    public sealed class Commodity : BaseEntity
    {
        private Commodity(
            Guid id, 
            string title,
            decimal price, 
            string? description, 
            DefaultMeasure defaultMeasure)
            :base (id)
        {
            Title = title;
            Price = price;
            Description = description;
            DefaultMeasureId = defaultMeasure.Id;
            DefaultMeasure = defaultMeasure;
        }
        private Commodity() { }
        public string Title { get; private set; }
        public decimal Price { get; private set; }
        public string? Description { get; private set; }
        public Guid DefaultMeasureId { get; private set; }
        public DefaultMeasure DefaultMeasure { get; private set; }
        public static Commodity Create(string title, decimal price, DefaultMeasure defaultMeasure, string? description)
        {
            return new Commodity(
                Guid.NewGuid(),
                title,
                price,
                description,
                defaultMeasure);
        }
        public static Commodity Update(Commodity commodity, string title, decimal price, DefaultMeasure defaultMeasure, string? description)
        {
            commodity.Title = title;
            commodity.Price = price;
            commodity.Description = description;
            commodity.DefaultMeasure = defaultMeasure;
            commodity.DefaultMeasureId = defaultMeasure.Id;
            return commodity;
        }
    }
}
