using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SpookVooper.Api.Forums
{
    class PostViewModel
    {
        public ulong PostID { get; set; }

        // The author of the post
        public string Author { get; set; }

        // Category this blog was posted in
        public string Category { get; set; }

        // Title of this post
        [Display(Name = "Post Title")]
        [Required]
        [MaxLength(32, ErrorMessage = "Name should be under 32 characters.")]
        public string Title { get; set; }

        // Content of this post
        [Display(Name = "Post Content")]
        [Required]
        [MaxLength(3000, ErrorMessage = "Content should be under 3000 characters.")]
        public string Content { get; set; }

        // Likes on this post
        public int Likes { get; set; }

        // Time this blog was posted
        public DateTime TimePosted { get; set; }
    }
}
