using System.Collections.Generic;
using System.Threading.Tasks;
using static SpookVooper.Api.SpookVooperAPI;

namespace SpookVooper.Api.Entities.Groups
{
    public class Group : Entity
    {
        /// <summary>
        /// Creates a group object using the SVID and optional key for priviliged actions
        /// </summary>
        public Group(string svid, string auth_key = null) : base(svid, auth_key)
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
        /// Returns all available data about this user at the moment the snapshot is called (async)
        /// </summary>
        public async Task<GroupSnapshot> GetSnapshotAsync()
        {
            GroupSnapshot snapshot;
            try
            {
                snapshot = await GetDataFromJson<GroupSnapshot>($"group/GetGroup?svid={Id}");

            }
            catch (VooperException)
            {
                throw new VooperException($"Malformed response for GetGroup");
            }

            return snapshot;
        }
        /// <summary>
        /// Returns all available data about this user at the moment the snapshot is called
        /// </summary>
        public GroupSnapshot GetSnapshot() => GetSnapshotAsync().Result;

        public async Task<List<string>> GetGroupMemberIDsAsync()
        {
            List<string> results;
            try
            {
                results = await GetDataFromJson<List<string>>($"group/GetGroupMembers?svid={Id}");

            }
            catch (VooperException)
            {
                throw new VooperException($"Malformed response for GetGroupMemberIDsAsync");
            }

            return results;
        }

        public async Task<bool> HasGroupPermissionAsync(string userSVID, string permission)
        {
            string response = await GetData($"group/HasGroupPermission?svid={Id}&usersvid={userSVID}&permission={permission}");

            if (bool.TryParse(response, out bool result)) return result;

            throw new VooperException($"Malformed response for HasGroupPermissionAsync: {response}");
        }

        public new async Task<string> GetNameAsync()
        {
            return await GetData($"group/GetName?svid={Id}");
        }

        public static async Task<bool> DoesGroupExistAsync(string svid)
        {
            string response = await GetData($"group/DoesGroupExist?svid={svid}");

            if (bool.TryParse(response, out bool result)) return result;

            throw new VooperException($"Malformed response for DoesGroupExist: {response}");
        }

        public static async Task<string> GetSVIDFromNameAsync(string name)
        {
            string svid = await GetData($"group/GetSVIDFromName?name={name}");

            if (!svid.StartsWith("g-"))
            {
                throw new VooperException($"Malformed response for GetSVIDFromName: {svid}");
            }

            return svid;
        }
    }
}
