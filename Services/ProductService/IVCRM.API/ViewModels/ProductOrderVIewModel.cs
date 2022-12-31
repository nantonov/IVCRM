﻿namespace IVCRM.API.ViewModels
{
    public class ProductOrderViewModel
    {
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public float Quantity { get; set; }
        public decimal Price { get; set; }

        public ProductViewModel? Product { get; set; }
    }
}
