namespace WisApi.Models.DTO_s.ForumDTOs
{
    public class CommentDTO
    {
        public string? UserName { get; set; }

        public string Comment { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public bool IsAnonymous { get; set; }

        public int PostId { get; set; }
    }
}
