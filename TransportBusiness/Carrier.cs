using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportBusiness
{
    class Carrier
    {
        public Carrier(int carrierID, string carrierName, string phone, string[] routes,
            List<Transport> Transports, List<Driver> Drivers)
        {
            this.carrierID = carrierID;
            this.carrierName = carrierName;
            this.routes = routes;
            this.phone = phone;
            this.Transports = Transports;
            this.Drivers = Drivers;
        }
        public int carrierID { get; set; }
        public string carrierName { get; set; }
        public string phone { get; set; }
        public string[] routes { get; set; }
        public List<Transport> Transports { get; set; }
        public List<Driver> Drivers { get; set; }
        public bool IsAgree { get; set; }
        public bool IsFree { get; set; }
    }
}
