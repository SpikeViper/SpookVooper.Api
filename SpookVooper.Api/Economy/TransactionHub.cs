using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
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
                Console.WriteLine(message);
                Transaction transaction = null;
                try
                {
                    transaction = JsonSerializer.Deserialize<Transaction>(message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }

                OnTransaction?.Invoke(transaction);
            });

            try
            {
                connection.StartAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occured while opening the SignalR for the Transaction hub");
                Console.WriteLine(e);
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
