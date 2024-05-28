using Project.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace Project.DTO.CategoryDTO
{
    public class ResultCategoryDTO
    {
        public int CategoryId { get; set; }

		[Required(ErrorMessage = "Kategori Adı alanı zorunludur")]
		[StringLength(100, ErrorMessage = "Kategori Adı en fazla 100 karakter uzunluğunda olmalıdır")]
		[Display(Name = "Name")]
		public string CategoryName { get; set; }
		public DataStatus DataStatus { get; set; }
    }
}
