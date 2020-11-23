using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SpookVooper.Api.Oauth2
{
    public class OauthApp
    {
        [Key]
        public string Id { get; set; }
        public string Secret { get; set; }
        public string Owner { get; set; }
        public int Uses { get; set; }
        public string Name { get; set; }
        public string Image_Url { get; set; }
    }
}
