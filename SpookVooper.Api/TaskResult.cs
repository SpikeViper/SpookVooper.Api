using System.Text.Json.Serialization;

namespace SpookVooper.Api
{
    public class TaskResult
    {
        [JsonPropertyName("info")]
        public string Info { get; set; }
        [JsonPropertyName("succeeded")]
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

    public class TaskResult<T>
    {
        public string Info { get; set; }
        public bool Succeeded { get; set; }
        public T Data { get; set; }

        public TaskResult(bool success, string info, T data)
        {
            Info = info;
            Succeeded = success;
            Data = data;
        }

        public TaskResult()
        {
            Succeeded = false;
            Info = "An unknown error occured, or the task was never flagged as successful.";
            Data = default;
        }
    }
}
