using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace SpookVooper.Api.Entities
{
    public interface Entity
    {
        public string Id { get; }

        public decimal GetBalance();

        public Task<decimal> GetBalanceAsync();

        public TaskResult SendCredits(decimal amount, string to, string description);

        public TaskResult SendCredits(decimal amount, Entity to, string description);

        public Task<TaskResult> SendCreditsAsync(decimal amount, string to, string description);

        public Task<TaskResult> SendCreditsAsync(decimal amount, Entity to, string description);
    }
}
