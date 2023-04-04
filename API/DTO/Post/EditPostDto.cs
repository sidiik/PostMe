namespace ReactivitiesV1.DTO.Post
{
    public class EditPostDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime LastUpdatedAt { get; set; }
        public bool IsPublished { get; set; } = false;
    }
}