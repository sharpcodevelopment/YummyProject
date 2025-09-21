namespace YummyProject.API.Dtos.ServiceDtos
{
    public class GetByIdServiceDto
    {
        public int ServiceId { get; set; }
        public string ServiceTitle { get; set; }
        public string Description { get; set; }
        public string IconUrl { get; set; }
    }
}
