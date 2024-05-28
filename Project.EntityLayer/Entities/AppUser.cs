using Microsoft.AspNetCore.Identity;
using Project.Data.Entities.Abstract;
using Project.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace Project.Data.Entities
{
    public class AppUser : IdentityUser<int> , IGenericEntity
    {
		[Required(ErrorMessage = "İsim alanı zorunludur")]
		[StringLength(50, ErrorMessage = "İsim en fazla 50 karakter uzunluğunda olmalıdır")]
		[Display(Name = "First Namme")]
		public string FirstName { get; set; }

		[Required(ErrorMessage = "Soyisim alanı zorunludur")]
		[StringLength(50, ErrorMessage = "Soyisim en fazla 50 karakter uzunluğunda olmalıdır")]
		[Display(Name = "Last Namme")]
		public string LastName { get; set; }

		public DateTime CreatedDate { get; set; }
		public DateTime? ModifiedDate { get; set; }
		public DateTime? DeletedDate { get; set; }
		public DataStatus DataStatus { get; set; }
	}
}
