using Microsoft.AspNetCore.Mvc;

namespace TanakhsApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public abstract class BackendControllerBase : ControllerBase { }
}
