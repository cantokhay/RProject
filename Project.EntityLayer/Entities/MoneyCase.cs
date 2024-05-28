using Project.Data.Entities.Abstract;
using Project.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace Project.Data.Entities
{
	public class MoneyCase : IGenericEntity
	{
        public int MoneyCaseId { get; set; }

		[Required(ErrorMessage = "Kasadaki Para alanı zorunludur")]
		[RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Virgülden sonra en fazla 2 basamak olmalıdır")]
		[Display(Name = "Total Money In Case")]
		public decimal TotalMoneyInCase { get; set; }

		public DateTime CreatedDate { get; set; }
		public DateTime? ModifiedDate { get; set; }
		public DateTime? DeletedDate { get; set; }
		public DataStatus DataStatus { get; set; }
	}
}
