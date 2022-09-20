using Auth0.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Xerp.Pages.Account;

[AllowAnonymous]
public class LoginModel : PageModel {
	public void OnGet(string returnUrl = "/") {
		var authenticationProperties = new LoginAuthenticationPropertiesBuilder()
		// Indicate here where Auth0 should redirect the user after a login.
		// Note that the resulting absolute Uri must be added to the
		// **Allowed Callback URLs** settings for the app.
		.WithRedirectUri(returnUrl)
		.Build();

		HttpContext.ChallengeAsync(Auth0Constants.AuthenticationScheme, authenticationProperties).Wait();
	}
}
