using Project.Data.Enums;

namespace ProjectWebUI.VMs.CategoryVM
{
    public class UpdateCategoryVM
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DataStatus DataStatus { get; set; }
    }
}
