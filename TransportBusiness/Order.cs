using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportBusiness
{
    class Order
    {
        public Order(int orderID, int weightOfCargo, string departureCity,
            string arrivalCity, int customerID, int carrierID, int leadTimeHours)
        {
            this.orderID = orderID;
            this.weightOfCargo = weightOfCargo;
            this.departureCity = departureCity;
            this.arrivalCity = arrivalCity;
            this.customerID = customerID;
            this.carrierID = carrierID;
            this.leadTimeHours = leadTimeHours;
        }
        public int orderID { get; set; }
        public int weightOfCargo { get; set; }
        public string departureCity { get; set; }
        public string arrivalCity { get; set; }
        public int customerID { get; set; }
        public int carrierID { get; set; }
        public int leadTimeHours { get; set; }
    }
}
