namespace YummyProject.API.Entities.Models
{
    public class Feature
    {
        public int FeatureId { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Description { get; set; }
        public string FeatureVideoUrl { get; set; }
        public string FeatureImageUrl { get; set; }
    }
}
