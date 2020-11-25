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

        public Task<decimal> GetBalance();

        public Task<TaskResult> SendCredits(decimal amount, string to, string description);

        public Task<TaskResult> SendCredits(decimal amount, User to, string description);
    }
}
