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

            if (httpResponse.IsSuccessStatusCode)
            {
                return await httpResponse.Content.ReadAsStringAsync();
            }
            else
            {
                throw new VooperException($"Response failed: HTTP Code {httpResponse.StatusCode}");
            }
        }

        /// <summary>
        /// All API functions relating to Users
        /// </summary>
        public static class Users
        {
            public static async Task<User> GetUser(string svid)
            {
                string result = await GetData($"https://api.spookvooper.com/user/GetUser?svid={svid}");

                User user = null;

                try
                {
                    user = (User)JsonConvert.DeserializeObject(result);
                }
                catch (System.Exception e)
                {
                    throw new VooperException($"Malformed response: {result}");
                }

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


        /// <summary>
        /// API routes for Groups
        /// </summary>
        public static class Groups
        {
            public static async Task<decimal> GetBalance(string svid)
            {
                string response = await GetData($"https://api.spookvooper.com/group/GetBalance?svid={svid}");

                decimal result = 0m;

                try
                {
                    result = decimal.Parse(response);
                }
                catch(System.Exception e)
                {
                    throw new VooperException($"Malformed response: {response}");
                }

                return result;
            }

            public static async Task<bool> DoesGroupExist(string svid)
            {
                string response = await GetData($"https://api.spookvooper.com/group/DoesGroupExist?svid={svid}");

                bool result = false;

                try
                {
                    result = bool.Parse(response);
                }
                catch (System.Exception e)
                {
                    throw new VooperException($"Malformed response: {response}");
                }

                return result;
            }

            public static async Task<List<string>> GetGroupMemberIDs(string svid)
            {
                string response = await GetData($"https://api.spookvooper.com/group/GetGroupMembers?svid={svid}");

                List<string> results = null;

                try
                {
                    results = JsonConvert.DeserializeObject<List<string>>(response);
                }
                catch (System.Exception e)
                {
                    throw new VooperException($"Malformed response: {response}");
                }

                return results;
            }

            public static async Task<bool> HasGroupPermission(string groupSVID, string userSVID, string permission)
            {
                string response = await GetData($"https://api.spookvooper.com/group/HasGroupPermission?svid={groupSVID}&usersvid={userSVID}&permission={permission}");

                bool result = false;

                try
                {
                    result = bool.Parse(response);
                }
                catch (System.Exception e)
                {
                    throw new VooperException($"Malformed response: {response}");
                }

                return result;
            }

            public static async Task<string> GetSVIDFromName(string name)
            {
                return await GetData($"https://api.spookvooper.com/group/GetSVIDFromName?name={name}");
            }

            public static async Task<string> GetName(string svid)
            {
                return await GetData($"https://api.spookvooper.com/group/GetName?svid={svid}");
            }
        }

        public static class Economy
        {
            public static async Task<decimal> GetBalance(string svid)
            {
                string response = await GetData($"https://api.spookvooper.com/eco/GetBalance?svid={svid}");

                decimal result = 0m;

                try
                {
                    result = decimal.Parse(response);
                }
                catch (System.Exception e)
                {
                    throw new VooperException($"Malformed response: {response}");
                }

                return result;
            }

            public static async Task<TaskResult> SendTransactionByIDS(string from, string to, decimal amount, string auth, string detail)
            {
                string response = "";

                try
                {
                   response = await GetData($"https://api.spookvooper.com/eco/SendTransactionByIDS?from={from}&to={to}&amount={amount}&auth={auth}&detail={detail}");
                }
                catch (VooperException e)
                {
                    // Ignore HTTP error codes, TaskResult handles it
                }

                TaskResult result = null;

                try
                {
                    result = JsonConvert.DeserializeObject<TaskResult>(response);
                }
                catch(Exception e)
                {
                    result = new TaskResult(false, "An error occured getting a response from SpookVooper.");
                }

                return result;
            }

            public static async Task<decimal> GetStockValue(string ticker)
            {
                string response = await GetData($"https://api.spookvooper.com/eco/GetStockValue?ticker={ticker}");

                decimal result = 0m;

                try
                {
                    result = decimal.Parse(response);
                }
                catch (System.Exception e)
                {
                    throw new VooperException($"Malformed response: {response}");
                }

                return result;
            }

            public static async Task<List<decimal>> GetStockHistory(string ticker, )
            {
                string response = await GetData($"https://api.spookvooper.com/group/GetGroupMembers?svid={svid}");

                List<string> results = null;

                try
                {
                    results = JsonConvert.DeserializeObject<List<string>>(response);
                }
                catch (System.Exception e)
                {
                    throw new VooperException($"Malformed response: {response}");
                }

                return results;
            }

        }
    }
}
