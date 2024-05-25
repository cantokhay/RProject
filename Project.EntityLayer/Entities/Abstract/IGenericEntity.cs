using Project.Data.Enums;

namespace Project.Data.Entities.Abstract
{
	public interface IGenericEntity
	{
		public DateTime CreatedDate { get; set; }
		public DateTime? ModifiedDate { get; set; }
		public DateTime? DeletedDate { get; set; }
		public DataStatus DataStatus { get; set; }
	}
}
