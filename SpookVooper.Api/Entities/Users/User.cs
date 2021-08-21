using System.Threading.Tasks;
using static SpookVooper.Api.SpookVooperAPI;

namespace SpookVooper.Api.Entities
{
    public class User : Entity
    {
        /// <summary>
        /// Creates a user object using the SVID and optional key for priviliged actions
        /// </summary>
        public User(string svid, string auth_key = null) : base(svid, auth_key)
        {
            if (!svid.StartsWith("u-"))
            {
                throw new VooperException("Svid should start with a u- for a user object!");
            }

            Id = svid;
            Auth_Key = auth_key;
        }

        public void SetAuthKey(string auth)
        {
            Auth_Key = auth;
        }

        /// <summary>
        /// Returns all available data about this user at the moment the snapshot is called (async)
        /// </summary>
        public async Task<UserSnapshot> GetSnapshotAsync()
        {
            UserSnapshot snapshot;
            try
            {
                snapshot = await GetDataFromJson<UserSnapshot>($"user/GetUser?svid={Id}");

            }
            catch (VooperException)
            {
                throw new VooperException($"Malformed response for GetUser");
            }

            return snapshot;
        }

        public async Task<string> GetUsernameAsync()
        {
            return await GetData($"user/GetUsername?svid={Id}");
        }

        public async Task<int> GetDaysSinceLastMoveAsync()
        {
            string response = await GetData($"user/GetDaysSinceLastMove?svid={Id}");

            if (int.TryParse(response, out int result)) return result;

            throw new VooperException($"Malformed response for GetDaysSinceLastMove: {response}");
        }

        // Static methods

        public static async Task<string> GetSVIDFromUsernameAsync(string username)
        {
            string svid = await GetData($"user/GetSVIDFromUsername?username={username}");

            if (svid.StartsWith("u-")) return svid;

            throw new VooperException($"Malformed response for GetSVIDFromName: {svid}");
        }

        public static async Task<string> GetSVIDFromDiscordAsync(ulong discordid)
        {
            string svid = await GetData($"user/GetSVIDFromDiscord?discordid={discordid}");

            if (svid.StartsWith("u-")) return svid;

            throw new VooperException($"Malformed response for GetSVIDFromName: {svid}");
        }

        public static async Task<string> GetUsernameFromDiscordAsync(ulong discordid)
        {
            return await GetData($"user/GetUsernameFromDiscord?discordid={discordid}");
        }

        public static async Task<string> GetUsernameFromMinecraftAsync(string minecraftid)
        {
            return await GetData($"user/GetUsernameFromMinecraft?minecraftid={minecraftid}");
        }

        public static async Task<string> GetSVIDFromMinecraftAsync(string minecraftid)
        {
            return await GetData($"user/GetSVIDFromMinecraft?minecraftid={minecraftid}");
        }
    }
}
