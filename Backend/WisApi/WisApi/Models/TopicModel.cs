﻿namespace WisApi.Models
{
    
    public class TopicModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string UserId { get; set; }

        public string? UserName { get; set; } = "Anonymous";

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string IpAdress {  get; set; }

        public bool IsAnonymous { get; set; } = false;

        public bool IsInvisible { get; set; }

        public ICollection<PostModel> Posts { get; } = new List<PostModel>();


    }
}
