using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;
using SpookVooper.Api.Economy.Stocks;
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
            string response = await httpResponse.Content.ReadAsStringAsync();

            if (httpResponse.IsSuccessStatusCode)
            {
                return response;
            }
            else
            {
                return $"HTTP Error: {httpResponse.StatusCode}; {response}";
            }
        }

        /// <summary>
        /// Allows for easy use of SpookVooper economic functions
        /// </summary>
        public static class Economy
        {

            public static async Task<TaskResult> SendTransactionByIDS(string from, string to, decimal amount, string auth, string detail)
            {
                string response = "";

                try
                {
                   response = await GetData($"https://api.spookvooper.com/eco/SendTransactionByIDS?from={from}&to={to}&amount={amount}&auth={auth}&detail={detail}");
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
                catch(Exception e)
                {
                    result = new TaskResult(false, "An error occured getting a response from SpookVooper.");
                }
                #pragma warning restore 0168

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
                #pragma warning disable 0168
                catch (System.Exception e)
                {
                    throw new VooperException($"Malformed response: {response}");
                }
                #pragma warning restore 0168

                return result;
            }

            public static async Task<List<decimal>> GetStockHistory(string ticker, string type, int count, int interval)
            {
                string response = await GetData($"https://api.spookvooper.com/eco/GetStockHistory?ticker={ticker}&type={type}&count={count}&interval={interval}");

                List<decimal> results = null;

                try
                {
                    results = JsonConvert.DeserializeObject<List<decimal>>(response);
                }
                #pragma warning disable 0168
                catch (System.Exception e)
                {
                    throw new VooperException($"Malformed response: {response}");
                }
                #pragma warning restore 0168

                return results;
            }

            public static async Task<List<int>> GetStockVolumeHistory(string ticker, string type, int count, int interval)
            {
                string response = await GetData($"https://api.spookvooper.com/eco/GetStockHistory?ticker={ticker}&type={type}&count={count}&interval={interval}");

                List<int> results = null;

                try
                {
                    results = JsonConvert.DeserializeObject<List<int>>(response);
                }
                #pragma warning disable 0168
                catch (System.Exception e)
                {
                    throw new VooperException($"Malformed response: {response}");
                }
                #pragma warning restore 0168

                return results;
            }

            public static async Task<TaskResult> SubmitStockBuy(string ticker, int count, decimal price, string accountid, string auth)
            {
                string response = "";

                try
                {
                    response = await GetData($"https://api.spookvooper.com/eco/SubmitStockBuy?ticker={ticker}&count={count}&price={price}&accountid={accountid}&auth={auth}");
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

            public static async Task<TaskResult> SubmitStockSell(string ticker, int count, decimal price, string accountid, string auth)
            {
                string response = "";

                try
                {
                    response = await GetData($"https://api.spookvooper.com/eco/SubmitStockSell?ticker={ticker}&count={count}&price={price}&accountid={accountid}&auth={auth}");
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

            public static async Task<TaskResult> CancelOrder(string orderid, string accountid, string auth)
            {
                string response = "";

                try
                {
                    response = await GetData($"https://api.spookvooper.com/eco/CancelOrder?orderid={orderid}&accountid={accountid}&auth={auth}");
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

            public static async Task<decimal> GetStockBuyPrice(string ticker)
            {
                string response = await GetData($"https://api.spookvooper.com/eco/GetStockBuyPrice?ticker={ticker}");

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

            public static async Task<List<OfferInfo>> GetQueueInfo(string ticker, string type)
            {
                string response = await GetData($"https://api.spookvooper.com/eco/GetQueueInfo?ticker={ticker}&type={type}");

                List<OfferInfo> results = null;

                try
                {
                    results = JsonConvert.DeserializeObject<List<OfferInfo>>(response);
                }
                #pragma warning disable 0168
                catch (System.Exception e)
                {
                    throw new VooperException($"Malformed response: {response}");
                }
                #pragma warning restore 0168

                return results;
            }

            public static async Task<List<StockOffer>> GetUserStockOffers(string ticker, string svid)
            {
                string response = await GetData($"https://api.spookvooper.com/eco/GetUserStockOffers?ticker={ticker}&svid={svid}");

                List<StockOffer> results = null;

                try
                {
                    results = JsonConvert.DeserializeObject<List<StockOffer>>(response);
                }
                #pragma warning disable 0168
                catch (System.Exception e)
                {
                    throw new VooperException($"Malformed response: {response}");
                }
                #pragma warning restore 0168

                return results;
            }
        }
    }
}
