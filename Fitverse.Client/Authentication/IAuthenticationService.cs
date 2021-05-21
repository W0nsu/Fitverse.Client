using System.Threading.Tasks;
using Fitverse.Client.Models;

namespace Fitverse.Client.Authentication
{
	public interface IAuthenticationService
	{
		Task<AuthenticatedUserModel> LoginAsync(AuthenticationUserModel userForAuthentication);
		Task LogoutAsync();
	}
}