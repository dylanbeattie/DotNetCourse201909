using System;
using System.Collections.Generic;
using System.Linq;

namespace Bitflags
{
    class Program
    {
        static void Main(string[] args)
        {
            var car = new Car { Features = Features.MetallicPaint | Features.Sunroof };
            Console.WriteLine(car);
        }
    }

    public class Car {
        public Dictionary<AvailableFeatures, decimal> PriceAdjustments = new Dictionary<AvailableFeatures, decimal> {
            { AvailableFeatures.MetallicPaint, 1000M },
            { AvailableFeatures.Sunroof, 500M },
            { AvailableFeatures.TapeDeck, -500M }
        };

        public List<AvailableFeatures> ListFeatures {
            get {
                var result = new List<AvailableFeatures>();
                foreach(AvailableFeatures feature in PriceAdjustments.Keys) {
                     if (Features.HasFlag(feature)) result.Add(feature);
                 }
                return(result);
            }
        }

        public AvailableFeatures Features { get; set; }

        public decimal Price {
            get {
                var priceAdjustment = 0M;
                foreach(var feature in this.ListFeatures) {
                    priceAdjustment += PriceAdjustments[feature];
                }
                return (priceAdjustment);
            }
        }

        public override string ToString() {
            return($"A car with: {Features}");
        }
    }


    [Flags]
    public enum AvailableFeatures {
        MetallicPaint = 0b0001,
        Sunroof = 0b0010,
        TapeDeck = 0b0100,
        Convertible = 0b1000
    }
}
