using System.ComponentModel.DataAnnotations;

namespace Project.DTO.BasketDTO
{
    public class CreateBasketDTO
    {
		[Required(ErrorMessage = "Miktar alanı zorunludur")]
		[RegularExpression(@"^\d+$", ErrorMessage = "Geçersiz miktar formatı")]
		[Display(Name = "Count")]
		public int Count { get; set; }
		public int ProductId { get; set; }
		public int CustomerId { get; set; }
    }
}
