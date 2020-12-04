using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace SpookVooper.Api.Government
{
    public class District
    {
        [Key]
        public string Name { get; set; }

        [Display(Name = "Flag Image URL")]
        public string Flag_Url { get; set; }
        public string Description { get; set; }
        public string Senator { get; set; }
        public string Group_Id { get; set; }
    }
}
