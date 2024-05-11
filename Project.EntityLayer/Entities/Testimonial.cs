namespace Project.Data.Entities
{
    public class Testimonial
    {
        public int TestimonialId { get; set; }
        public string Comment { get; set; }
        public string TestimonialName { get; set; }
        public string TestimonialTitle { get; set; }
        public string TestimonialImageURL { get; set; }
        public bool TestimonialStatus { get; set; }
    }
}
