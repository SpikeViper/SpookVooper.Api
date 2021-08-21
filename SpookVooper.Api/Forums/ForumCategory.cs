using System.ComponentModel.DataAnnotations;

namespace SpookVooper.Api.Forums
{
    public class ForumCategory
    {
        // Name of the blog category
        [Key]
        public string CategoryID { get; }

        public string Description { get; }

        public string Tags { get; }

        public string Parent { get; }

        // Roles that are allowed to post, if empty there are no limits
        public string RoleAccess { get; }
    }
}
