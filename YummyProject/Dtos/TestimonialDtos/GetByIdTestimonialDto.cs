namespace YummyProject.API.Dtos.TestimonialDtos
{
    public class GetByIdTestimonialDto
    {
        public int TestimonialId { get; set; }
        public string CustomerName { get; set; }
        public string Feedback { get; set; }
        public string CustomerImageUrl { get; set; }
        public string Designation { get; set; }
    }
}
