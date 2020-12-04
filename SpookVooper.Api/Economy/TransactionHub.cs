using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpookVooper.Api.Economy
{
    /// <summary>
    /// The function to be run when a transaction is recieved
    /// </summary>
    public delegate void TransactionAction(Transaction transaction);

    /// <summary>
    /// A class used to connect to and use the transaction hub system
    /// </summary>
    public class TransactionHub
    {
        public HubConnection connection;

        public event TransactionAction OnTransaction;

        public TransactionHub()
        {
            Console.WriteLine("Starting Transaction hub connection...");

            connection = new HubConnectionBuilder()
                .WithUrl("https://spookvooper.com/transactionHub")
                .WithAutomaticReconnect()
                .Build();

            connection.Closed += OnClosed;

            connection.On("NotifyTransaction", (string message) =>
            {
                Transaction transaction = JsonConvert.DeserializeObject<Transaction>(message);
                OnTransaction?.Invoke(transaction);
            });

            try
            {
                connection.StartAsync();
            }
            catch (System.Exception e)
            {
                Console.WriteLine("An error occured while opening the SignalR for the Transaction hub");
                Console.WriteLine(e.Message);
            }
        }

        public async Task OnClosed(Exception e)
        {
            Console.WriteLine("Transaction hub disconnected...");
            Console.WriteLine(e.Message);

            await connection.StartAsync();
        }
    }
}
