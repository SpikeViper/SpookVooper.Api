using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpookVooper.Api.Entities
{
    public class DiscordRoleData
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Id")]
        public ulong Id { get; set; }

        public DiscordRoleData(string name, ulong id)
        {
            this.Name = name;
            this.Id = id;
        }
    }
}
