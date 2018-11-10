using HackOpay.Core.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackOpay.Core.Module
{
    public class LogicModule
    {
        private TransactRepository _transactRepo;


    }

    public class DataModule
    {
        private TransactRepository _transactRepo;
        private PayerRepository _payerRepo;
        private RecipientRepository _recipientRepo; 


        public TransactRepository Transacts { get { if (_transactRepo == null) { _transactRepo = new TransactRepository(); } return _transactRepo; } }
        public PayerRepository Payers { get { if (_payerRepo == null) { _payerRepo = new PayerRepository(); } return _payerRepo; } }
        public RecipientRepository Recipients { get { if (_recipientRepo == null) { _recipientRepo = new RecipientRepository(); } return _recipientRepo; } }

    }
}
