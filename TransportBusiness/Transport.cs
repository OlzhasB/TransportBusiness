using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportBusiness
{
    class Transport
    {
        public int transportID { get; set; }
        public string transportType { get; set; }
        public int[] cargoID { get; set; }
        public string transportName { get; set; }
        public double loadCapacity { get; set; }
        public double volume { get; set; }
        public double freeWeight { get { return freeWeight; } set { freeWeight = loadCapacity; } }
        public double freeVolume { get { return freeVolume; } set { freeVolume = volume; } }
        public void loadCargo(Cargo[] cs)
        {
            foreach (Cargo c in cs)
            {
                if (freeWeight < c.weight || freeVolume < c.volume)
                {
                    Console.WriteLine($"You cannot load {c.name} in {transportName}");
                    continue;
                }
                freeWeight -= c.weight;
                freeVolume -= c.volume;
            }
        }
        public bool isFree { get; set; }
    }
}
