using System.ComponentModel.DataAnnotations;

namespace SpookVooper.Api.Government
{
    public class Minister
    {
        [Key]
        public string Ministry { get; }
        public string UserId { get; }
    }
}
