using System.ComponentModel.DataAnnotations;

namespace SpookVooper.Api.Government
{
    public class Minister
    {
        [Key]
        public string Ministry { get; set; }
        public string UserId { get; set; }
    }
}
