using System.Text.Json.Serialization;

namespace SpookVooper.Api.Economy.Stocks
{
    public class StockTradeModel
    {
        public string Ticker { get; }

        public int Amount { get; }

        public decimal Price { get; }

        public string From { get; }

        public string To { get; }

        public string BuyId { get; }

        public decimal TruePrice { get; }

        public string SellId { get; }
    }
}
