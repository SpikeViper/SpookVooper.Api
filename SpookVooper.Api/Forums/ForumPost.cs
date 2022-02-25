using System;
using System.ComponentModel.DataAnnotations;

namespace SpookVooper.Api.Forums
{
    public class ForumPost
    {
        // The ID of this post
        [Key]
        public ulong PostID { get; }

        // The author of the post
        public string Author { get; }

        // Category this blog was posted in
        public string Category { get; }

        // Title of this post
        public string Title { get; }

        // Content of this post
        public string Content { get; }

        // Tags of this post
        public string Tags { get; }

        public bool Removed { get; }

        // Pic post
        public bool Picture { get; }

        // Time this blog was posted
        public DateTime TimePosted { get; }
    }
}
