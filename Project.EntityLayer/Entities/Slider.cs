using Project.Data.Entities.Abstract;
using Project.Data.Enums;

namespace Project.Data.Entities
{
    public class Slider : IGenericEntity
    {
        public int SliderId { get; set; }
        public string SliderTitle1 { get; set; }
        public string SliderDescription1 { get; set; }
        public string SliderTitle2 { get; set; }
        public string SliderDescription2 { get; set; }
        public string SliderTitle3 { get; set; }
        public string SliderDescription3 { get; set; }

		public DateTime CreatedDate { get; set; }
		public DateTime? ModifiedDate { get; set; }
		public DateTime? DeletedDate { get; set; }
		public DataStatus DataStatus { get; set; } = DataStatus.Active;

	}
}