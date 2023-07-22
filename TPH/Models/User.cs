using Microsoft.AspNetCore.Identity;

namespace TPH.Models
{
	public class User : IdentityUser
	{
		public virtual ICollection<RefreshToken>? RefreshTokens { get; set; } = new HashSet<RefreshToken>();
    }
}
