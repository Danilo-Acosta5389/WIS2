
namespace WisApi.Models
{
    public class CommentModel
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string? UserName { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string IpAdress {  get; set; }

        public int PostId { get; set; }

        public PostModel Post { get; set; }

    }
}
