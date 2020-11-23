using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SpookVooper.Api.Entities.Groups
{
    public class Group : ITradeable, Entity
    {
        // Id of group
        [Key]
        [Required]
        [Display(Name = "Group ID")]
        public string Id { get; set; }

        // Name of group
        [Required]
        [MaxLength(64, ErrorMessage = "Name should be under 64 characters.")]
        [RegularExpression("^[a-zA-Z0-9, ]*$", ErrorMessage = "Please use only letters, numbers, and commas.")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        // Group page description
        [Required]
        [Display(Name = "Group Description")]
        [MaxLength(3000, ErrorMessage = "Description should be under 3000 characters.")]
        public string Description { get; set; }

        // If the group is open to the public
        [Display(Name = "Open")]
        public bool Open { get; set; }

        [Display(Name = "Credits")]
        public decimal Credits { get; set; }

        // URL for group image
        [Display(Name = "Group Icon URL")]
        [RegularExpression(@"(^(.*)(\.jpg|\.jpeg|\.png|\.gif|\.PNG|\.JPG|\.JPEG))$", ErrorMessage = "Link should end in an image file [.png, .jpg, .jpeg, .gif, etc.]")]
        public string Image_Url { get; set; }

        // The type of group this is
        [Required]
        [Display(Name = "Group Category")]
        public string Group_Category { get; set; }

        // The owner of this group
        [Display(Name = "Owner ID")]
        public string Owner_Id { get; set; }

        // The district containing this group
        [Display(Name = "District")]
        public string District_Id { get; set; }

        [Display(Name = "Default Role IDs")]
        public string Default_Role_Id { get; set; }

        [Display(Name = "API Key")]
        public string Api_Key { get; set; }

        public decimal Credits_Invested { get; set; }

        public int Amount { get { return 1; } }


        public class GroupTypes
        {
            public const string None = "Groups", Political = "Parties", Company = "Companies", News = "News";
        }

        public bool IsOwner(User user)
        {
            return user.Id == Owner_Id;
        }
    }
}
