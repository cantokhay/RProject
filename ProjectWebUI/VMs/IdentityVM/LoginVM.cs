using System.ComponentModel.DataAnnotations;

namespace ProjectWebUI.VMs.IdentityVM
{
	public class LoginVM
	{
		[Required(ErrorMessage = "Şifre alanı zorunludur")]
		[MinLength(6, ErrorMessage = "Şifre en az 6 karakter uzunluğunda olmalıdır")]
		[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{6,}$", ErrorMessage = "Şifre en az 6 karakter uzunluğunda olmalıdır ve en az bir büyük harf, bir küçük harf, bir sayı ve bir özel karakter içermelidir")]
		[Display(Name = "Password")]
		public string Password { get; set; }

		[Required(ErrorMessage = "Kullanıcı Adı alanı zorunludur")]
		[StringLength(50, ErrorMessage = "Kullanıcı Adı en fazla 50 karakter uzunluğunda olmalıdır")]
		[Display(Name = "User Name")]
		public string UserName { get; set; }
	}
}
