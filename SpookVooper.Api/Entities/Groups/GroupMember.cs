using System.ComponentModel.DataAnnotations;

namespace SpookVooper.Api.Entities.Groups
{
    public class GroupMember
    {
        [Key]
        public string Id { get; }
        public string User_Id { get; }
        public string Group_Id { get; }

    }
}
