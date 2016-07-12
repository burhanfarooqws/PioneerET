using PioneerET.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PioneerET.API.Controllers
{
    public class UsersController : ApiController
    {
        /// <summary>
        /// Gets All Users listed
        /// </summary>
        /// <returns>List of Users</returns>
        public IHttpActionResult Get()
        {
            return Ok(new Users().Get());
        }
    }
}
