using System.Web.Http;
using System.Web.Http.Cors;
using TPSWeb_API.Core.Features.StaffProfiles;

namespace TPSWeb_API.Controllers
{
    [EnableCors(origins: "https://localhost:44340", headers: "*", methods: "*")]
    public class StaffProfilesController : ApiController
    {
        private StaffProfilesHandler staffProfileHandler;
        public StaffProfilesController(StaffProfilesHandler _staffProfileHandler)
        {
            this.staffProfileHandler = _staffProfileHandler;
        }

        [HttpGet]
        // GET api/StaffProfiles
        public IHttpActionResult GetAll()
        {
             var response = staffProfileHandler.GetAll();
             if (response.IsSuccess)
             {
                 return Ok(response.data);
             }
             return BadRequest(response.Message);
        }

        [HttpGet]
        // GET api/StaffProfiles/5
        public IHttpActionResult Get(int id)
        {
            var response = staffProfileHandler.Get(id);
            if (response.IsSuccess)
            {
                return Ok(response.data);
            }
            return BadRequest(response.Message);
        }

        [HttpPost]
        public IHttpActionResult Post(StaffProfileModel staffProfileModel)
        {
            var response = staffProfileHandler.Add(staffProfileModel);
            if (response.IsSuccess)
            {
                return Ok(response.Message);
            }
            return BadRequest(response.Message);
        }

        [HttpPut]
        public IHttpActionResult Put(int id, StaffProfileModel staffProfileModel)
        {
            var response = staffProfileHandler.Update(id, staffProfileModel);
            if (response.IsSuccess)
            {
                return Ok(response.Message);
            }
            return BadRequest(response.Message);
        }
    }

    

}
