using HackOpay.Core.Common;
using HackOpay.Core.Domain;
using HackOpay.Core.Form;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackOpay.Core.Service
{
    public class UserService : BaseService
    {
        public Recipient SignUp(SignUpForm form)
        {
            //check if the email is valid
            if(!Util.IsEmail(form.Email))
            {
                throw new Exception("Invalid Email");
            }

            //check if email exists
            var user =  DataModule.Recipients.Search(email: form.Email).Items.FirstOrDefault();
            if(user != null)
            {
                throw new Exception("Email is already in use");
            }


            user = DataModule.Recipients.Search(mobile: form.Mobile).Items.FirstOrDefault();
            if (user != null)
            {
                throw new Exception("Mobile is already in use");
            }

            //go ahead and create the recipient

            user = CreateRecipient(form);


            //insert to db
            user = DataModule.Recipients.Insert(user);

            if(user.Id <= 0)
            {
                throw new Exception("user could not be added to DB");
            }

            return user;

        }

        public Recipient CreateRecipient(SignUpForm form)
        {
            return new Recipient()
            {
                AccountNumber = form.AccountNumber,
                BankId = form.BankId,
                Mobile = form.Mobile,
                Email = form.Email,
                Name = form.FullName(),
                RecordStatus = 1
            };
        }
    }


    public class TransactService : BaseService
    {
        public List<TransactModel> ValidatePayment(string mobile, string paymentRef)
        {
            return null;
        }
    }
}
