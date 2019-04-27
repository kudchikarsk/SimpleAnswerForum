using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleAnswerForum.Data.Models
{
    public class Question
    {
        public long Id { get; set; }
        [MaxLength(256)]
        public string Content { get; set; }

        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual ICollection<Answer> Answers { get; set; } 
        public virtual ICollection<TopicQuestion> TopicQuestions { get; set; }
        public virtual ICollection<UpvoteQuestion> UpvoteQuestions { get; set; }
        public virtual ICollection<DownvoteQuestion> DownvoteQuestions { get; set; }

    }
}