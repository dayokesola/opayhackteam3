using HackOpay.Core.Data.Repository;
using HackOpay.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackOpay.Core.Module
{
    public class LogicModule
    {

        private UserService _user;

        public UserService UserService { get { if (_user == null) { _user = new UserService(); } return _user; } }


        private TransactService _tran;

        public TransactService TransactService { get { if (_tran == null) { _tran = new TransactService(); } return _tran; } }

    }

    public class DataModule
    {
        private TransactRepository _transactRepo;
        private TransactModelRepository _transactModelRepo;
        private PayerRepository _payerRepo;
        private RecipientRepository _recipientRepo; 


        public TransactRepository Transacts { get { if (_transactRepo == null) { _transactRepo = new TransactRepository(); } return _transactRepo; } }
        public TransactModelRepository TransactModels { get { if (_transactModelRepo == null) { _transactModelRepo = new TransactModelRepository(); } return _transactModelRepo; } }
        public PayerRepository Payers { get { if (_payerRepo == null) { _payerRepo = new PayerRepository(); } return _payerRepo; } }
        public RecipientRepository Recipients { get { if (_recipientRepo == null) { _recipientRepo = new RecipientRepository(); } return _recipientRepo; } }

    }
}
