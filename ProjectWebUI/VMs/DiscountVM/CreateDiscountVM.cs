﻿namespace ProjectWebUI.VMs.DiscountVM
{
    public class CreateDiscountVM
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal DiscountAmount { get; set; }
        public string ImageURL { get; set; }
		public bool DiscountStatus { get; set; }

	}
}
