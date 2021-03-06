using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;

namespace Fitverse.Client.Authentication
{
	public class AuthStateProvider : AuthenticationStateProvider
	{
		private readonly AuthenticationState _anonymous;
		private readonly HttpClient _httpClient;
		private readonly ILocalStorageService _localStorage;

		public AuthStateProvider(HttpClient httpClient, ILocalStorageService localStorage)
		{
			_httpClient = httpClient;
			_localStorage = localStorage;
			_anonymous = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
		}

		public override async Task<AuthenticationState> GetAuthenticationStateAsync()
		{
			var token = await _localStorage.GetItemAsync<string>("authToken");
			if (string.IsNullOrWhiteSpace(token))
				return _anonymous;

			_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);

			return new AuthenticationState(
				new ClaimsPrincipal(new ClaimsIdentity(JwtParser.ParseClaimsFromJwt(token), "jwtAuthType")));
		}

		public void NotifyUserAuthentication(string token)
		{
			var authenticatedUser =
				new ClaimsPrincipal(new ClaimsIdentity(JwtParser.ParseClaimsFromJwt(token), "jwtAuthType"));
			var authenticationState = Task.FromResult(new AuthenticationState(authenticatedUser));

			NotifyAuthenticationStateChanged(authenticationState);
		}

		public void NotifyUserLogout()
		{
			var authenticationState = Task.FromResult(_anonymous);
			NotifyAuthenticationStateChanged(authenticationState);
		}
	}
}