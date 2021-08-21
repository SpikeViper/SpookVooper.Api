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
        public string Id { get; }

        [JsonPropertyName("Owner_Name")]
        public string OwnerName { get; }

        // Owner of this offer
        [JsonPropertyName("Owner_Id")]
        public string OwnerId { get; }

        // The ticker of the stock in this offer
        [JsonPropertyName("Ticker")]
        public string Ticker { get; }

        // The type of order that has been placed.
        // Valid options are BUY and SELL
        [JsonPropertyName("Order_Type")]
        public string OrderType { get; }

        // The target price for this order, also known as a "ASK" or "BID" value
        [JsonPropertyName("Target")]
        public decimal Target { get; }

        // The amount of stock in this offer
        [JsonPropertyName("Amount")]
        public int Amount { get; }
    }
}
