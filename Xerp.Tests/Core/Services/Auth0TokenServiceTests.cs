namespace Xerp.Core.Services.Tests;

public class Auth0TokenServiceTests {
	private readonly IAuthTokenService _sut;

	public Auth0TokenServiceTests() {
		_sut = new Auth0TokenService();
	}

	[Fact()]
	public void GetTestAuthTokenAsyncTest() {
		var result = _sut.GetTestAuthTokenAsync().Result;
		Assert.NotNull(result);
	}
}