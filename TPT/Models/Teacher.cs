namespace TPT.Models
{
	public class Teacher : User
	{
		public int Age { get; set; }

		public string Degree { get; set; }

		public virtual ICollection<Subject> Subjects { get; set; } = new HashSet<Subject>();

        public int RoomId { get; set; }

		public virtual Room Room { get; set; }

    }
}
