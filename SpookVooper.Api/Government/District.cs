using System.ComponentModel.DataAnnotations;

namespace SpookVooper.Api.Government
{
    public class District
    {
        [Key]
        public string Name { get; }

        [Display(Name = "Flag Image URL")]
        public string Flag_Url { get; }
        public string Description { get; }
        public string Senator { get; }
        public string Group_Id { get; }
    }
}
