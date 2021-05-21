using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Fitverse.Client.Models;
using Microsoft.AspNetCore.Components.Authorization;

namespace Fitverse.Client.Authentication
{
	
	public class AuthenticationService : IAuthenticationService
	{
		private readonly AuthenticationStateProvider _authStateProvider;
		private readonly HttpClient _client;
		private readonly ILocalStorageService _localStorage;

		public AuthenticationService(HttpClient client, AuthenticationStateProvider authStateProvider,
			ILocalStorageService localStorage)
		{
			_client = client;
			_authStateProvider = authStateProvider;
			_localStorage = localStorage;
		}

		public async Task<AuthenticatedUserModel> LoginAsync(AuthenticationUserModel userForAuthentication)
		{
			var authResult = await _client.PostAsJsonAsync("api/auth/login", userForAuthentication);
			var authContent = await authResult.Content.ReadAsStringAsync();

			if (!authResult.IsSuccessStatusCode)
				return null;

			var result = JsonSerializer.Deserialize<AuthenticatedUserModel>(authContent,
				new JsonSerializerOptions{PropertyNameCaseInsensitive = true});

			await _localStorage.SetItemAsync("authToken", result.AccessToken);
			
			((AuthStateProvider)_authStateProvider).NotifyUserAuthentication(result.AccessToken);

			_client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", result.AccessToken);

			return result;
		}

		public async Task LogoutAsync()
		{
			await _localStorage.RemoveItemAsync("authToken");
			((AuthStateProvider)_authStateProvider).NotifyUserLogout();
			_client.DefaultRequestHeaders.Authorization = null;
		}
	}
}