using System.Text.Json.Serialization;

namespace SpookVooper.Api.Economy.Stocks
{
    public class OfferInfo
    {
        [JsonPropertyName("Target")]
        public decimal Target { get; }

        [JsonPropertyName("Amount")]
        public int Amount { get; }
    }
}
