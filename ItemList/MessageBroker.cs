using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemList
{
    public class MessageBroker
    {
        public string Message { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public bool IsRead { get; set; }
    }
}
