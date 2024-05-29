using System.ComponentModel.DataAnnotations;

namespace ProjectWebUI.VMs.IdentityVM
{
    public class AppUserEditVM
    {
        [Required(ErrorMessage = "E-posta alanı zorunludur")]
        [EmailAddress(ErrorMessage = "Geçersiz E-posta adresi")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "İsim alanı zorunludur")]
        [StringLength(50, ErrorMessage = "İsim en fazla 50 karakter uzunluğunda olmalıdır")]
        [Display(Name = "First Namme")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Soyisim alanı zorunludur")]
        [StringLength(50, ErrorMessage = "Soyisim en fazla 50 karakter uzunluğunda olmalıdır")]
        [Display(Name = "Last Namme")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Şifre alanı zorunludur")]
        [MinLength(6, ErrorMessage = "Şifre en az 6 karakter uzunluğunda olmalıdır")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{6,}$", ErrorMessage = "Şifre en az 6 karakter uzunluğunda olmalıdır ve en az bir büyük harf, bir küçük harf, bir sayı ve bir özel karakter içermelidir")]
        [Display(Name = "Password")]
        public string Password { get; set; }


        [Required(ErrorMessage = "Şifre tekrarı alanı zorunludur")]
        [Compare("Password", ErrorMessage = "Şifre ve şifre tekrarı aynı olmalıdır")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Kullanıcı Adı alanı zorunludur")]
        [StringLength(50, ErrorMessage = "Kullanıcı Adı en fazla 50 karakter uzunluğunda olmalıdır")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
    }
}
