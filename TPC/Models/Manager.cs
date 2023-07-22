namespace TPC.Models
{
	public class Manager : User
	{
		public virtual ICollection<RefreshToken>? RefreshTokens { get; set; } = new HashSet<RefreshToken>();
	}
}
