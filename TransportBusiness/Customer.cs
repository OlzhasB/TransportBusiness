using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportBusiness
{
    class Customer
    {
        public Customer(int customerID, string customerName, string firstname, string lastname, string phone)
        {
            this.customerID = customerID;
            this.firstname = firstname;
            this.lastname = lastname;
            this.phone = phone;
        }
        public int customerID { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string phone { get; set; }
        public bool isAgree { get; set; }
    }
}
