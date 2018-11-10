using System;
using System.Linq;
using System.Collections.Generic;
using HackOpay.Core.Common;
using HackOpay.Core.Domain;
using HackOpay.Core.Module;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.ModelBinding;
using HackOpay.Core.Form;

namespace HackOpay.Web.Controllers
{

    public class TransactServiceController : BaseApiController
    {

        [ResponseType(typeof(IEnumerable<TransactModel>))]
        [Route("Validate")]
        [HttpGet]
        public IHttpActionResult Validate(string mobile = "", string paymentref = "")
        {
            try
            {
                var items = Logic.TransactService.ValidatePayment(mobile, paymentref);
                
                return Ok(items);
            }
            catch (Exception ex)
            { 
                return BadRequest(ex.Message);
            }
        }


        [ResponseType(typeof(IEnumerable<TransactModel>))]
        [Route("Initiate")]
        [HttpPost]
        public IHttpActionResult Initiate(TransactForm form)
        {
            try
            {
                var items = Logic.TransactService.Initiate(form);

                return Ok(items);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }

}