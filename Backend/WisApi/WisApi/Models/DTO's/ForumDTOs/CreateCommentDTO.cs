namespace WisApi.Models.DTO_s.ForumDTOs
{
    public class CreateCommentDTO
    {
        public string? UserName { get; set; }

        public string Comment {  get; set; }

        public DateTime CreatedAt { get; set; }

        public bool IsAnonymous { get; set; }

        public int PostId { get; set; }
    }
}
