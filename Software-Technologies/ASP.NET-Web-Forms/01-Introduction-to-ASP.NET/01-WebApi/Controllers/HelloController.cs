using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _1._3.Web_Api.Controllers
{
    public class HelloController : ApiController
    {
        public string Get(int id)
        {
            return "Hello, world!";
        }
    }
}
