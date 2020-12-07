using Newtonsoft.Json;
using SpookVooper.Api.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SpookVooper.Api.Economy
{
    public enum ApplicableTax
    {
        None = 0, Corporate = 1, Payroll = 2, CapitalGains = 3, Sales = 4
    }

    public class Transaction
    {
        [JsonProperty("FromAccount")]
        public string FromAccount;
        [JsonProperty("ToAccount")]
        public string ToAccount;
        [JsonProperty("Amount")]
        public decimal Amount;
        [JsonProperty("Detail")]
        public string Detail;
        [JsonProperty("Force")]
        public bool Force;
        [JsonProperty("IsCompleted")]
        private bool IsCompleted;
        [JsonProperty("Tax")]
        public ApplicableTax Tax;
        [JsonProperty("Result")]
        private TaskResult Result;

        public Entity GetSender() {

            if (FromAccount == null || string.IsNullOrWhiteSpace(FromAccount))
            {
                return null;
            }

            return new Entity(FromAccount);
        }

        public Entity GetReciever()
        {

            if (ToAccount == null || string.IsNullOrWhiteSpace(ToAccount))
            {
                return null;
            }

            return new Entity(ToAccount);
        }
    }
}
