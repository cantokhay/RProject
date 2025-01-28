using System.ComponentModel.DataAnnotations;

namespace ProjectWebUI.VMs.BasketVM
{
    public class CreateBasketVM
    {
		[Required(ErrorMessage = "Miktar alanı zorunludur")]
		[RegularExpression(@"^\d+$", ErrorMessage = "Geçersiz miktar formatı")]
		[Display(Name = "Count")]
		public int Count { get; set; }
		public int ProductId { get; set; }
        public int CustomerId { get; set; }
    }
}
