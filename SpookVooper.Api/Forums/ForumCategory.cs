using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SpookVooper.Api.Forums
{
    public class ForumCategory
    {
        // Name of the blog category
        [Key]
        public string CategoryID { get; set; }

        public string Description { get; set; }

        public string Tags { get; set; }

        public string Parent { get; set; }

        // Roles that are allowed to post, if empty there are no limits
        public string RoleAccess { get; set; }
    }
}
