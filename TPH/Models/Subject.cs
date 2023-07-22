namespace TPH.Models
{
	public class Subject
	{
        public int SubjectId { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public int Hours { get; set; }

        public string TeacherId { get; set; }

        public virtual Teacher Teacher { get; set; }

        public virtual ICollection<StudentWithSubject> Students { get; set; } = new HashSet<StudentWithSubject>();
    }
}
