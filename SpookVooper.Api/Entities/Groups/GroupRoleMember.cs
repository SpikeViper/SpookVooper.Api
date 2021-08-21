using System.ComponentModel.DataAnnotations;

namespace SpookVooper.Api.Entities.Groups
{
    public class GroupRoleMember
    {
        [Key]
        public string Id { get; }
        public string Role_Id { get; }
        public string User_Id { get; }
        public string Group_Id { get; }

    }
}
