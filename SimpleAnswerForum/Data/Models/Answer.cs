using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleAnswerForum.Data.Models
{
    public class Answer
    {
        public Answer()
        {

        }

        public Answer(string content, string applicationUserId)
        {
            Content = content;
            ApplicationUserId = applicationUserId;
            CreatedAt = DateTime.Now;
            ModifiedAt = DateTime.Now;
        }

        public long Id { get; set; }
        [MaxLength(256)]
        public string Content { get; set; }

        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public long QuestionId { get; set; }
        public virtual Question Question { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        public virtual ICollection<UpvoteAnswer> UpvoteAnswers { get; set; }
        public virtual ICollection<DownvoteAnswer> DownvoteAnswers { get; set; }

        public void Update(string content, string applicationUserId)
        {
            Content = content;
            ApplicationUserId = applicationUserId;
            ModifiedAt = DateTime.Now;
        }
    }
}