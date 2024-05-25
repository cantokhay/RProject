namespace Project.DTO.TestimonialDTO
{
    public class UpdateTestimonialDTO
    {
        public int TestimonialId { get; set; }
        public string Comment { get; set; }
        public string TestimonialName { get; set; }
        public string TestimonialTitle { get; set; }
        public string TestimonialImageURL { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool TestimonialStatus { get; set; }
	}
}
