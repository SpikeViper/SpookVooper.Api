﻿using SpookVooper.Api.Entities;
using System;
using System.Threading.Tasks;

namespace SpookVooper.Api
{
    /// <summary>
    /// This class exists to show you how to use the API effectively
    /// </summary>
    public class Example
    {
        static async Task Main(string[] args)
        {
            // Define two users with SVIDs
            User spike = new User("u-2a0057e6-356a-4a49-b825-c37796cb7bd9");
            User brendan = new User("u-02c977bb-0a6c-4eb2-bfca-5e9101025aaf");

            // Print their names and balances
            Console.WriteLine($"{spike.GetUsername()} has ¢{spike.GetBalance()}");
            Console.WriteLine($"{brendan.GetUsername()} has ¢{brendan.GetBalance()}");

            // Set the key for spike *can also be done as a second argument during creation*
            spike.SetAuthKey("this-is-a-key");

            // Have spike send a transaction to brendan
            TaskResult result = await spike.SendCredits(100, brendan, "Friend payment");

            // Log the result of the transaction
            Console.WriteLine(result.Info);

            // Need more data?
            // Use "snapshots" to get a large yet non-updating set of data from a group or user
            UserSnapshot snapShot = await spike.GetSnapshot();
            int messageCount = snapShot.discord_message_count;

            Console.WriteLine($"{spike.GetUsername()} sent {messageCount} messages!");
        }
    }
}
