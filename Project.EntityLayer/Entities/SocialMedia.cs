using Project.Data.Entities.Abstract;
using Project.Data.Enums;

namespace Project.Data.Entities
{
    public class SocialMedia : IGenericEntity
    {
        public int SocialMediaId { get; set; }
        public string SocialMediaTitle { get; set; }
        public string SocialMediaURL { get; set; }
        public string SocialMediaIcon { get; set; }

		public DateTime CreatedDate { get; set; }
		public DateTime? ModifiedDate { get; set; }
		public DateTime? DeletedDate { get; set; }
		public DataStatus DataStatus { get; set; } = DataStatus.Active;
	}
}
