//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Xerp.Core.Services;

//namespace Xerp.Controllers;

//[Route("api/[controller]"), ApiController, AllowAnonymous]
//public class TestTokensController : ControllerBase {
//	private readonly IAuthTokenService _authTokenSvc;

//	public TestTokensController(
//		IAuthTokenService authTokenSvc
//		) {
//		_authTokenSvc = authTokenSvc;
//	}

//	// GET: api/<TestTokensController>
//	[HttpGet]
//	public async Task<AuthToken> GetAsync() {
//		return await _authTokenSvc.GetTestAuthTokenAsync();
//	}
//}
