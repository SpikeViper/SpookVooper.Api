using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpookVooper.Api
{
    public class TaskResult
    {
        [JsonPropertyName("Info")]
        public string Info { get; }
        [JsonPropertyName("Succeeded")]
        public bool Succeeded { get; }

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
