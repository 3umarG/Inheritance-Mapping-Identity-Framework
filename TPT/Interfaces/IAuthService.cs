using TPT.DTOs;
using TPT.Models.Auth;

namespace TPT.Interfaces
{
	public interface IAuthService
	{
		public Task<AuthModel> RegisterStudent(StudentRegisterDto dto);

		public Task<AuthModel> LoginAsync(LoginDto dto); 
		
		public Task<AuthModel> RegisterTeacherAsync(TeacherRegisterDto dto);

		
	}
}
