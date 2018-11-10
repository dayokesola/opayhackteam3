using System;
using System.Linq;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using HackOpay.Core.Module;

namespace HackOpay.Web.Controllers
{

    public class BaseController : Controller
    {
        LogicModule _logic;
        public LogicModule Logic { get { if (_logic == null) { _logic = new LogicModule(); } return _logic; } }

    }

}