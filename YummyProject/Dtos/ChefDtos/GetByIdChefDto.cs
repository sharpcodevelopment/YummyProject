namespace YummyProject.API.Dtos.ChefDtos
{
    public class GetByIdChefDto
    {
        public int ChefId { get; set; }
        public string Name { get; set; }
        public string Specialty { get; set; }
        public string ImageUrl { get; set; }
        public string Bio { get; set; }
    }
}
