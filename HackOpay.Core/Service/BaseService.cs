using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HackOpay.Core.Module;

namespace HackOpay.Core.Service
{

    public class BaseService
    {

        DataModule _data;
         

        public DataModule DataModule { get { if (_data == null) { _data = new DataModule(); } return _data; } }

    }

}