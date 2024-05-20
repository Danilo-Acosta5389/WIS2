namespace WisApi.Models.DTO_s.ForumDTOs
{
    public class CreatePostDTO
    {
        public string Title { get; set; }

        public string? SubTitle { get; set; }

        public string Text { get; set; }

        public DateTime CreatedAt { get; set; }

        public string? UserName { get; set; }

        public int TopicId { get; set; }

        public bool IsAnonymous { get; set; }
    }
}
