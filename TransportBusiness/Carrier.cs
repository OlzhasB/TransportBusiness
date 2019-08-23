using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportBusiness
{
    class Carrier
    { 
        public Carrier(int carrierID, int vehicleAmount, string route, int transportID,
            int pricePerKm, int cabinVolume)
        {
            this.carrierID = carrierID;
            this.vehicleAmount = vehicleAmount;
            this.route = route;
            this.transportID = transportID;
            this.pricePerKm = pricePerKm;
            this.cabinVolume = cabinVolume;
        }
        public int carrierID { get; set; }
        public int vehicleAmount { get; set; }
        public string route { get; set; }
        public int transportID { get; set; }
        public int pricePerKm { get; set; }
        public int cabinVolume { get; set; }

    }
}
