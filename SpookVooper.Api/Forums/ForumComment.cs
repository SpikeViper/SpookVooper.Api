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
        public ulong CommentID { get; set; }

        // Post this was posted on
        public ulong PostOnID { get; set; }

        // Comment this was commented on
        public ulong? CommentOnID { get; set; }

        // Content of the comment
        public string Content { get; set; }

        // User who posted this comment
        public string UserID { get; set; }

        // Time posted
        public DateTime TimePosted { get; set; }

        public bool Removed { get; set; }

    }
}
