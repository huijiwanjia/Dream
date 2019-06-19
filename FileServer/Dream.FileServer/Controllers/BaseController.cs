using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dream.ExceptionHandler.Filter;

namespace Dream.FileServer.Controllers
{
    [ErrorHanlder]
    public class BaseController : Controller
    {
    }
}
