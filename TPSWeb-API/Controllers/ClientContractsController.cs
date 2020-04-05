using System.Web.Http;
using System.Web.Http.Cors;
using TPSWeb_API.Core.Features.ClientContracts;

namespace TPSWeb_API.Controllers
{
    [EnableCors(origins: "https://localhost:44340", headers: "*", methods: "*")]
    public class ClientContractsController : ApiController
    {
        private ClientContractsHandler clientContractsHandler;
        public ClientContractsController(ClientContractsHandler _clientContractsHandler)
        {
            this.clientContractsHandler = _clientContractsHandler;
        }

        [HttpGet]
        // GET api/ClientContracts
        public IHttpActionResult GetAll()
        {
            var response = clientContractsHandler.GetAll();
            if (response.IsSuccess)
            {
                return Ok(response.data);
            }
            return BadRequest(response.Message);
        }

        [HttpGet]
        // GET api/ClientContracts/5
        public IHttpActionResult Get(int id)
        {
            var response = clientContractsHandler.Get(id);
            if (response.IsSuccess)
            {
                return Ok(response.data);
            }
            return BadRequest(response.Message);
        }

        [HttpPost]
        public IHttpActionResult Post(ClientContractModel clientContractModel)
        {
            var response = clientContractsHandler.Add(clientContractModel);
            if (response.IsSuccess)
            {
                return Ok(response.Message);
            }
            return BadRequest(response.Message);
        }

        [HttpPut]
        public IHttpActionResult Put(int id, ClientContractModel clientContractModel)
        {
            var response = clientContractsHandler.Update(id, clientContractModel);
            if (response.IsSuccess)
            {
                return Ok(response.Message);
            }
            return BadRequest(response.Message);
        }
    }
}
