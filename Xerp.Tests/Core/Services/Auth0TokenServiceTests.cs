using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xerp.Core.Services;
using Xunit;

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