﻿using BarManagement.UI.Models.Commodity;

namespace BarManagement.UI.Models.CoctailIngredients
{
    public class CoctailIngredientViewModel
    {
        public Guid Id { get; set; }

        public Guid CoctailId { get; set; }

        public Guid CommodityId { get; set; }

        public CommodityViewModel Commodity { get; set; }

        public double AmountInDefaultMeasure { get; set; }
    }
}
