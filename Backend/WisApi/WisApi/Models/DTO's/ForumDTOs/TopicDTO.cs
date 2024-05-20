namespace WisApi.Models.DTO_s.ForumDTOs
{
    public class TopicDTO
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string? UserName { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
