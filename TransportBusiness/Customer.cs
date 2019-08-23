using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportBusiness
{
    class Customer
    {
        public Customer(int customerID, string companyName, DateTime creationDate,
            int workersAmount, string city)
        {
            this.customerID = customerID;
            this.companyName = companyName;
            this.creationDate = creationDate;
            this.workersAmount = workersAmount;
            this.city = city;
        }
        public int customerID { get; set; }
        public string companyName { get; set; }
        public DateTime creationDate { get; set; }
        public int workersAmount { get; set; }
        public string city { get; set; }
    }
}
