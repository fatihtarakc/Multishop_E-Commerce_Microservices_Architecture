﻿namespace Multishop.Basket.Dtos.BasketDtos
{
    public class BasketItemDto
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductAmount { get; set; }
        public decimal ProductPrice { get; set; }
    }
}