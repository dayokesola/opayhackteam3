using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HackOpay.Core.Domain
{

    public class BaseEntity<T>
    {
        public T Id { get; set; }
        public int RecordStatus { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

}