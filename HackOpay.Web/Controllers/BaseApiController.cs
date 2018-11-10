using HackOpay.Core.Common;
using HackOpay.Core.Domain;
using HackOpay.Core.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.ModelBinding;

namespace HackOpay.Web.Controllers
{

    public class BaseApiController : ApiController
    {
        LogicModule _logic; 
        public LogicModule Logic { get { if (_logic == null) { _logic = new LogicModule(); } return _logic; } } 


        /// <summary>
        /// Adds the header.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="data">The data.</param>
        [ApiExplorerSettings(IgnoreApi = true)]
        protected void AddHeader(string key, object data)
        {

            HttpContext.Current.Response.Headers.Add(key, Util.SerializeJSON(data));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelState"></param>
        /// <returns></returns>
        [ApiExplorerSettings(IgnoreApi = true)]
        public string ModelError(ModelStateDictionary modelState)
        {
            string error = "";
            foreach (var state in modelState.Values)
            {
                foreach (var msg in state.Errors)
                {
                    error += msg.ErrorMessage + "<br />";
                }
            }
            return error;
        }


         
    }



}
