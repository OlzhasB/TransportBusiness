using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportBusiness
{
    class Order
    {
        public Order() { }
        public Order(int orderID, List<Cargo> Cargoes, string departureCity,
            string arrivalCity, Customer customer, int carrierID, decimal price, DateTime creationDate, 
            DateTime departureDate, DateTime arrivalDate, DateTime completionDate)
        {
            this.orderID = orderID;
            this.Cargoes = Cargoes;
            this.departureCity = departureCity;
            this.arrivalCity = arrivalCity;
            this.customer = customer;
            this.carrierID = carrierID;
            this.price = price;
            this.creationDate = creationDate;
            this.departureDate = departureDate;
            this.arrivalDate = arrivalDate;
            this.completionDate = completionDate;
        }
        public int orderID { get; set; }
        public List<Cargo> Cargoes { get; set; }
        public string departureCity { get; set; }
        public string arrivalCity { get; set; }
        public Customer customer { get; set; }

        public int carrierID { get; set; }
        public decimal price { get; set; }
        public DateTime creationDate { get; set; }
        public DateTime departureDate { get; set; }
        public DateTime arrivalDate { get; set; }
        public DateTime completionDate { get; set; }
    }
}
