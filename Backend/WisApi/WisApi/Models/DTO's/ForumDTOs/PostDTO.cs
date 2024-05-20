namespace WisApi.Models.DTO_s.ForumDTOs
{
    public class PostDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string? SubTitle { get; set; }

        public string Text { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string? UserName { get; set; }
    }
}
