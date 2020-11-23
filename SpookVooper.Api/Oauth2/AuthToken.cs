using System;
using System.Collections.Generic;
using System.Text;

namespace SpookVooper.Api.Oauth2
{
    public class AuthToken
    {
        /// <summary>
        /// The ID of the authentification key is also the secret key. Really no need for another random gen.
        /// (is sha256)
        /// </summary>
        public string Id { get; set; }
        public string AppId { get; set; }
        public string UserId { get; set; }
        public string Scope { get; set; }
        public DateTime Time { get; set; }
    }
}
