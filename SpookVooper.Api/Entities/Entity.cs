using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Newtonsoft.Json;

namespace SpookVooper.Api.Entities
{
    public class Entity
    {
        public string Id { get; set; }

        public string Auth_Key { get; set; }

        public Entity(string svid, string auth_key = null){
            this.Id = svid;
            this.Auth_Key = auth_key;

            if (!svid.StartsWith("u-") && !svid.StartsWith("g-"))
            {
                throw new VooperException("Svid should start with a u- or g- for an entity object!");
            }
        }

        public string GetName()
        {
            return GetNameAsync().Result;
        }
        public async Task<string> GetNameAsync()
        {
            return await SpookVooperAPI.GetData($"https://api.spookvooper.com/Entity/GetName?svid={Id}");
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

        public TaskResult SendCredits(decimal amount, string to, string description)
        {
            return SendCreditsAsync(amount, to, description).Result;
        }

        public TaskResult SendCredits(decimal amount, Entity to, string description)
        {
            return SendCreditsAsync(amount, to, description).Result;
        }

        public async Task<TaskResult> SendCreditsAsync(decimal amount, Entity to, string description)
        {
            return await SendCreditsAsync(amount, to.Id, description);
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
                result = new TaskResult(false, response);
            }
#pragma warning restore 0168

            return result;
        }
    }
}
