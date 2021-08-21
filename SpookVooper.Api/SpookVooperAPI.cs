using Microsoft.VisualBasic.CompilerServices;
using SpookVooper.Api.Economy.Stocks;
using SpookVooper.Api.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpookVooper.Api
{
    /// <summary>
    /// This is the "main" class for the API, allowing for a lot of general and useful operations
    /// </summary>
    public static class SpookVooperAPI
    {
        public static readonly HttpClient client = new()
        {
            BaseAddress = new Uri("https://api.spookvooper.com/")
        };

        public static readonly CultureInfo USCulture = new("en-US");

        public static async Task<T> GetDataFromJson<T>(string url)
        {
            try
            {
                return await client.GetFromJsonAsync<T>(url);
            }
            catch (Exception e)
            {
                throw new VooperException($"HTTP Error for GetDataFromJson!\n{e}");
            }
        }

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
                TaskResult result;
                try
                {
                    result = await GetDataFromJson<TaskResult>($"eco/SendTransactionByIDS?from={from}&to={to}&amount={amount}&auth={auth}&detail={detail}");
                   
                }
                catch (VooperException)
                {
                    result = new TaskResult(false, "An error occured getting a response from SpookVooper.");
                }

                return result;
            }

            public static async Task<decimal> GetStockValue(string ticker)
            {
                string response = await GetData($"eco/GetStockValue?ticker={ticker}");

                if (decimal.TryParse(response, NumberStyles.Number, USCulture, out decimal result)) return result;

                throw new VooperException($"Malformed response for GetStockValue: {response}");
            }

            public static async Task<List<decimal>> GetStockHistory(string ticker, string type, int count, int interval)
            {
                List<decimal> results;
                try
                {
                    results = await GetDataFromJson<List<decimal>>($"eco/GetStockHistory?ticker={ticker}&type={type}&count={count}&interval={interval}");
                }
                catch (Exception)
                {
                    throw new VooperException($"Malformed response for GetStockHistory");
                }

                return results;
            }

            public static async Task<List<int>> GetStockVolumeHistory(string ticker, string type, int count, int interval)
            {
                List<int> results;
                try
                {
                    results = await GetDataFromJson<List<int>>($"eco/GetStockHistory?ticker={ticker}&type={type}&count={count}&interval={interval}");
                }
                catch (Exception)
                {
                    throw new VooperException($"Malformed response for GetStockVolumeHistory");
                }

                return results;
            }

            public static async Task<TaskResult> SubmitStockBuy(string ticker, int count, decimal price, string accountid, string auth)
            {
                TaskResult result;
                try
                {
                    result = await GetDataFromJson<TaskResult>($"eco/SubmitStockBuy?ticker={ticker}&count={count}&price={price}&accountid={accountid}&auth={auth}");
                }
                catch (Exception)
                {
                    result = new TaskResult(false, "An error occured getting a response from SpookVooper.");
                }

                return result;
            }

            public static async Task<TaskResult> SubmitStockSell(string ticker, int count, decimal price, string accountid, string auth)
            {
                TaskResult result;
                try
                {
                    result = await GetDataFromJson<TaskResult>($"eco/SubmitStockSell?ticker={ticker}&count={count}&price={price}&accountid={accountid}&auth={auth}");
                }
                catch (Exception)
                {
                    result = new TaskResult(false, "An error occured getting a response from SpookVooper.");
                }

                return result;
            }

            public static async Task<TaskResult> CancelOrder(string orderid, string accountid, string auth)
            {
                TaskResult result;
                try
                {
                    result = await GetDataFromJson<TaskResult>($"eco/CancelOrder?orderid={orderid}&accountid={accountid}&auth={auth}");
                }
                catch (Exception)
                {
                    result = new TaskResult(false, "An error occured getting a response from SpookVooper.");
                }

                return result;
            }

            public static async Task<decimal> GetStockBuyPrice(string ticker)
            {
                string response = await GetData($"eco/GetStockBuyPrice?ticker={ticker}");

                if (decimal.TryParse(response, NumberStyles.Number, USCulture, out decimal result)) return result;

                throw new VooperException($"Malformed response for GetStockBuyPrice: {response}");
            }

            public static async Task<List<OfferInfo>> GetQueueInfo(string ticker, string type)
            {
                List<OfferInfo> results;
                try
                {
                    results = await GetDataFromJson<List<OfferInfo>>($"eco/GetQueueInfo?ticker={ticker}&type={type}");
                }
                catch (Exception)
                {
                    throw new VooperException($"Malformed response for GetQueueInfo");
                }

                return results;
            }

            public static async Task<List<StockOffer>> GetUserStockOffers(string ticker, string svid)
            {
                List<StockOffer> results;
                try
                {
                    results = await GetDataFromJson<List<StockOffer>>($"eco/GetUserStockOffers?ticker={ticker}&svid={svid}");
                }
                catch (Exception)
                {
                    throw new VooperException($"Malformed response for GetUserStockOffers");
                }

                return results;
            }
        }
    }
}
