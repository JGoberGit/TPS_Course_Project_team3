using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using TPSWeb_API.Core.Features.UserAccounts;

namespace TPSWeb_API.Controllers
{
    [EnableCors(origins: "https://localhost:44340", headers: "*", methods: "*")]
    public class UserAccountsController : ApiController
    {
        private UserAccountHandler userAccountHandler;
        public UserAccountsController(UserAccountHandler _userAccountHandler)
        {
            this.userAccountHandler = _userAccountHandler;
        }

        [HttpGet]
        // GET api/UserAccounts/
        public IHttpActionResult Get(UserAccountModel userAccountModel)
        {
            var response = userAccountHandler.Verify(userAccountModel);
            if (response.IsSuccess)
            {
                return Ok(response.Message);
            }
            return BadRequest(response.Message);
        }

        [HttpPost]
        // api/UserAccounts/
        public IHttpActionResult Post(UserAccountModel userAccountModel)
        {
            var response = userAccountHandler.Add(userAccountModel);
            if (response.IsSuccess)
            {
                return Ok(response.Message);
            }
            return BadRequest(response.Message);
        }
    }
}
