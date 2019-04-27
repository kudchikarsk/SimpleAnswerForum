using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleAnswerForum.Data.Models
{
    public class UpvoteQuestion
    {
        public long Id { get; set; }

        public long QuestionId { get; set; }
        public Question Question { get; set; }

        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
