
namespace WisApi.Models
{
    public class PostModel
    {
        
        public int Id { get; set; }
        
        public string Title { get; set; }

        public string? SubTitle { get; set; }
        
        public string Text { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string UserId { get; set; }

        public string? UserName { get; set; }

        public string IpAdress { get; set; }

        public int TopicId { get; set; }

        public TopicModel Topic { get; set; } = null!;

        public ICollection<CommentModel> Comments { get; } = new List<CommentModel>();



    }
}
