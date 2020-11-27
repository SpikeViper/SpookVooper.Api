using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpookVooper.Api.Entities
{
    public class GroupSnapshot
    {
        [JsonProperty]
        public string Id { get; set; }
        [JsonProperty]
        public string Name { get; set; }
        [JsonProperty]
        public string Description { get; set; }
        [JsonProperty]
        public bool Open { get; set; }
        [JsonProperty]
        public decimal Credits { get; set; }
        [JsonProperty]
        public string Image_Url { get; set; }
        [JsonProperty]
        public string Group_Category { get; set; }
        [JsonProperty]
        public string Owner_Id { get; set; }
        [JsonProperty]
        public string District_Id { get; set; }
        [JsonProperty]
        public string Default_Role_Id { get; set; }
        [JsonProperty]
        public decimal Credits_Invested { get; set; }
    }
}
