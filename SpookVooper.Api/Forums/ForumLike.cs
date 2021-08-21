using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SpookVooper.Api.Forums
{
    public class ForumLike
    {
        [Key]
        public string LikeID { get; }
        public string AddedBy { get; }
        public string GivenTo { get; }
        public ulong Post { get; }
    }
}
