﻿namespace TPC.Models
{
	public class Student : User
	{
        public string Address { get; set; }

        public string PhoneNumber { get; set; } 

        public virtual ICollection<StudentWithSubject>? Subjects { get; set; } = new HashSet<StudentWithSubject>();

		public virtual ICollection<RefreshToken>? RefreshTokens { get; set; } = new HashSet<RefreshToken>();
	}
}
