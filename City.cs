using System;
namespace OverTheHorizon
{
    public class City
    {
        public City()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public double PriceIndex { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsMarket { get; set; }
    }
}
