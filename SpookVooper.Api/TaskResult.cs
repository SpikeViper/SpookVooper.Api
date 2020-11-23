using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpookVooper.Api
{
    public class TaskResult
    {
        [JsonProperty("Info")]
        public string Info { get; set; }
        [JsonProperty("Succeeded")]
        public bool Succeeded { get; set; }

        public TaskResult(bool success, string info)
        {
            Info = info;
            Succeeded = success;
        }

        public TaskResult()
        {
            Succeeded = false;
            Info = "An unknown error occured, or the task was never flagged as successful.";
        }
    }
}
