using MCApplicationServices.Interfaces;
using MCInfrastructure.Messaging.Responses.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MCWebAPI.Controllers
{
    /// <summary>
    /// Authentication controller
    /// </summary>
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class AuthController : ControllerBase
    {
        private readonly IJWTAuthenticationManager _manager;
        /// <summary>
        /// Authentication controller
        /// </summary>
        /// <param name="manager"></param>
        public AuthController(IJWTAuthenticationManager manager)
        {
            _manager = manager;
        }
        /// <summary>
        /// Generate Jwt token
        /// </summary>
        /// <param name="clientId">Client Identifier</param>
        /// <param name="secret">Client Secret</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Token([FromQuery] string clientId, [FromQuery] string secret)
        {
            var token = _manager.Authenticate(clientId, secret);
            return Ok(await Task.FromResult(new TokenResponse() { Token = token }));
        }
    }
}
