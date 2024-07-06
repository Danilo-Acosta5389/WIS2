
namespace WisApi.Models
{
    public class PostModel
    {
        public PostModel() { }

        public PostModel(string title, string subTitle, string text, DateTime createdAt, string userName, string userId, string ipAdress, bool isAnonymous, bool isInvisible, int topicId)
        {
            Title = title;
            SubTitle = subTitle;
            Text = text;
            CreatedAt = createdAt;
            UserName = userName;
            UserId = userId;
            IpAdress = ipAdress;
            IsAnonymous = isAnonymous;
            IsInvisible = isInvisible;
            TopicId = topicId;
        }

        public int Id { get; set; }
        
        public string Title { get; set; }

        public string? SubTitle { get; set; }
        
        public string Text { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string UserId { get; set; }

        public string? UserName { get; set; } = "Anonymous";

        public string IpAdress { get; set; }

        public bool IsAnonymous { get; set; } = false;

        public bool IsInvisible { get; set; }

        public int TopicId { get; set; }

        public TopicModel Topic { get; set; } = null!;

        public ICollection<CommentModel> Comments { get; } = new List<CommentModel>();



    }
}
