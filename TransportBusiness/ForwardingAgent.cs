
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportBusiness
{
    class ForwardingAgent
    {
        public uint forwardingAgentID { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public List<Order> Orders { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
    }
}
