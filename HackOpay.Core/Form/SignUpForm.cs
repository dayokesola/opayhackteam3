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
}
