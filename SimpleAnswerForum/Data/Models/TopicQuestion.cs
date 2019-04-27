using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleAnswerForum.Data.Models
{
    public class TopicQuestion
    {
        public long TopicId { get; set; }
        public virtual Topic Topic { get; set; }

        public long QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
