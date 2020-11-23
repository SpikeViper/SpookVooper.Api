using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpookVooper.Api
{
    /// <summary>
    /// This class allows for secure strings to not be within the source.
    /// This is pretty useless for anyone other than those working on SpookVooper.
    /// </summary>
    #region SECRET
    public class Secrets
    {
        public static Config config;

        public static string twitchClientID { get { return config.TwitchClient; } }
        public static string twitchSecret { get { return config.TwitchSecret; } }
        public static string twitchOAuth { get { return config.TwitchOAuth; } }
        public static string NC_Override { get { return config.NerdcraftOverride; } }

#if DEBUG
        public static string token { get { return config.VoopAITestToken; } }
#else
        public static string token { get { return config.VoopAIToken; } }
#endif

#if DEBUG
        public static string DBstring { get { return config.TestDBString; }}
#else
        public static string DBstring { get { return config.DBString; }}
#endif
        public static string NCDBString { get { return config.NerdcraftDBString; } }

    }

    public class Config
    {
        [JsonProperty]
        public string TwitchClient;
        [JsonProperty]
        public string TwitchSecret;
        [JsonProperty]
        public string TwitchOAuth;
        [JsonProperty]
        public string NerdcraftOverride;
        [JsonProperty]
        public string VoopAIToken;
        [JsonProperty]
        public string VoopAITestToken;
        [JsonProperty]
        public string DBString;
        [JsonProperty]
        public string TestDBString;
        [JsonProperty]
        public string NerdcraftDBString;
    }

    #endregion
}
