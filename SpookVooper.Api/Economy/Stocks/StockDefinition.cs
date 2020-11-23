using System.ComponentModel.DataAnnotations;

namespace SpookVooper.Api.Economy.Stocks
{
    public class StockDefinition
    {
        // The ticker, or identifier, for this stock
        [Key]
        public string Ticker { get; set; }

        // The group that issued this stock
        public string Group_Id { get; set; }

        // Current value estimate
        public decimal Current_Value { get; set; }
    }
}
