using System;
namespace OverTheHorizon
{
    public class Product
    {
        public Product()
        {
        }
        public int Id { get; set; }
        public int CityId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public float PriceIndex { get; set; }
        public bool IsBuy { get; set; }
        public bool IsSell { get; set; }
    }
}
