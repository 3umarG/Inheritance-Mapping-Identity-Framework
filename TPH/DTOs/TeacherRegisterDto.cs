namespace TPH.DTOs
{
	public class TeacherRegisterDto : LoginDto
	{
		public int Age { get; set; }

		public string Degree { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
