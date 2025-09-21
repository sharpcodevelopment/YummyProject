namespace YummyProject.API.Dtos.FeatureDtos
{
    public class CreateFeatureDto
    {
        
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Description { get; set; }
        public string FeatureVideoUrl { get; set; }
        public string FeatureImageUrl { get; set; }
    }
}
