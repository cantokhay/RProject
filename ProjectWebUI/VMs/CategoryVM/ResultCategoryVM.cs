using Project.Data.Enums;

namespace ProjectWebUI.VMs.CategoryVM
{
    public class ResultCategoryVM
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public DataStatus DataStatus { get; set; }
    }
}
