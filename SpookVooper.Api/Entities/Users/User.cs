using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;

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
        public UserSnapshot GetSnapshot()
        {
            return GetSnapshotAsync().Result;
        }

        /// <summary>
        /// Returns all available data about this user at the moment the snapshot is called (async)
        /// </summary>
        public async Task<UserSnapshot> GetSnapshotAsync()
        {
            string json = await SpookVooperAPI.GetData($"https://api.spookvooper.com/user/GetUser?svid={Id}");

            UserSnapshot snapshot = null;

            try { 
                snapshot = JsonConvert.DeserializeObject<UserSnapshot>(json);
            }
#pragma warning disable 0168
            catch (System.Exception e)
            {
                throw new VooperException($"Malformed response: {json}");
            }
#pragma warning restore 0168

            return snapshot;
        }
        public string GetUsername()
        {
            return GetUsernameAsync().Result;
        }

        public async Task<string> GetUsernameAsync()
        {
            return await SpookVooperAPI.GetData($"https://api.spookvooper.com/user/GetUsername?svid={Id}");
        }

        public bool HasDiscordRole(string role)
        {
            return HasDiscordRoleAsync(role).Result;
        }

        public async Task<bool> HasDiscordRoleAsync(string role)
        {
            string response = await SpookVooperAPI.GetData($"https://api.spookvooper.com/user/HasDiscordRole?userid={Id}&role={role}");

            try
            {
                return bool.Parse(response);
            }
#pragma warning disable 0168
            catch (System.Exception e)
            {
                throw new VooperException($"Malformed response: {response}");
            }
#pragma warning restore 0168
        }

        public List<DiscordRoleData> GetDiscordRoles()
        {
            return GetDiscordRolesAsync().Result;
        }

        public async Task<List<DiscordRoleData>> GetDiscordRolesAsync()
        {
            string response = await SpookVooperAPI.GetData($"https://api.spookvooper.com/user/GetDiscordRoles?svid={Id}");

            return JsonConvert.DeserializeObject<List<DiscordRoleData>>(response);
        }

        public int GetDaysSinceLastMove()
        {
            return GetDaysSinceLastMoveAsync().Result;
        }

        public async Task<int> GetDaysSinceLastMoveAsync()
        {
            string response = await SpookVooperAPI.GetData($"https://api.spookvooper.com/user/GetDaysSinceLastMove?svid={Id}");

            int result = int.MaxValue;

            int.TryParse(response, out result);

            return result;
        }

        // Static methods

        public static string GetSVIDFromUsername(string username)
        {
            return GetSVIDFromUsernameAsync(username).Result;
        }

        public static async Task<string> GetSVIDFromUsernameAsync(string username)
        {
            return await SpookVooperAPI.GetData($"https://api.spookvooper.com/user/GetSVIDFromUsername?username={username}");
        }

        public static string GetSVIDFromDiscord(ulong discordid)
        {
            return GetSVIDFromDiscordAsync(discordid).Result;
        }

        public static async Task<string> GetSVIDFromDiscordAsync(ulong discordid)
        {
            return await SpookVooperAPI.GetData($"https://api.spookvooper.com/user/GetSVIDFromDiscord?discordid={discordid}");
        }

        public static string GetUsernameFromDiscord(ulong discordid)
        {
            return GetUsernameFromDiscordAsync(discordid).Result;
        }

        public static async Task<string> GetUsernameFromDiscordAsync(ulong discordid)
        {
            return await SpookVooperAPI.GetData($"https://api.spookvooper.com/user/GetUsernameFromDiscord?discordid={discordid}");
        }

        public static string GetUsernameFromMinecraft(string minecraftid)
        {
            return GetUsernameFromMinecraftAsync(minecraftid).Result;
        }

        public static async Task<string> GetUsernameFromMinecraftAsync(string minecraftid)
        {
            return await SpookVooperAPI.GetData($"https://api.spookvooper.com/user/GetUsernameFromMinecraft?minecraftid={minecraftid}");
        }

        public static string GetSVIDFromMinecraft(string minecraftid)
        {
            return GetSVIDFromMinecraftAsync(minecraftid).Result;
        }

        public static async Task<string> GetSVIDFromMinecraftAsync(string minecraftid)
        {
            return await SpookVooperAPI.GetData($"https://api.spookvooper.com/user/GetSVIDFromMinecraft?minecraftid={minecraftid}");
        }
    }
}
