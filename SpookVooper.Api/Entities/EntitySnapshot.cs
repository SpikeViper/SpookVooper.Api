using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpookVooper.Api.Entities
{
    public class EntitySnapshot
    {
        [JsonProperty]
        public string Id { get; set; }

        [JsonProperty]
        public string Name { get; set; }

        [JsonProperty]
        public decimal Credits { get; set; }

        [JsonProperty]
        public string Image_Url { get; set; }
    }
}
