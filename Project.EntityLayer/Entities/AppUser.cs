using Microsoft.AspNetCore.Identity;
using Project.Data.Entities.Abstract;
using Project.Data.Enums;

namespace Project.Data.Entities
{
    public class AppUser : IdentityUser<int> , IGenericEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

		public DateTime CreatedDate { get; set; }
		public DateTime? ModifiedDate { get; set; }
		public DateTime? DeletedDate { get; set; }
		public DataStatus DataStatus { get; set; } = DataStatus.Active;
	}
}
