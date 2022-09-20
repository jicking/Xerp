using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace Xerp.Pages.Account;

public class IndexModel : PageModel {
	public void OnGet() {
		var Name = User.Identity.Name;
		var EmailAddress = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
		var ProfileImage = User.Claims.FirstOrDefault(c => c.Type == "picture")?.Value;
	}
}
