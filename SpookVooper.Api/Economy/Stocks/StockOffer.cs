using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace SpookVooper.Api.Economy.Stocks
{
    /// <summary>
    /// Stock offers are the object used to represent open stock trades.
    /// A stock offer object is created when a trade is initiated, and removed when completed.
    /// </summary>
    public class StockOffer
    {
        // The ID of this stock offer
        [Key]
        [JsonPropertyName("Id")]
        public string Id { get; set; }

        [JsonPropertyName("Owner_Name")]
        public string OwnerName { get; set; }

        // Owner of this offer
        [JsonPropertyName("Owner_Id")]
        public string OwnerId { get; set; }

        // The ticker of the stock in this offer
        [JsonPropertyName("Ticker")]
        public string Ticker { get; set; }

        // The type of order that has been placed.
        // Valid options are BUY and SELL
        [JsonPropertyName("Order_Type")]
        public string OrderType { get; set; }

        // The target price for this order, also known as a "ASK" or "BID" value
        [JsonPropertyName("Target")]
        public decimal Target { get; set; }

        // The amount of stock in this offer
        [JsonPropertyName("Amount")]
        public int Amount { get; set; }
    }
}
