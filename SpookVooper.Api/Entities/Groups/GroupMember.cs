using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace SpookVooper.Api.Entities.Groups
{
    public class GroupMember
    {
        [Key]
        public string Id { get; set; }
        public string User_Id { get; set; }
        public string Group_Id { get; set; }

    }
}
