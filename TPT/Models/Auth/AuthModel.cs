using System.Text.Json.Serialization;

namespace TPT.Models.Auth
{
	public class AuthModel
	{
		public string UserName { get; set; }
		public string Email { get; set; }

		[JsonIgnore]
		public string Message { get; set; }

		public bool IsAuthed { get; set; }

		public string Token { get; set; }

		[JsonIgnore]
		public string? RefreshToken { get; set; }

		public DateTime AccessTokenExpiration { get; set; }

		public DateTime RefreshTokenExpiration { get; set; }


	}
}
