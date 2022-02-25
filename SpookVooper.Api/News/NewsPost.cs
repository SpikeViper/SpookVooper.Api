using System;
using System.ComponentModel.DataAnnotations;

namespace SpookVooper.Api.News
{
    public class NewsPost
    {
        [Key]
        public string PostID { get; }

        public ulong DiscussionID { get; }

        [MaxLength(128, ErrorMessage = "Name should be under 128 characters.")]
        [Required]
        public string Title { get; }

        [MaxLength(10000, ErrorMessage = "Content should be under 10,000 characters.")]
        [Required]
        public string Content { get; }

        public string AuthorID { get; }

        public string GroupID { get; }

        [DataType(DataType.ImageUrl, ErrorMessage = "Please enter a valid image URL")]
        [Display(Name = "Main Image URL")]
        [Required]
        public string ImageURL { get; }

        public DateTime Timestamp { get; }

        [Display(Name = "Tags")]
        [Required]
        [MaxLength(50, ErrorMessage = "Tags should be under 50 characters.")]
        [RegularExpression("^[a-zA-Z0-9, ]*$", ErrorMessage = "Please use only letters, numbers, and commas.")]
        public string Tags { get; }
    }
}
