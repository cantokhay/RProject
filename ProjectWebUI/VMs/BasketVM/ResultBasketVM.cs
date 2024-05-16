﻿namespace ProjectWebUI.VMs.BasketVM
{
    public class ResultBasketVM
    {
        public int BasketId { get; set; }
        public decimal Price { get; set; }
        public decimal Count { get; set; }
        public decimal TotalProductPrice { get; set; }

        public int ProductId { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductName { get; set; }

        public string CustomerName { get; set; }
        public int CustomerId { get; set; }
    }
}
