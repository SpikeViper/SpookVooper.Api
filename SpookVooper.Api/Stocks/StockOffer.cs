using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SpookVooper.Api.Stocks
{
    /// <summary>
    /// Stock offers are the object used to represent open stock trades.
    /// A stock offer object is created when a trade is initiated, and removed when completed.
    /// </summary>
    public class StockOffer
    {
        // The ID of this stock offer
        [Key]
        [JsonProperty("Id")]
        public string Id { get; set; }

        // Owner of this offer
        [JsonProperty("Owner_Id")]
        public string Owner_Id { get; set; }

        // The ticker of the stock in this offer
        [JsonProperty("Ticker")]
        public string Ticker { get; set; }

        // The type of order that has been placed.
        // Valid options are BUY and SELL
        [JsonProperty("Order_Type")]
        public string Order_Type { get; set; }

        // The target price for this order, also known as a "ASK" or "BID" value
        [JsonProperty("Target")]
        public decimal Target { get; set; }

        // The amount of stock in this offer
        [JsonProperty("Amount")]
        public int Amount { get; set; }
    }
}
