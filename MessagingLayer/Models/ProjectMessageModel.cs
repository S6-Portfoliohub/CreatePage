namespace MessagingLayer.Models
{
    public class ProjectMessageModel
    {
        public string? UserID { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public string? Img { get; set; }
    }
}
