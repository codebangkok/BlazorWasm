using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;

namespace Server.Controllers
{
    public class OidcConfigurationController : Controller
    {
        IClientRequestParametersProvider parametersProvider;

        public OidcConfigurationController(IClientRequestParametersProvider parametersProvider)
        {
            this.parametersProvider = parametersProvider;
        }

        [HttpGet("_configuration/{clientId}")]
        public IActionResult GetClientRequestParametersProvider([FromRoute]string clientId)
        {
            var parameters = parametersProvider.GetClientParameters(HttpContext, clientId);
            return Ok(parameters);
        }
    }
}