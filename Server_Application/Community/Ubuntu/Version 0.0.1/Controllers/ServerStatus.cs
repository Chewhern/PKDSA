using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PKDSA_ServerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServerStatus : ControllerBase
    {

        //There're many HTTP responses, if this function could be called and return
        //normal status, it indicates that the server is online
        [HttpGet]
        public void EmptyFunction() 
        {
            
        }
    }
}
