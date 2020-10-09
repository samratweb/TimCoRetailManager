using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using TRMDataManager.Library.DataAccess;

namespace TRMDataManager.Controllers
{
    [Authorize]
    public class UserController : ApiController
    {
        // GET api/user
        public IHttpActionResult Get()
        {
            string userId = RequestContext.Principal.Identity.GetUserId();
            UserData user = new UserData();
            var userList = user.GetUsersById(userId);
            return Ok(userList);
        }
    }
}
