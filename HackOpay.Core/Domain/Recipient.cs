using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackOpay.Core.Domain
{
    public class Recipient : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string AccountNumber { get; set; } 
        public int BankId { get; set; }
    }



}
