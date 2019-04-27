using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleAnswerForum.Data.Models
{
    public class UpvoteAnswer
    {
        public long Id { get; set; }

        public long AnswerId { get; set; }
        public Answer Answer { get; set; }

        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
