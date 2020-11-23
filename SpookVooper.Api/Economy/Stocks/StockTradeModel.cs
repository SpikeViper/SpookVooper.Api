using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SpookVooper.Api.Economy.Stocks
{
    public class StockTradeModel
    {
        [JsonProperty("Ticker")]
        public string Ticker { get; set; }

        [JsonProperty("Amount")]
        public int Amount { get; set; }

        [JsonProperty("Price")]
        public decimal Price { get; set; }

        [JsonProperty("From")]
        public string From { get; set; }

        [JsonProperty("To")]
        public string To { get; set; }

        [JsonProperty("Buy_Id")]
        public string Buy_Id { get; set; }

        [JsonProperty("True_Price")]
        public decimal True_Price { get; set; }

        [JsonProperty("Sell_Id")]
        public string Sell_Id { get; set; }
    }
}
