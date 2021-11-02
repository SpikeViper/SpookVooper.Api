using System.Text.Json.Serialization;

namespace SpookVooper.Api.Economy.Stocks
{
    public class OfferInfo
    {
        [JsonPropertyName("Target")]
        public decimal Target { get; set; }

        [JsonPropertyName("Amount")]
        public int Amount { get; set; }
    }
}
