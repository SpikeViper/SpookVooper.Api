using System.ComponentModel.DataAnnotations;

namespace SpookVooper.Api.Forums
{
    public class ForumCommentLike
    {
        [Key]
        public string LikeID { get; }

        // ID of the comment liked
        public ulong CommentID { get; }

        // ID of the user who posted this comment
        public string UserID { get; }

        public string GivenTo { get; }
    }
}
