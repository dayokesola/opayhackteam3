using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HackOpay.Core.Domain
{

    public class Transaction : BaseEntity<int>
    {
        public int RecipientId { get; set; }
        public int PayerId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentRef { get; set; }
        public int CurrencyId { get; set; }
        public int TrnxStatus { get; set; }
    }

}