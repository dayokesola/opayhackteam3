using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackOpay.Core.Domain
{
    public class Customer : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string AccountNumber { get; set; } 
        public int BankId { get; set; }
    }

    public class BaseEntity<T>
    {
        public T Id { get; set; }
        public int RecordStatus { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
