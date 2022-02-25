using System;

namespace SpookVooper.Api.Oauth2
{
    public class AuthToken
    {
        /// <summary>
        /// The ID of the authentification key is also the secret key. Really no need for another random gen.
        /// (is sha256)
        /// </summary>
        public string Id { get; }
        public string AppId { get; }
        public string UserId { get; }
        public string Scope { get; }
        public DateTime Time { get; }
    }
}
