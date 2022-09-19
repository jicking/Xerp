using RestSharp;
using System.Text.Json;
using System.Threading;

namespace Xerp.Core.Services;

public interface IAuthTokenService {
	Task<AuthToken> GetTestAuthTokenAsync();
}
public class Auth0TokenService : IAuthTokenService {

	public async Task<AuthToken> GetTestAuthTokenAsync() {
		var client = new RestClient("https://jickingdev.us.auth0.com/oauth");
		var request = new RestRequest("/token");
		request.AddHeader("content-type", "application/json");
		request.AddParameter("application/json", "{\"client_id\":\"hxc3B3CXbrXDskMh7WDxYhBxsxYzwrSN\",\"client_secret\":\"wyt6E3aX4gkMYf3XHazuG0W1PU3LBF6ecyGSyFK_tWeJCFZ3eoWdFqjxwsL1TWmr\",\"audience\":\"xerp-service\",\"grant_type\":\"client_credentials\"}", ParameterType.RequestBody);
		var response = await client.PostAsync(request, CancellationToken.None);

		if (response.IsSuccessful) {
			var token = JsonSerializer.Deserialize<AuthToken>(response.Content);
			return token;
		}

		return null;
	}
}

public class AuthToken {
	public string access_token { get; set; }
	public string token_type { get; set; }
}
