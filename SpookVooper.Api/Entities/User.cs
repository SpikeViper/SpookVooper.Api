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
        /// The core SVID for this user
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The key used to authenticate requests for this user
        /// </summary>
        public string Auth_Key { get; set; }

        /// <summary>
        /// Creates a user object using the SVID and optional key for priviliged actions
        /// </summary>
        public User(string svid, string auth_key = null)
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
        /// Returns all available data about this user at the moment the snapshot is called
        /// </summary>
        public async Task<UserSnapshot> GetSnapshot()
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

        public async Task<string> GetUsername()
        {
            return await SpookVooperAPI.GetData($"https://api.spookvooper.com/user/GetUsername?svid={Id}");
        }

        public async Task<bool> HasDiscordRole(string role)
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

        public async Task<List<DiscordRoleInfo>> GetDiscordRoles()
        {
            string response = await SpookVooperAPI.GetData($"https://api.spookvooper.com/user/GetDiscordRoles?svid={Id}");

            return JsonConvert.DeserializeObject<List<DiscordRoleInfo>>(response);
        }

        public async Task<int> GetDaysSinceLastMove()
        {
            string response = await SpookVooperAPI.GetData($"https://api.spookvooper.com/user/GetDaysSinceLastMove?svid={Id}");

            int result = int.MaxValue;

            int.TryParse(response, out result);

            return result;
        }

        public async Task<decimal> GetBalance()
        {
            string response = await SpookVooperAPI.GetData($"https://api.spookvooper.com/eco/GetBalance?svid={Id}");

            decimal result = 0m;

            try
            {
                result = decimal.Parse(response);
            }
#pragma warning disable 0168
            catch (System.Exception e)
            {
                throw new VooperException($"Malformed response: {response}");
            }
#pragma warning restore 0168

            return result;
        }

        public async Task<TaskResult> SendCredits(decimal amount, User to, string description)
        {
            return await SendCredits(amount, to.Id, description);
        }

        public async Task<TaskResult> SendCredits(decimal amount, string to, string description)
        {
            string response = "";

            try
            {
                response = await SpookVooperAPI.GetData($"https://api.spookvooper.com/eco/SendTransactionByIDS?from={Id}&to={to}&amount={amount}&auth={Auth_Key}&detail={description}");
            }
#pragma warning disable 0168
            catch (VooperException e)
            {
                // Ignore HTTP error codes, TaskResult handles it
            }
#pragma warning restore 0168

            TaskResult result = null;

            try
            {
                result = JsonConvert.DeserializeObject<TaskResult>(response);
            }
#pragma warning disable 0168
            catch (Exception e)
            {
                result = new TaskResult(false, "An error occured getting a response from SpookVooper.");
            }
#pragma warning restore 0168

            return result;
        }

        public class DiscordRoleInfo
        {
            [JsonProperty]
            public string Name { get; set; }

            [JsonProperty]
            public ulong Id { get; set; }
        }

        // Static methods

        public static async Task<string> GetSVIDFromUsername(string username)
        {
            return await SpookVooperAPI.GetData($"https://api.spookvooper.com/user/GetSVIDFromUsername?username={username}");
        }

        public static async Task<string> GetSVIDFromDiscord(ulong discordid)
        {
            return await SpookVooperAPI.GetData($"https://api.spookvooper.com/user/GetSVIDFromDiscord?discordid={discordid}");
        }

        public static async Task<string> GetUsernameFromDiscord(ulong discordid)
        {
            return await SpookVooperAPI.GetData($"https://api.spookvooper.com/user/GetUsernameFromDiscord?discordid={discordid}");
        }

        public static async Task<string> GetUsernameFromMinecraft(string minecraftid)
        {
            return await SpookVooperAPI.GetData($"https://api.spookvooper.com/user/GetUsernameFromMinecraft?minecraftid={minecraftid}");
        }

        public static async Task<string> GetSVIDFromMinecraft(string minecraftid)
        {
            return await SpookVooperAPI.GetData($"https://api.spookvooper.com/user/GetSVIDFromMinecraft?minecraftid={minecraftid}");
        }
    }
}
