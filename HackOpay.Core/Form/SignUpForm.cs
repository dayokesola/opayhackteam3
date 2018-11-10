using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackOpay.Core.Form
{
    public class SignUpForm
    {
        [EmailAddress]
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string AccountNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int BankId { get; set; }

        public string FullName()
        {
            return FirstName + " " + LastName;
        }
    }


    public class TransactForm
    {
        public string PayerMobile { get; set; }
        public decimal Amount { get; set; }
        public string Narration { get; set; }
        public DateTime DueDate { get; set; }
        public int RecipientId { get; set; }
    }
}
