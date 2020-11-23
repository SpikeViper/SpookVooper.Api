using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SpookVooper.Api.News
{
    public class NewsPost
    {
        [Key]
        public string PostID { get; set; }

        public ulong DiscussionID { get; set; }

        [MaxLength(128, ErrorMessage = "Name should be under 128 characters.")]
        [Required]
        public string Title { get; set; }

        [MaxLength(10000, ErrorMessage = "Content should be under 10,000 characters.")]
        [Required]
        public string Content { get; set; }

        public string AuthorID { get; set; }

        public string GroupID { get; set; }

        [DataType(DataType.ImageUrl, ErrorMessage = "Please enter a valid image URL")]
        [Display(Name = "Main Image URL")]
        [Required]
        public string ImageURL { get; set; }

        public DateTime Timestamp { get; set; }

        [Display(Name = "Tags")]
        [Required]
        [MaxLength(50, ErrorMessage = "Tags should be under 50 characters.")]
        [RegularExpression("^[a-zA-Z0-9, ]*$", ErrorMessage = "Please use only letters, numbers, and commas.")]
        public string Tags { get; set; }
    }
}
