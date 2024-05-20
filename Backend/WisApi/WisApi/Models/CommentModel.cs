
namespace WisApi.Models
{
    public class CommentModel
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string Comment {  get; set; }

        public string? UserName { get; set; } = "Anonymous";

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string IpAdress {  get; set; }

        public bool IsAnonymous { get; set; } = false;

        public int PostId { get; set; }

        public PostModel Post { get; set; }

    }
}
