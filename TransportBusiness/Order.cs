using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportBusiness
{
    class Order
    {
        public int orderID { get; set; }
        public List<Cargo> Cargoes { get; set; }
        public string departureCity { get; set; }
        public string arrivalCity { get; set; }
        public Customer customer { get; set; }
        public double price { get; set; }
        public Transport transport { get; set; }
        public Driver driver { get; set;}
        public DateTime creationDate { get; set; }
        public DateTime departureDate { get; set; }
        public DateTime arrivalDate { get; set; }
        public DateTime completionDate { get; set; }
    }
}
