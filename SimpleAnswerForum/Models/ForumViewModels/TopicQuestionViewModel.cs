using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleAnswerForum.Models.ForumViewModels
{
    public class TopicQuestionViewModel
    {
        public long Id { get; set; }
        public long TopicId { get; set; }
        public TopicViewModel Topic { get; set; }
    }
}
