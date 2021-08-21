using System;
using System.Globalization;
using System.Threading.Tasks;
using static SpookVooper.Api.SpookVooperAPI;

namespace SpookVooper.Api.Entities
{
    public class Entity
    {
        public string Id { get; protected internal set; }

        public string Auth_Key { get; set; }

        public Entity(string svid, string auth_key = null){
            if (!svid.StartsWith("u-") && !svid.StartsWith("g-"))
            {
                throw new VooperException("Svid should start with a u- or g- for an entity object!");
            }

            Id = svid;
            Auth_Key = auth_key;
        }

        public async Task<string> GetNameAsync()
        {
            return await GetData($"Entity/GetName?svid={Id}");
        }

        public async Task<decimal> GetBalanceAsync()
        {
            string response = await GetData($"eco/GetBalance?svid={Id}");

            if (decimal.TryParse(response, NumberStyles.Number, USCulture, out decimal result)) return result;

            throw new VooperException($"Malformed response for GetBalance: {response}");
        }

        public async Task<TaskResult> SendCreditsAsync(decimal amount, Entity to, string description)
        {
            return await SendCreditsAsync(amount, to.Id, description);
        }

        public async Task<TaskResult> SendCreditsAsync(decimal amount, string to, string description)
        {
            TaskResult result;
            try
            {
                result = await GetDataFromJson<TaskResult>($"eco/SendTransactionByIDS?from={Id}&to={to}&amount={amount}&auth={Auth_Key}&detail={description}");
            }
            catch (Exception e)
            {
                result = new TaskResult(false, e.Message);
            }

            return result;
        }
    }
}
