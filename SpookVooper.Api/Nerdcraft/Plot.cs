using System.ComponentModel.DataAnnotations;

namespace SpookVooper.Api.Nerdcraft
{
    public class Plot
    {
        [Key]
        public string Id { get; }
        public int X { get; }
        public int Z { get; }
        public bool ForSale { get; }
        public bool GroupOwned { get; }
        public string Owner { get; }
        public float Price { get; }
        public string Title { get; }
        public string Builders { get; }
        public bool Public { get; }
        public bool NoLimit { get; }
    }
}
