using System.ComponentModel.DataAnnotations;

namespace Fitverse.Client.Models
{
	public class AuthenticationUserModel
	{ 
		public string Username { get; set; }
		public string Password { get; set; }
	}
}