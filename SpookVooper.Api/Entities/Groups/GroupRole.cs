using System.ComponentModel.DataAnnotations;

namespace SpookVooper.Api.Entities.Groups
{

    public class GroupRole
    {
        public static GroupRole Default = new()
        {
            Color = "",
            GroupId = "NONE",
            RoleId = "DEFAULT",
            Name = "Default Role",
            Weight = int.MinValue,
            Permissions = "post|"
        };

        // The name of the role
        [MaxLength(64, ErrorMessage = "Name should be under 64 characters.")]
        [RegularExpression("^[a-zA-Z0-9, ]*$", ErrorMessage = "Please use only letters, numbers, and commas.")]
        public string Name { get; private set; }

        // The ID of the role
        [Key]
        public string RoleId { get; private set; }

        // Things this role is allowed to do
        public string Permissions { get; private set; }

        // Hexcode for role color
        [MaxLength(6, ErrorMessage = "Color should be a hex code (ex: #ffffff)")]
        public string Color { get; private set; }

        // The group this role belongs to
        public string GroupId { get; private set; }

        // Salary for role
        public decimal Salary { get; private set; }

        // Weight of the role
        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Numbers only!")]
        public int Weight { get; private set; }
    }
}
