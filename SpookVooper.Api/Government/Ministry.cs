using System.ComponentModel.DataAnnotations;

namespace SpookVooper.Api.Government
{
    public class Ministry
    {
        [Key]
        public string Name { get; }
        public string Description { get; }
    }
}
