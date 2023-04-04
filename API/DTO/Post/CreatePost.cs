namespace ReactivitiesV1.DTO
{
    public class ModifyPost
    {

        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsPublished { get; set; } = false;
    }
}