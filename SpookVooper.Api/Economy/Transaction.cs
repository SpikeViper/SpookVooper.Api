using SpookVooper.Api.Entities;
using System;
using System.Text.Json.Serialization;

namespace SpookVooper.Api.Economy
{
    public enum ApplicableTax
    {
        None = 0, Corporate = 1, Payroll = 2, CapitalGains = 3, Sales = 4
    }

    public class Transaction
    {
        [JsonPropertyName("FromAccount")]
        public string FromAccount { get; set; }

        [JsonPropertyName("ToAccount")]
        public string ToAccount { get; set; }

        [JsonPropertyName("Amount")]
        public decimal Amount { get; set; }

        [JsonPropertyName("Detail")]
        public string Detail { get; set; }

        [JsonPropertyName("Force")]
        public bool Force { get; set; }

        [JsonPropertyName("IsCompleted")]
        public bool IsCompleted { get; set; }

        [JsonPropertyName("Tax")]
        public ApplicableTax Tax { get; set; }

        [JsonPropertyName("Result")]
        private TaskResult Result { get; set; }

        public Entity GetSender() {

            if (FromAccount == null || string.IsNullOrWhiteSpace(FromAccount)) return null;

            return new Entity(FromAccount);
        }

        public Entity GetReciever()
        {
            if (ToAccount == null || string.IsNullOrWhiteSpace(ToAccount)) return null;

            return new Entity(ToAccount);
        }

        // enum.ToString() performance is worse then a switch
        public string TaxToString()
        {
            return TaxToString(Tax);
        }

        public static string TaxToString(ApplicableTax type)
        {
            return type switch
            {
                ApplicableTax.None => nameof(ApplicableTax.None),
                ApplicableTax.Corporate => nameof(ApplicableTax.Corporate),
                ApplicableTax.Payroll => nameof(ApplicableTax.Payroll),
                ApplicableTax.CapitalGains => nameof(ApplicableTax.CapitalGains),
                ApplicableTax.Sales => nameof(ApplicableTax.Sales),
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }
    }
}
