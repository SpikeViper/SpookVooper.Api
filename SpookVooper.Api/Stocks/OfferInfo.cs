using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpookVooper.Api.Stocks
{
    public class OfferInfo
    {
        [JsonProperty]
        public decimal Target { get; set; }

        [JsonProperty]
        public int Amount { get; set; }
    }
}
