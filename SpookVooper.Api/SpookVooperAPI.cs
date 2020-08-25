using Newtonsoft.Json;
using SpookVooper.Api.Entities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SpookVooper.Api
{
    /// <summary>
    /// This is the "main" class for the API, allowing for a lot of general and useful operations
    /// </summary>
    public static class SpookVooperAPI
    {
        public static HttpClient client = new HttpClient();

        public static async Task<string> GetData(string url)
        {
            var httpResponse = await client.GetAsync(url);

            return await httpResponse.Content.ReadAsStringAsync();
        }

        /// <summary>
        /// All API functions relating to Users
        /// </summary>
        public static class UserAPI
        {
            public static async Task<User> GetUser(string svid)
            {
                string result = await GetData($"https://api.spookvooper.com/user/GetUser?svid={svid}");

                User user = (User)JsonConvert.DeserializeObject(result);

                return user;
            }

            public static async Task<string> GetUsername(string svid)
            {
                return await GetData($"https://api.spookvooper.com/user/GetUsername?svid={svid}");
            }

            public static async Task<string> GetSVIDFromUsername(string username)
            {
                return await GetData($"https://api.spookvooper.com/user/GetSVIDFromUsername?username={username}");
            }

            public static async Task<string> GetSVIDFromDiscord(int discordid)
            {
                return await GetData($"https://api.spookvooper.com/user/GetSVIDFromDiscord?discordid={discordid}");

            }

            public static async Task<string> GetUsernameFromDiscord(int discordid)
            {
                return await GetData($"https://api.spookvooper.com/user/GetUsernameFromDiscord?discordid={discordid}");

            }

            public static async Task<string> GetUsernameFromMinecraft(string minecraftid)
            {
                return await GetData($"https://api.spookvooper.com/user/GetUsernameFromMinecraft?minecraftid={minecraftid}");

            }

            public static async Task<string> GetSVIDFromMinecraft(string minecraftid)
            {
                return await GetData($"https://api.spookvooper.com/user/GetSVIDFromMinecraft?minecraftid={minecraftid}");

            }

            public static async Task<string> HasDiscordRole(string svid, string role)
            {
                return await GetData($"https://api.spookvooper.com/user/HasDiscordRole?svid={svid}&role={role}");

            }

            public class DiscordRoleInfo
            {
                [JsonProperty]
                public string Name { get; set; }

                [JsonProperty]
                public ulong Id { get; set; }
            }

            public static async Task<List<DiscordRoleInfo>> GetDiscordRoles(string svid)
            {
                string response = await GetData($"https://api.spookvooper.com/user/GetDiscordRoles?svid={svid}");

                return JsonConvert.DeserializeObject<List<DiscordRoleInfo>>(response);
            }

            public static async Task<int> GetDaysSinceLastMove(string svid)
            {
                string response = await GetData($"https://api.spookvooper.com/user/GetDaysSinceLastMove?svid={svid}");

                int result = int.MaxValue;

                int.TryParse(response, out result);

                return result;
            }

        }

        public static class GroupAPI
        {

        }
    }
}
