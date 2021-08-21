using System;
using System.ComponentModel.DataAnnotations;

namespace SpookVooper.Api.Forums
{
    class PostViewModel
    {
        public ulong PostID { get; }

        // The author of the post
        public string Author { get; }

        // Category this blog was posted in
        public string Category { get; }

        // Title of this post
        [Display(Name = "Post Title")]
        [Required]
        [MaxLength(32, ErrorMessage = "Name should be under 32 characters.")]
        public string Title { get; }

        // Content of this post
        [Display(Name = "Post Content")]
        [Required]
        [MaxLength(3000, ErrorMessage = "Content should be under 3000 characters.")]
        public string Content { get; }

        // Likes on this post
        public int Likes { get; }

        // Time this blog was posted
        public DateTime TimePosted { get; }
    }
}
