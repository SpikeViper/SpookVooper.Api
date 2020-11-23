using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SpookVooper.Api.Nerdcraft
{
    public class Plot
    {
        [Key]
        public string Id { get; set; }
        public int X { get; set; }
        public int Z { get; set; }
        public bool ForSale { get; set; }
        public bool GroupOwned { get; set; }
        public string Owner { get; set; }
        public float Price { get; set; }
        public string Title { get; set; }
        public string Builders { get; set; }
        public bool Public { get; set; }
        public bool NoLimit { get; set; }
    }
}
