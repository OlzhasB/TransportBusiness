using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportBusiness
{
    class Agreement
    {
        public int agreementID { get; set; }
        public int customerId { get; set; }
        public int carrierID { get; set; }
        public DateTime departureDate { get; set; }
        public DateTime arrivalDate {get;set;}
        public string departurePoint { get; set; }
        public string destinationPoint { get; set; }
        public bool isSigned { get;set; }
    }
}
