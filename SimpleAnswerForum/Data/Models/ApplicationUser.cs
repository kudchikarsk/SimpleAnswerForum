using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace SimpleAnswerForum.Data.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(32)]
        public string FirstName { get; set; }
        [MaxLength(32)]
        public string LastName { get; set; }
        [MaxLength(128)]
        public string Credentials { get; set; }
        [MaxLength(256)]
        public string Bio { get; set; }
        public string ProfilePictureFilename { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<UpvoteQuestion> UpvoteQuestions { get; set; }
        public virtual ICollection<DownvoteQuestion> DownvoteQuestions { get; set; }
        public virtual ICollection<UpvoteAnswer> UpvoteAnswers { get; set; }
        public virtual ICollection<DownvoteAnswer> DownvoteAnswers { get; set; }

    }
}
