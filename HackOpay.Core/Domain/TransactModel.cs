using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HackOpay.Core.Domain
{

    public class TransactModel : BaseEntity<int>
    {
        public int RecipientId { get; set; }
        public int PayerId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentRef { get; set; }
        public int CurrencyId { get; set; }
        public int TrnxStatus { get; set; }

        public string RecipientName { get; set; }
        public string RecipientEmail { get; set; }
        public string RecipientMobile { get; set; }
        public string RecipientAccountNumber { get; set; }
        public int RecipientBankId { get; set; }
        public int RecipientBankName { get; set; }


        public string PayerName { get; set; }
        public string PayerEmail { get; set; }


    }

}