using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SpookVooper.Api.Economy.Stocks
{
    public class StockDefinition
    {
        // The ticker, or identifier, for this stock
        [Key]
        public string Ticker { get; }

        // The group that issued this stock
        public string GroupId { get; }

        // Current value estimate
        public decimal CurrentValue { get; }
    }
}
