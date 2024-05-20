namespace WisApi.Models.DTO_s.ForumDTOs
{
    public class CreateTopicDTO
    {
        public string? UserName { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool IsAnonymous { get; set; }
    }
}
