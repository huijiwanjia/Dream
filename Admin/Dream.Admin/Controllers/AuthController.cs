using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dream.Security.Auth;

namespace Dream.Admin.Controllers
{
    [DreamAuthorize]
    public class AuthController : Controller
    {
       
    }
}