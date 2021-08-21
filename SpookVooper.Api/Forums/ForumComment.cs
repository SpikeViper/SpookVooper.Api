using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Linq;

namespace SpookVooper.Api.Forums
{
    public class ForumComment
    {
        // ID of this comment
        [Key]
        public ulong CommentID { get; }

        // Post this was posted on
        public ulong PostOnID { get; }

        // Comment this was commented on
        public ulong? CommentOnID { get; }

        // Content of the comment
        public string Content { get; }

        // User who posted this comment
        public string UserID { get; }

        // Time posted
        public DateTime TimePosted { get; }

        public bool Removed { get; }

    }
}
