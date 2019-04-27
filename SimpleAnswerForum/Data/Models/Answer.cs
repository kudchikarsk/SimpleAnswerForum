using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleAnswerForum.Data.Models
{
    public class Answer
    {
        public long Id { get; set; }
        [MaxLength(256)]
        public string Content { get; set; }

        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public long QuestionId { get; set; }
        public virtual Question Question { get; set; }

        public virtual ICollection<UpvoteAnswer> UpvoteAnswers { get; set; }
        public virtual ICollection<DownvoteAnswer> DownvoteAnswers { get; set; }

    }
}