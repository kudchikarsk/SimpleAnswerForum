using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleAnswerForum.Models.ForumViewModels
{
    public class TopicViewModel
    {
        public long Id { get; set; }
        [MaxLength(256)]
        public string Name { get; set; }
    }
}