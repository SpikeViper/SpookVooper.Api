using System.ComponentModel.DataAnnotations;

namespace SpookVooper.Api.Oauth2
{
    public class OauthApp
    {
        [Key]
        public string Id { get; }
        public string Secret { get; }
        public string Owner { get; }
        public int Uses { get; }
        public string Name { get; }
        public string Image_Url { get; }
    }
}
