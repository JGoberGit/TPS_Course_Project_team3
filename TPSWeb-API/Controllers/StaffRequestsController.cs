using System.Web.Http;
using System.Web.Http.Cors;
using TPSWeb_API.Core.Features.StaffRequests;

namespace TPSWeb_API.Controllers
{
    [EnableCors(origins: "https://localhost:44340", headers: "*", methods: "*")]
    public class StaffRequestsController : ApiController
    {
        private StaffRequestsHandler staffRequestsHandler;
        public StaffRequestsController(StaffRequestsHandler _staffRequestsHandler)
        {
            this.staffRequestsHandler = _staffRequestsHandler;
        }

        [HttpGet]
        // GET api/StaffRequests
        public IHttpActionResult GetAll()
        {
            var response = staffRequestsHandler.GetAll();
            if (response.IsSuccess)
            {
                return Ok(response.data);
            }
            return BadRequest(response.Message);
        }

        [HttpGet]
        // GET api/StaffRequests/5
        public IHttpActionResult Get(int id)
        {
            var response = staffRequestsHandler.Get(id);
            if (response.IsSuccess)
            {
                return Ok(response.data);
            }
            return BadRequest(response.Message);
        }

        [HttpPost]
        public IHttpActionResult Post(StaffRequestModel staffRequestModel)
        {
            var response = staffRequestsHandler.Add(staffRequestModel);
            if (response.IsSuccess)
            {
                return Ok(response.Message);
            }
            return BadRequest(response.Message);
        }

        [HttpPut]
        public IHttpActionResult Put(int id, StaffRequestModel staffRequestModel)
        {
            var response = staffRequestsHandler.Update(id, staffRequestModel);
            if (response.IsSuccess)
            {
                return Ok(response.Message);
            }
            return BadRequest(response.Message);
        }
    }
}
