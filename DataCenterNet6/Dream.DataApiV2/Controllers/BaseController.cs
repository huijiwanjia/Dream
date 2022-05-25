using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dream.ExceptionHandler.Filter;

namespace Dream.DataApi.Controllers
{
    [ErrorHanlder]
    [Route("dream/[controller]")]
    public class BaseController : Controller
    {
    }
}
