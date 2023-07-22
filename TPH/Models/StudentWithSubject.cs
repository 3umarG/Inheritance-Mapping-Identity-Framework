namespace TPH.Models
{
	public class StudentWithSubject
	{
        public int SubjectId { get; set; }

        public string StudentId { get; set; }

        public double Grade { get; set; }


        public virtual Student Student { get; set; }

        public virtual Subject Subject { get; set; }

    }
}
