using Microsoft.AspNetCore.Identity;

namespace TPT.Models
{
	public class User : IdentityUser
	{
		public virtual ICollection<RefreshToken>? RefreshTokens { get; set; } = new HashSet<RefreshToken>();
    }
}
