namespace YummyProject.API.Entities.Models
{
    public class Testimonial
    {
        public int TestimonialId { get; set; }
        public string CustomerName { get; set; }
        public string Feedback { get; set; }
        public string CustomerImageUrl { get; set; }
        public string Designation { get; set; }
    }
}
