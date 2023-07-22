namespace TPC.Models
{
	public class Teacher : User
	{
		public int Age { get; set; }

		public string Degree { get; set; }

		public virtual ICollection<Subject>? Subjects { get; set; } = new HashSet<Subject>();

        public int? RoomId { get; set; }

		public virtual Room? Room { get; set; }

		public virtual ICollection<RefreshToken>? RefreshTokens { get; set; } = new HashSet<RefreshToken>();
	}
}
