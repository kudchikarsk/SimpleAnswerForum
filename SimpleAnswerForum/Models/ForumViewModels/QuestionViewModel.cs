using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleAnswerForum.Models.ForumViewModels
{
    public class QuestionViewModel
    {
        public long Id { get; set; }
        [MaxLength(256)]
        public string Content { get; set; }

        public string ApplicationUserId { get; set; }
        public virtual ApplicationUserViewModel ApplicationUser { get; set; }

        public virtual ICollection<AnswerViewModel> Answers { get; set; } 
        public virtual ICollection<TopicQuestionViewModel> TopicQuestions { get; set; }

        public long UpvotesCount { get; set; }
        public long DownvotesCount { get; set; }

    }
}