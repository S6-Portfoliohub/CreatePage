namespace CreatePage.Models
{
    public class ProjectViewModel
    {
        public string? UserID { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public string? Img { get; set; }
    }
}
