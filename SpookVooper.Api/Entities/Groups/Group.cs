using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace SpookVooper.Api.Entities.Groups
{
    public class Group : Entity
    {
        /// <summary>
        /// The core SVID for this group
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The key used to authenticate requests for this group
        /// </summary>
        public string Auth_Key { get; set; }

        /// <summary>
        /// Creates a group object using the SVID and optional key for priviliged actions
        /// </summary>
        public Group(string svid, string auth_key = null)
        {
            if (!svid.StartsWith("g-"))
            {
                throw new VooperException("Svid should start with a g- for a user object!");
            }

            Id = svid;
            Auth_Key = auth_key;
        }

        public class GroupTypes
        {
            public const string None = "Groups", Political = "Parties", Company = "Companies", News = "News", District = "District";
        }

        /// <summary>
        /// Returns all available data about this user at the moment the snapshot is called
        /// </summary>
        public GroupSnapshot GetSnapshot()
        {
            return GetSnapshotAsync().Result;
        }

        /// <summary>
        /// Returns all available data about this user at the moment the snapshot is called (async)
        /// </summary>
        public async Task<GroupSnapshot> GetSnapshotAsync()
        {
            string json = await SpookVooperAPI.GetData($"https://api.spookvooper.com/group/GetGroup?svid={Id}");

            GroupSnapshot snapshot = null;

            try
            {
                snapshot = JsonConvert.DeserializeObject<GroupSnapshot>(json);
            }
#pragma warning disable 0168
            catch (System.Exception e)
            {
                throw new VooperException($"Malformed response: {json}");
            }
#pragma warning restore 0168

            return snapshot;
        }

        public decimal GetBalance()
        {
            return GetBalanceAsync().Result;
        }

        public async Task<decimal> GetBalanceAsync()
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

        public List<string> GetGroupMemberIDs()
        {
            return GetGroupMemberIDsAsync().Result;
        }

        public async Task<List<string>> GetGroupMemberIDsAsync()
        {
            string response = await SpookVooperAPI.GetData($"https://api.spookvooper.com/group/GetGroupMembers?svid={Id}");

            List<string> results = null;

            try
            {
                results = JsonConvert.DeserializeObject<List<string>>(response);
            }
#pragma warning disable 0168
            catch (System.Exception e)
            {
                throw new VooperException($"Malformed response: {response}");
            }
#pragma warning restore 0168

            return results;
        }

        public bool HasGroupPermission(string userSVID, string permission)
        {
            return HasGroupPermissionAsync(userSVID, permission).Result;
        }

        public async Task<bool> HasGroupPermissionAsync(string userSVID, string permission)
        {
            string response = await SpookVooperAPI.GetData($"https://api.spookvooper.com/group/HasGroupPermission?svid={Id}&usersvid={userSVID}&permission={permission}");

            bool result = false;

            try
            {
                result = bool.Parse(response);
            }
#pragma warning disable 0168
            catch (System.Exception e)
            {
                throw new VooperException($"Malformed response: {response}");
            }
#pragma warning restore 0168

            return result;
        }

        public string GetName()
        {
            return GetNameAsync().Result;
        }

        public async Task<string> GetNameAsync()
        {
            return await SpookVooperAPI.GetData($"https://api.spookvooper.com/group/GetName?svid={Id}");
        }

        // Static methods

        public static bool DoesGroupExist(string svid)
        {
            return DoesGroupExistAsync(svid).Result;
        }

        public static async Task<bool> DoesGroupExistAsync(string svid)
        {
            string response = await SpookVooperAPI.GetData($"https://api.spookvooper.com/group/DoesGroupExist?svid={svid}");

            bool result = false;

            try
            {
                result = bool.Parse(response);
            }
#pragma warning disable 0168
            catch (System.Exception e)
            {
                throw new VooperException($"Malformed response: {response}");
            }
#pragma warning restore 0168

            return result;
        }

        public static string GetSVIDFromName(string name)
        {
            return GetSVIDFromNameAsync(name).Result;
        }

        public static async Task<string> GetSVIDFromNameAsync(string name)
        {
            return await SpookVooperAPI.GetData($"https://api.spookvooper.com/group/GetSVIDFromName?name={name}");
        }

        public TaskResult SendCredits(decimal amount, Entity to, string description)
        {
            return SendCreditsAsync(amount, to, description).Result;
        }

        public async Task<TaskResult> SendCreditsAsync(decimal amount, Entity to, string description)
        {
            return await SendCreditsAsync(amount, to.Id, description);
        }

        public TaskResult SendCredits(decimal amount, string to, string description)
        {
            return SendCreditsAsync(amount, to, description).Result;
        }

        public async Task<TaskResult> SendCreditsAsync(decimal amount, string to, string description)
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


    }
}
