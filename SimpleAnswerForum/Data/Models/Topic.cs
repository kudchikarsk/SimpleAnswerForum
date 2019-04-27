using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleAnswerForum.Data.Models
{
    public class Topic
    {
        public long Id { get; set; }
        [MaxLength(256)]
        public string Name { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<TopicQuestion> TopicQuestions { get; set; }
    }
}