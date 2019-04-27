using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleAnswerForum.Models.ForumViewModels
{
    public class ApplicationUserViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        [MaxLength(32)]
        [Required]
        public string FirstName { get; set; }
        [MaxLength(32)]
        [Required]
        public string LastName { get; set; }
        [MaxLength(128)]
        public string Credentials { get; set; }
        [MaxLength(256)]
        public string Bio { get; set; }
        public string ProfilePictureFilename { get; set; }
    }
}
