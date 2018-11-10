using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HackOpay.Core.Domain
{

    public class Bank : BaseEntity<int>
    {
        public string Name { get; set; } 
    }

}