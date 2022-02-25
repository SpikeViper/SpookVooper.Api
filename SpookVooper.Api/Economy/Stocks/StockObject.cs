using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SpookVooper.Api.Entities;
using static SpookVooper.Api.SpookVooperAPI.Economy;
using System.Text.Json.Serialization;

namespace SpookVooper.Api.Economy.Stocks
{
    public class StockObject
    {
        // Stock ID is NOT the ticker, it is a UUID for this "stack" of stock
        [Key]
        [JsonPropertyName("Id")]
        public string Id { get; }

        // The ticker is the unique symbol used to identify the stock
        [JsonPropertyName("Ticker")]
        public string Ticker { get; }

        // The ID of the owning entity
        [JsonPropertyName("Owner_Id")]
        public string Owner_Id { get; }

        // The amount of stock in this
        [JsonPropertyName("Amount")]
        public int Amount { get; }

        // The name of the stock item
        [JsonPropertyName("Name")]
        public string Name { get { return Ticker + " Stock"; } }

        public async Task<decimal> GetValueAsync() => await GetStockValue(Ticker);

        public bool IsOwner(Entity entity) => Owner_Id == entity.Id;
    }
}
