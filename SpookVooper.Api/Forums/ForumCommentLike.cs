using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SpookVooper.Api.Forums
{
    public class ForumCommentLike
    {
        [Key]
        public string LikeID { get; set; }

        // ID of the comment liked
        public ulong CommentID { get; set; }

        // ID of the user who posted this comment
        public string UserID { get; set; }

        public string GivenTo { get; set; }
    }
}
