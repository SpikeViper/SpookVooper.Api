using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Concurrent;
using SpookVooper.Api.Entities;

namespace SpookVooper.Api.Economy.Stocks
{
    public class StockObject
    {
        // Stock ID is NOT the ticker, it is a UUID for this "stack" of stock
        [Key]
        public string Id { get; set; }

        // The ticker is the unique symbol used to identify the stock
        public string Ticker { get; set; }

        // The ID of the owning entity
        public string Owner_Id { get; set; }

        // The amount of stock in this
        public int Amount { get; set; }

        // The name of the stock item
        public string Name { get { return Ticker + " Stock"; } }

        public decimal GetValue()
        {
            return SpookVooperAPI.Economy.GetStockValue(Ticker).Result;
        }

        public async Task<decimal> GetValueAsync()
        {
            return await SpookVooperAPI.Economy.GetStockValue(Ticker);
        }
        public bool IsOwner(Entity entity)
        {
            return Owner_Id == entity.Id;
        }
    }
}
